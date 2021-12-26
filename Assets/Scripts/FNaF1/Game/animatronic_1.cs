using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animatronic_1 : MonoBehaviour {

	[Header("cam arrays")]
	public Sprite[] freddyLocations;
	public Sprite[] bonnieLocations;
	public Sprite[] chicaLocations;
	public Sprite[] foxyLocations;

	[Header("paths")]
	public int[] freddyPaths;
	public int[] bonniePath;
	public int[] chicaPaths;
	public int[] foxyPaths;

	[Header("positions")]
	public int freddyPos;
	public int bonniePos;
	public int chicaPos;
	public int foxyPos;

	[Header("annimatronic levels")]
	public int freddyLevel = 0;
	public int bonnieLevel = 0;
	public int chicaLevel = 0;
	public int foxyLevel = 0;

	[Header("fx")]
	public bool someoneMoved;
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
		StartCoroutine(startNight());
	}

	void setDifficulty()
    {
		if (nightScr._whichNight == 1)
        {
			freddyLevel = 0;
			bonnieLevel = 3;
			chicaLevel = 3;
			foxyLevel = 0;

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
			StartCoroutine(ossilateFreddyLevel());
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

		StartCoroutine(freddyLoop());
		StartCoroutine(mainLoop());
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

		StartCoroutine(increaseDifficulty());
    }

	IEnumerator ossilateFreddyLevel()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 1f));
		yield return new WaitForSeconds((float)rand);
		if (freddyLevel == 1)
			freddyLevel = 2;
		else
			freddyLevel = 1;
		StartCoroutine(ossilateFreddyLevel());
    }

	//loops
	IEnumerator freddyLoop()
    {
		yield return new WaitForSeconds(3);
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("freddy random number = " + rand);
		if (freddyLevel >= rand)
        {
			freddyPos++;
			someoneMoved = true;
			StartCoroutine(showLoopResultsInGame());
		}
		StartCoroutine(freddyLoop());
    }

	IEnumerator mainLoop()
    {
		yield return new WaitForSeconds(4);
		bonnieLoop();
		chicaLoop();
		foxyLoop();
		StartCoroutine(mainLoop());
	}

	void bonnieLoop()
	{
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("bonnie random number = " + rand);
		if (bonnieLevel >= rand)
		{
			bonniePos++;
			someoneMoved = true;
			StartCoroutine(showLoopResultsInGame());
		}
	}

	void chicaLoop()
	{
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("chica random number = " + rand);
		if (chicaLevel >= rand)
		{
			chicaPos++;
			someoneMoved = true;
			StartCoroutine(showLoopResultsInGame());
		}
	}

	void foxyLoop()
	{
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("foxy random number = " + rand);
		if (foxyLevel >= rand)
		{
			foxyPos++;
			someoneMoved = true;
			StartCoroutine(showLoopResultsInGame());
		}
	}

	IEnumerator showLoopResultsInGame()
    {
		if (someoneMoved)
        {
			staticOverlay.color = fxColor;
			move.Play();
			camScr.cams[bonniePath[bonniePos]] = bonnieLocations[bonniePos];
			camScr.switchCamera(camScr.whichCam);
			yield return new WaitForSeconds(3);
			staticOverlay.color = normalColor;

			someoneMoved = false;
		}
    }
}
