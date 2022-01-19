using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class animatronic_1 : MonoBehaviour {

	[Header("cam arrays")]
	public string[] stageCams;
	public string[] freddyLocations;
	public string[] bonnieLocations;
	public string[] chicaLocations;
	public string[] foxyLocations;

	[Header("paths")]
	//public int[] freddyPaths;
	//public int[] bonniePath;
	//public int[] chicaPaths;
	//public int[] foxyPaths;

	[Header("positions")]
	public int freddyPos;
	public int bonniePos;
	public int chicaPos;
	public int foxyPos;
	public bool freddyAtDoor;
	public bool bonnieAtDoor;
	public bool chicaAtDoor;
	public bool foxyAtDoor;
	public bool foxyRunning;
	public bool chicaInKitchen;

	[Header("annimatronic levels")]
	public int freddyLevel = 0;
	public int bonnieLevel = 0;
	public int chicaLevel = 0;
	public int foxyLevel = 0;

	[Header("fx")]
	public bool freddyMoved;
	public bool bonnieMoved;
	public bool chicaMoved;
	public bool foxyMoved;
	public Color fxColor;
	public Color normalColor;
	public Image staticOverlay;
	public AudioSource move;

	[Header("sfx")]
	public AudioClip[] freddySfx;
	public AudioClip[] kitchenSfx;
	public AudioClip[] hallwaySfx;
	public AudioClip foxyRunSfx;
	public AudioSource freddySfxPlayer;
	public AudioSource kitchenSfxPlayer;
	public AudioSource hallWaySfxPlayer;
	public int[] playKitchenSfx;
	public int[] playHallwaySfx;

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
		yield return new WaitForSeconds(4);
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("freddy random number = " + rand);
		if (freddyLevel >= rand)
        {
			if (bonniePos >= 1 && chicaPos >= 1)
            {
				if (rand >= 15)
					freddyPos += 2;
				else
					freddyPos++;


				freddyMoved = true;
			}
			StartCoroutine(showLoopResultsInGame());
		}
		StartCoroutine(freddyLoop());
    }

	IEnumerator mainLoop()
    {
		yield return new WaitForSeconds(5);
		bonnieLoop();
		chicaLoop();
		foxyLoop();
		yield return new WaitForSeconds(3);
		StartCoroutine(mainLoop());
	}

	void bonnieLoop()
	{
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("bonnie random number = " + rand);
		if (bonnieLevel >= rand)
		{
			if (rand >= 15)
				bonniePos += 2;
			else
				bonniePos++;

			bonnieMoved = true;
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
			if (!chicaInKitchen)
            {
				if (rand >= 15)
					chicaPos += 2;
				else
					chicaPos++;
			}

			chicaMoved = true;
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
			if (!camScr.isOn && !foxyRunning)
            {
				foxyPos++;

				foxyMoved = true;
			}
			StartCoroutine(showLoopResultsInGame());
		}
	}

	void playFreddyLaugh()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, freddySfx.Length - 1));
		freddySfxPlayer.clip = freddySfx[(int)rand];
		freddySfxPlayer.Play();
    }

	void playKitchenAudio()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, kitchenSfx.Length - 1));
		kitchenSfxPlayer.clip = kitchenSfx[(int)rand];
		kitchenSfxPlayer.Play();
    }

	void playWalkAudio()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, hallwaySfx.Length - 1));
		hallWaySfxPlayer.clip = hallwaySfx[(int)rand];
		hallWaySfxPlayer.Play();
	}

	void setDoorImages()
    {
		/*
		if (freddyPos > freddyPaths.Length)
			freddyAtDoor = true;
		if (bonniePos > bonniePath.Length)
			bonnieAtDoor = true;
		if (chicaPos > chicaPaths.Length)
			chicaAtDoor = true;
		if (foxyPos > foxyPaths.Length)
			foxyAtDoor = true;
		*/
    }

	void setStageImages()
    {
		if (nightScr._whichNight >= 6)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + stageCams[6]);
			camScr.cams[0] = timelySprite;
		}

		if (bonniePos >= 1 && chicaPos <= 0)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + stageCams[0]);
			camScr.cams[0] = timelySprite;
		}
		else if (bonniePos <= 0 && chicaPos >= 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + stageCams[1]);
			camScr.cams[0] = timelySprite;
		}

		if (freddyPos <= 0 && bonniePos >= 1 && chicaPos >= 1)
		{
			if (nightScr._whichNight < 5)
            {
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + stageCams[2]);
				camScr.cams[0] = timelySprite;
			}
            else
            {
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + stageCams[3]);
				camScr.cams[0] = timelySprite;
			}
		}

		if (freddyPos >= 1 && bonniePos >= 1 && chicaPos >= 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + stageCams[4]);
			camScr.cams[0] = timelySprite;
		}
	}

	IEnumerator showLoopResultsInGame()
    {

		//clear all frames
		for (int i = 0; i < camScr.cams.Length; i++)
		{
			camScr.cams[i] = camScr.camsBackup[i];
		}

		setDoorImages();
		setStageImages();

		if (freddyMoved)
		{
			playFreddyLaugh();
		}

		//freddy
		if (freddyPos == 1)
		{
			camScr.cams[1] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + freddyLocations[1]);
		}
		else if (freddyPos == 2)
		{
			camScr.cams[10] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + freddyLocations[2]);
		}
		else if (freddyPos == 3)
		{
			camScr.cams[6] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + freddyLocations[3]);
		}
		else if (freddyPos == 4)
		{
			camScr.cams[7] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + freddyLocations[4]);
		}
		else if (freddyPos == 5)
		{
			freddyAtDoor = true;
		}

		//bonnie
		if (bonniePos == 1)
		{
			camScr.cams[1] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + bonnieLocations[1]);
		}
		else if (bonniePos == 2)
		{
			camScr.cams[1] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + bonnieLocations[2]);
		}
		else if (bonniePos == 3)
		{
			if (nightScr._whichNight >= 2 && nightScr._whichNight < 5)
			{
				camScr.cams[8] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + bonnieLocations[6]);
			}
			else if (nightScr._whichNight >= 5)
			{
				camScr.cams[8] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + bonnieLocations[7]);
			}
			else
			{
				bonniePos = 4;
			}
		}
		else if (bonniePos == 4)
		{
			camScr.cams[3] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + bonnieLocations[3]);
		}
		else if (bonniePos == 5)
		{
			camScr.cams[5] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + bonnieLocations[5]);
		}
		else if (bonniePos == 6)
		{
			camScr.cams[4] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + bonnieLocations[4]);
		}
		else if (bonniePos == 7)
        {
			if (!hallWaySfxPlayer.isPlaying)
				playWalkAudio();
			bonnieAtDoor = true;
        }

		//chica
		if (chicaPos == 1)
        {
			camScr.cams[1] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + chicaLocations[1]);
		}
		else if (chicaPos == 2)
        {
			camScr.cams[1] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + chicaLocations[2]);
		}
		else if (chicaPos == 3)
        {
			if (nightScr._whichNight <= 3)
            {
				camScr.cams[10] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + chicaLocations[6]);
			}
            else
            {
				chicaPos = 5;
            }
        }
		else if (chicaPos == 4)
        {
			double randChoice = System.Math.Round(UnityEngine.Random.Range(0f, 1f));
			if (randChoice == 0)
            {
				camScr.cams[10] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + chicaLocations[7]);
			}
            else
            {
				StartCoroutine(chicaKitchen());
            }
			
		}
		else if (chicaPos == 5)
        {
			camScr.cams[6] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + chicaLocations[3]);
		}
		else if (chicaPos == 6)
		{
			camScr.cams[6] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + chicaLocations[4]);
		}
		else if (chicaPos == 7)
		{
			camScr.cams[7] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + chicaLocations[5]);
		}
		else if (chicaPos == 8)
        {
			if (!hallWaySfxPlayer.isPlaying)
				playWalkAudio();
			chicaAtDoor = true;
        }

		if (foxyPos == 1)
        {
			camScr.cams[2] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + foxyLocations[1]);
		}
        else if (foxyPos == 2)
        {
			camScr.cams[2] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + foxyLocations[2]);
		}
		else if (foxyPos == 3)
		{
			if (nightScr._whichNight < 5)
            {
				camScr.cams[2] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + foxyLocations[3]);
			}
            else
            {
				camScr.cams[2] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + foxyLocations[4]);
			}

			StartCoroutine(foxyAttack());
		}

		Resources.UnloadUnusedAssets();


		if (freddyMoved || bonnieMoved || chicaMoved || foxyMoved)
		{
			staticOverlay.color = fxColor;
			if (camScr.isOn)
            {
				move.Play();
				camScr.switchCamera(camScr.whichCam);
			}
			yield return new WaitForSeconds(3);
			staticOverlay.color = normalColor;
		}

		if (freddyMoved)
			freddyMoved = false;
		if (bonnieMoved)
			bonnieMoved = false;
		if (chicaMoved)
			chicaMoved = false;
		if (foxyMoved)
			foxyMoved = false;
			
	}

	IEnumerator foxyAttack()
    {
		hallWaySfxPlayer.clip = foxyRunSfx;

		yield return new WaitForSeconds(2f);
    }

	IEnumerator chicaKitchen()
    {
		chicaInKitchen = true;

		playKitchenAudio();

		yield return new WaitForSeconds(kitchenSfxPlayer.clip.length);

		chicaInKitchen = false;

		chicaPos = 5;
    }
}