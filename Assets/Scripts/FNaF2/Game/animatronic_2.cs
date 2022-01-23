using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animatronic_2 : MonoBehaviour {

	[Header("Cam arrays")]
	public string[] stageCams;
	public string[] freddyLocations;
	public string[] bonnieLocations;
	public string[] chicaLocations;
	public string[] foxyLocations;
	public string[] toyFreddyLocations;
	public string[] toyBonnieLocations;
	public string[] toyChicaLocations;
	public string[] mangleLocations;
	public string[] bbLocations;

	[Header("jumpscare")]
	public int whichJumpscare;

	[Header("positions")]
	public int freddyPos;
	public int bonniePos;
	public int chicaPos;
	public int foxyPos;
	public int toyFreddyPos;
	public int toyBonniePos;
	public int toyChicaPos;
	public int manglePos;
	public int bbPos;

	[Header("annimatronic levels")]
	public int freddyLevel = 0;
	public int bonnieLevel = 0;
	public int chicaLevel = 0;
	public int foxyLevel = 0;
	public int toyFreddyLevel = 0;
	public int toyBonnieLevel = 0;
	public int toyChicaLevel = 0;
	public int mangleLevel = 0;
	public int bbLevel;

	[Header("fx")]
	public bool freddyMoved;
	public bool bonnieMoved;
	public bool chicaMoved;
	public bool foxyMoved;
	public bool toyFreddyMoved;
	public bool toyBonnieMoved;
	public bool toyChicaMoved;
	public bool mangleMoved;
	public bool bbMoved;
	public Color fxColor;
	public Color normalColor;
	public Image staticOverlay;
	public AudioSource move;

	[Header("shared scripts")]
	public timeScript timeScr;
	public whichNight nightScr;
	public officeScript_1_2_3 officeScr;
	public cameraScript_1_2_3 camScr;


	void Start () {
		
	}
	
	void setDifficulty()
    {
		if (nightScr._whichNight == 1)
		{
			freddyLevel = 0;
			bonnieLevel = 0;
			chicaLevel = 0;
			foxyLevel = 1;

		}
		if (nightScr._whichNight == 2)
		{
			freddyLevel = 0;
			bonnieLevel = 3;
			chicaLevel = 1;
			foxyLevel = 1;
		}
		if (nightScr._whichNight == 3)
		{
			freddyLevel = 1;
			bonnieLevel = 0;
			chicaLevel = 5;
			foxyLevel = 2;
		}
		if (nightScr._whichNight == 4)
		{
			//StartCoroutine(ossilateFreddyLevel());
			bonnieLevel = 2;
			chicaLevel = 4;
			foxyLevel = 6;
		}
		if (nightScr._whichNight == 5)
		{
			freddyLevel = 3;
			bonnieLevel = 5;
			chicaLevel = 7;
			foxyLevel = 5;
		}
		if (nightScr._whichNight == 6)
		{
			freddyLevel = 4;
			bonnieLevel = 10;
			chicaLevel = 12;
			foxyLevel = 6;
		}
		if (nightScr._whichNight == 7)
		{
			//PlayerPrefs.SetInt("CN_" + whichGame.ToString() + "_" + anniName[i].ToString() + ":", levels[i]);
			freddyLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "Freddy" + ":");
			bonnieLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "Bonnie" + ":");
			chicaLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "Chica" + ":");
			foxyLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "Foxy" + ":");

			toyFreddyLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "t_Freddy" + ":");
			toyBonnieLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "t_Bonnie" + ":");
			toyChicaLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "t_Chica" + ":");
			mangleLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "Mangle" + ":");
		}
	}

	IEnumerator startNight()
	{
		if (nightScr._whichNight == 1)
		{
			yield return new WaitForSeconds(timeScr.secondsPerHour * 2);
			setDifficulty();
			StartCoroutine(increaseDifficulty());
		}
		else
		{
			setDifficulty();
			StartCoroutine(increaseDifficulty());
		}
	}

	IEnumerator increaseDifficulty()
	{
		yield return new WaitForSeconds(timeScr.secondsPerHour);

		if (freddyLevel != 0)
			freddyLevel++;
		if (bonnieLevel != 0)
			bonnieLevel++;
		if (chicaLevel != 0)
			chicaLevel++;
		if (foxyLevel != 0)
			foxyLevel++;

		if (toyFreddyLevel != 0)
			toyFreddyLevel++;
		if (toyBonnieLevel != 0)
			toyBonnieLevel++;
		if (toyChicaLevel != 0)
			toyChicaLevel++;
		if (mangleLevel != 0)
			mangleLevel++;

		StartCoroutine(increaseDifficulty());
	}
}
