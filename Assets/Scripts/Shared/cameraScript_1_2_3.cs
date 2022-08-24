using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript_1_2_3 : MonoBehaviour {

	[Header("camera animations")]
	public Animator camAnim;
	public Animator switchCam;
	public Animation camMovement;

	[Header("Gameobjects to enable/disabled")]
	public GameObject camGameObject;
	public GameObject camScreen;

	[Header("Image to change")]
	public Image camScreenImg;

	[Header("How long the animation should take (0.2/0.3s)")]
	public float animTime = 0.2f;

	[Header("states")]
	public bool isOn = false;
	public int camOn = 0;
	public bool moves = false;
	public string status = "nothing";

	[Header("audio")]
	public AudioSource[] sfx;

	[Header("Camera's + old camera frames to reload from mem")]
	public Sprite[] cams; //edited according to anni pos
	public Sprite[] camsBackup;

	[Header("General camera info")]
	public int whichCam;
	public Text camName;
    public string[] camNames;
	public string[] specialProperty;


	[Header("Fnaf 2 specific stuff")]
	public bool fnaf2;
	public mask_2 maskScript;
	public AudioSource musicBox;
	public string musicBoxSpritePath;
	public Image winderLevel;
	public float unwindDelay;
	public GameObject windButton;
	public animatronic_2 ani2Script;
	public int spriteCounter = 1;
	public int maxSprites = 21;

	[Header("fnaf 3 stuff")]
	public bool fnaf3;
	public Sprite map;
	public Sprite vMap;
	public Image mapImage;
	public GameObject normalButtons;
	public GameObject ventButtons;
	public GameObject audioButton;
	public int mapId = 0;
	public int camIdMap1;
	public int camIdMap2;

	[Header("office script")]
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
			camGameObject.SetActive(true);
			camAnim.SetTrigger("putUp");
			yield return new WaitForSeconds(0.01f);
			sfx[0].Play();
			yield return new WaitForSeconds(animTime);
			isOn = true;
			camOn = 1;
			camScreen.SetActive(true);
			camGameObject.SetActive(false);
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
			camGameObject.SetActive(true);
			camAnim.SetTrigger("putDown");
			yield return new WaitForSeconds(0.01f);
			camScreen.SetActive(false);
			sfx[1].Play();
			yield return new WaitForSeconds(animTime);
			isOn = false;
			camOn = 0;
			camGameObject.SetActive(false);
			status = "nothing";
			yield break;
		}
	}

	void Start()
    {
		for (int i = 0; i < cams.Length; i++)
		{
			camsBackup[i] = cams[i];
		}

		if (fnaf2)
		{
			StartCoroutine(unwindbox(unwindDelay));
		}
	}

    public void cam()
    {
		if (!isOn)
		{
			if (maskScript != null && maskScript.isOn == false)
            {
				StartCoroutine(putUp());
			}
			else if (maskScript == null)
            {
				StartCoroutine(putUp());
			}
		}
		else if (isOn)
		{
			StartCoroutine(putDown());
		}

		resetMouse();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.R))
		{
			if (!fnaf3)
            {
				cam();
			}
            else
            {
				if (officeScript.currentLimit == officeScript.camLimit[0])
                {
					cam();
				}
            }
		}

		if (moves)
		{
			if (camMovement.isPlaying == false)
            {
				camMovement.Play("camMove");
			}
		}

		if (fnaf3)
        {
			if (mapId == 0)
            {
				
				camIdMap1 = whichCam;
			}
			else if (mapId == 1)
            {
				
				camIdMap2 = whichCam;
			}
        }

		//fnaf 2
		doMusicBox();
	}

	public void switchCamera(int camId)
    {
		whichCam = camId;
		camScreenImg.sprite = cams[whichCam];
		camName.text = camNames[whichCam];
		switchCam.SetTrigger("switch");
		if (isOn)
        {
			sfx[2].Play();
		}
		resetMouse();
	}

	public void switchMap()
    {
		//only used in fnaf 3 so values are hardcoded
		if (mapId == 0)
        {
			mapImage.sprite = vMap;
			normalButtons.SetActive(false);
			ventButtons.SetActive(true);
			audioButton.SetActive(false);

			mapId = 1;
		}
		else if (mapId == 1)
		{
			mapImage.sprite = map;
			normalButtons.SetActive(true);
			ventButtons.SetActive(false);
			audioButton.SetActive(true);

			mapId = 0;
		}

		//reload the cams to previous vent/map camera
		if (mapId == 0)
        {
			whichCam = camIdMap1;
        }
		else if (mapId == 1)
		{
			whichCam = camIdMap2;
		}

		switchCamera(whichCam);
	}

	public void windbox()
    {
		if (spriteCounter > 1)
        {
			spriteCounter -= 1;

			Sprite timelySprite = Resources.Load<Sprite>(musicBoxSpritePath + spriteCounter.ToString());
			winderLevel.sprite = timelySprite;
		}
	}

	IEnumerator unwindbox(float delay)
    {

		yield return new WaitForSeconds(delay);

		if (spriteCounter < maxSprites)
			spriteCounter += 1;
		//else
			//ani2Script.

		Sprite timelySprite = Resources.Load<Sprite>(musicBoxSpritePath + spriteCounter.ToString());
		winderLevel.sprite = timelySprite;

		StartCoroutine(unwindbox(delay));
    }

	public void doMusicBox()
    {
		if (isOn && fnaf2)
        {

			//audio part
			if (specialProperty[whichCam] == "musicbox")
			{
				if (musicBox.isPlaying == false)
				{
					musicBox.Play();
				}

				windButton.SetActive(true);
			}
			else
			{
				if (musicBox != null)
				{
					musicBox.Stop();
				}

				windButton.SetActive(false);
			}
		}
        else if (!isOn || !fnaf2)
        {
			if (musicBox.isPlaying == true)
			{
				musicBox.Stop();
			}

			windButton.SetActive(false);
		}
	}

	void resetMouse()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.lockState = CursorLockMode.None;
	}
}
