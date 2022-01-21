using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeScript : MonoBehaviour {

	[Header("hours")]
	public Text hourText;
	public float secondsPerHour; //we use mobile times, not pc, that takes way too long. this can always be changed!
	public int time = 0;
	public string hourExtraText;

	[Header("night")]
	public bool fnaf4;
	public int whichGame;
	public Text nightText;
	public whichNight wNight;
	public string nightExtraText;

	void Start () {
		if (!fnaf4)
        {
			setNightText();
		}
        else
        {
			whichGame = 4;
        }
		StartCoroutine(doTimeLoop());
	}

	void setNightText()
    {
		nightText.text = nightExtraText + " " + wNight._whichNight.ToString();
    }

	IEnumerator doTimeLoop()
    {
		if (time == 0)
		{
			hourText.text = "12 " + hourExtraText;
		}
		else if (time == 6)
        {
			if (!fnaf4)
				SceneManager.LoadSceneAsync("6am_" + wNight._whichGame.ToString());
			else
				SceneManager.LoadSceneAsync("6am_" + whichGame.ToString());
		}
        else
        {
			hourText.text = time.ToString() + " " + hourExtraText;
        }
		yield return new WaitForSeconds(secondsPerHour);
		time++;
		StartCoroutine(doTimeLoop());
    }
	
}
