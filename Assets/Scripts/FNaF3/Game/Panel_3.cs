using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_3 : MonoBehaviour {

	[Header("Animations")]
	public Animator panelAnim;

	[Header("Gameobjects to enable/disabled")]
	public GameObject panelGameobject;
	public GameObject panelScreen;

	[Header("How long the animation should take (0.2/0.3s)")]
	public float animTime = 0.2f;

	[Header("states")]
	public bool isOn = false;
	public bool restarting = false;
	public string status = "nothing";
	public int whichOption;

	[Header("audio")]
	public AudioSource[] sfx;

	[Header("all the options")]
	public Text[] options;
	public string[] optionStringsSelected;
	public string[] optionStringsUnselected;
	public string block = "[]";
	public string error = "<color=red> error </color>";

	[Header("scripts")]
	public officeScript_1_2_3 officeScript;

	IEnumerator putUp()
	{
		if (status == "animating")
		{
			yield break;
		}
		else
		{
			status = "animating";
			panelGameobject.SetActive(true);
			panelAnim.SetTrigger("putUp");
			yield return new WaitForSeconds(0.01f);
			sfx[0].Play();
			yield return new WaitForSeconds(animTime);
			isOn = true;
			panelScreen.SetActive(true);
			panelGameobject.SetActive(false);
			status = "nothing";
			yield break;
		}
	}

	IEnumerator putDown()
	{
		if (status == "animating")
		{
			yield break;
		}
		else
		{
			status = "animating";
			panelGameobject.SetActive(true);
			panelAnim.SetTrigger("putDown");
			yield return new WaitForSeconds(0.01f);
			panelScreen.SetActive(false);
			sfx[1].Play();
			yield return new WaitForSeconds(animTime);
			isOn = false;
			panelGameobject.SetActive(false);
			status = "nothing";
			yield break;
		}
	}

	public void panel()
	{
		if (!isOn)
		{
			StartCoroutine(putUp());
		}
		else if (isOn)
		{
			StartCoroutine(putDown());
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.L))
		{
			if (officeScript.currentLimit == officeScript.camLimit[1])
			{
				panel();
			}
		}

		if (isOn)
        {
			if ((Input.GetKeyDown(KeyCode.JoystickButton8) && whichOption > 0) && !restarting || (Input.GetKeyDown(KeyCode.UpArrow) && whichOption > 0) && !restarting)
			{
				whichOption--;
			}
			else if ((Input.GetKeyDown(KeyCode.JoystickButton10) && whichOption < options.Length - 1) && !restarting || (Input.GetKeyDown(KeyCode.DownArrow) && whichOption < options.Length - 1) && !restarting)
			{
				whichOption++;
			}

			if ((Input.GetKeyDown(KeyCode.JoystickButton0)) && !restarting || (Input.GetKeyDown(KeyCode.X)) && !restarting)
			{
				select();
			}

			for (int i = 0; i < options.Length; i++)
            {
				options[i].text = optionStringsUnselected[i];
				if (!restarting)
					options[whichOption].text = optionStringsSelected[whichOption];
                else
					options[whichOption].text = optionStringsSelected[whichOption] + block;
			}
		}
	}

	double randomWait;
	float randWait;
	float restartPhaseMultiplier;
	int multiplier;

	void genRandomNumber()
    {
		randomWait = System.Math.Round(UnityEngine.Random.Range(0.3f, 0.8f));
		randWait = (float)randomWait;
	}

	IEnumerator animateRestartPhase(int deviceId)
    {
		sfx[2].Play();
		int device = deviceId;
		genRandomNumber();
		block = " []";
		yield return new WaitForSeconds(randWait);
		block = "  []";
		genRandomNumber();
		yield return new WaitForSeconds(randWait);
		block = "   []";
		genRandomNumber();
		yield return new WaitForSeconds(randWait);
		block = "    []";
		genRandomNumber();
		multiplier++;
		if (multiplier < restartPhaseMultiplier)
        {
			yield return new WaitForSeconds(0.1f);
			StartCoroutine(animateRestartPhase(device));
		}
        else
        {
			restarting = false;
			yield break;
        }
	}

	void select()
    {
		float multiplier = 3;

		if (whichOption == 0 || whichOption == 1 || whichOption == 2)
        {
			multiplier = 3;
			restartPhaseMultiplier = multiplier;
			StartCoroutine(animateRestartPhase(whichOption));

			restarting = true;
		}
		else if (whichOption == 3)
        {
			multiplier = 5;
			restartPhaseMultiplier = multiplier;
			StartCoroutine(animateRestartPhase(whichOption));

			restarting = true;
		}
		else if (whichOption == 4)
        {
			panel();
        }
    }
}
