using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class animatronic_2 : MonoBehaviour {

	[Header("Cam arrays")]
	public string[] stageCams;
	public string[] partsAndServiceCams;
	public string[] gameAreaCams;
	public string[] freddyLocations;
	public string[] bonnieLocations;
	public string[] chicaLocations;
	public string[] foxyLocations;
	public string[] toyFreddyLocations;
	public string[] toyBonnieLocations;
	public string[] toyChicaLocations;
	public string[] mangleLocations;
	public string[] bbLocations;
	public string[] marionetteLocations;

	[Header("Cam arrays lit")]
	public string[] stageCamsLit;
	public string[] partsAndServiceCamsLit;
	public string[] gameAreaCamsLit;
	public string[] freddyLocationsLit;
	public string[] bonnieLocationsLit;
	public string[] chicaLocationsLit;
	public string[] foxyLocationsLit;
	public string[] toyFreddyLocationsLit;
	public string[] toyBonnieLocationsLit;
	public string[] toyChicaLocationsLit;
	public string[] mangleLocationsLit;
	public string[] bbLocationsLit;
	public string[] marionetteLocationsLit;

	[Header("location types")]
	public string[] freddyLocationType;
	public string[] bonnieLocationType;
	public string[] chicaLocationType;
	public string[] foxyLocationType;
	public string[] toyFreddyLocationType;
	public string[] toyBonnieLocationType;
	public string[] toyChicaLocationType;
	public string[] mangleLocationType;
	public string[] bbLocationType;
	public string[] marionetteLocationType;

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
	public int marionettePos;

	[Header("annimatronic levels")]
	public int freddyLevel = 0;
	public int bonnieLevel = 0;
	public int chicaLevel = 0;
	public int foxyLevel = 0;
	public int toyFreddyLevel = 0;
	public int toyBonnieLevel = 0;
	public int toyChicaLevel = 0;
	public int mangleLevel = 0;
	public int bbLevel = 0;
	public int marionetteLevel = 0;

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
	public bool marionetteMoved;
	public Color fxColor;
	public Color normalColor;
	public Image staticOverlay;
	public AudioSource move;

	[Header("sfx")]
	public AudioSource hallwaySfxPlayer;
	public AudioSource walkSfxPlayer;
    public AudioSource ventWalkSfxPlayer;
	public AudioSource bbSfxPlayer;
	public AudioSource marionetteSfxPlayer;
	public AudioClip[] walkSfx;
	public AudioClip[] bbSfx;

	[Header("light information")]
	public bool lit = false;

	[Header("shared scripts")]
	public timeScript timeScr;
	public whichNight nightScr;
	public officeScript_1_2_3 officeScr;
	public cameraScript_1_2_3 camScr;
	public musicbox_2 musicBoxScr;
	public flashLight_2 flashlightScr;


	void Start () {
		StartCoroutine(startNight());
	}

	void Update()
    {
		if (flashlightScr.lightEnabled == true)
        {
			Debug.Log("lit");
			lit = true;
        }
        else
        {
			lit = false;
        }
	}
	
	void setDifficulty()
    {
		if (nightScr._whichNight == 1)
		{
			freddyLevel = 0;
			bonnieLevel = 0;
			chicaLevel = 0;
			foxyLevel = 1;

			toyFreddyLevel = 0;
			toyBonnieLevel = 0;
			toyChicaLevel = 0;
			mangleLevel = 0;
			bbLevel = 0;
		}
		if (nightScr._whichNight == 2)
		{
			freddyLevel = 0;
			bonnieLevel = 0;
			chicaLevel = 0;
			foxyLevel = 1;

			toyFreddyLevel = 2;
			toyBonnieLevel = 3;
			toyChicaLevel = 3;
			mangleLevel = 3;
			bbLevel = 3;
		}
		if (nightScr._whichNight == 3)
		{
			freddyLevel = 1;
			bonnieLevel = 1;
			chicaLevel = 1;
			foxyLevel = 2;

			toyFreddyLevel = 2;
			toyBonnieLevel = 1;
			toyChicaLevel = 1;
			mangleLevel = 0;
			bbLevel = 1;
		}
		if (nightScr._whichNight == 4)
		{
			freddyLevel = 4;
			bonnieLevel = 1;
			chicaLevel = 4;
			foxyLevel = 7;

			toyFreddyLevel = 0;
			toyBonnieLevel = 1;
			toyChicaLevel = 0;
			mangleLevel = 5;
			bbLevel = 3;
		}
		if (nightScr._whichNight == 5)
		{
			freddyLevel = 2;
			bonnieLevel = 2;
			chicaLevel = 2;
			foxyLevel = 5;

			toyFreddyLevel = 5;
			toyBonnieLevel = 2;
			toyChicaLevel = 0;
			mangleLevel = 1;
			bbLevel = 5;
		}
		if (nightScr._whichNight == 6)
		{
			freddyLevel = 5;
			bonnieLevel = 5;
			chicaLevel = 5;
			foxyLevel = 10;

			toyFreddyLevel = 4;
			toyBonnieLevel = 4;
			toyChicaLevel = 4;
			mangleLevel = 3;
			bbLevel = 5;
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
			bbLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "BalloonBoy" + ":");
			marionetteLevel = PlayerPrefs.GetInt("CN_" + nightScr._whichGame.ToString() + "_" + "Marionette" + ":");
		}

		StartCoroutine(mainLoop());
	}

	IEnumerator startNight()
	{
		if (nightScr._whichNight == 1)
		{
			yield return new WaitForSeconds(timeScr.secondsPerHour * 2);
			setDifficulty();

			toyBonnieLevel += 2;
			toyChicaLevel += 2;

			musicBoxScr.allowedToStart = true;
			StartCoroutine(increaseDifficulty());
		}
		else
		{
			setDifficulty();
			musicBoxScr.allowedToStart = true;
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
		if (bbLevel != 0)
			bbLevel++;
		if (marionetteLevel != 0)
        {
			marionetteLevel++;
			musicBoxScr.unwindDelay -= 0.1f;
		}

		StartCoroutine(increaseDifficulty());
	}

	IEnumerator mainLoop()
	{
		yield return new WaitForSeconds(5);
		freddyLoop();
		bonnieLoop();
		chicaLoop();
		foxyLoop();
		toyFreddyLoop();
		toyBonnieLoop();
		toyChicaLoop();
		mangleLoop();
		bbLoop();
		marionetteLoop();
		yield return new WaitForSeconds(3);
		StartCoroutine(mainLoop());
	}

	void freddyLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("freddy random number = " + rand);
		if (freddyLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			freddyMoved = true;
			freddyPos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void bonnieLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("bonnie random number = " + rand);
		if (bonnieLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			bonnieMoved = true;
			bonniePos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void chicaLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("chica random number = " + rand);
		if (chicaLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			chicaMoved = true;
			chicaPos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void foxyLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("foxy random number = " + rand);
		if (foxyLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			foxyMoved = true;
			foxyPos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void toyFreddyLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("toy freddy random number = " + rand);
		if (toyFreddyLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			toyFreddyMoved = true;
			toyFreddyPos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void toyBonnieLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("toy bonnie random number = " + rand);
		if (toyBonnieLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			toyBonnieMoved = true;
			toyBonniePos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void toyChicaLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("toy chica random number = " + rand);
		if (toyChicaLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			toyChicaMoved = true;
			toyChicaPos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void mangleLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("mangle random number = " + rand);
		if (mangleLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			mangleMoved = true;
			manglePos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void bbLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("balloon boy random number = " + rand);
		if (bbLevel >= rand)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			bbMoved = true;
			bbPos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
	}

	void marionetteLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("marionette random number = " + rand);

		if (musicBoxScr.spriteCounter == musicBoxScr.maxSprites)
        {
			marionetteLevel += 4;
        }

		if (marionetteLevel >= rand && musicBoxScr.spriteCounter == musicBoxScr.maxSprites)
		{
			/*
			if (bonniePos >= 1 && chicaPos >= 1 && camScr.isOn == false)
			{
				if (freddyAtDoor && doorScr.rightClosed == 0)
				{
					whichJumpscare = 0;
					startJumpscare(whichJumpscare);
				}
				else if (!freddyAtDoor)
				{
					if (rand >= 15)
						freddyPos += 2;
					else
						freddyPos++;
				}
				freddyMoved = true;
			}
			*/

			marionetteMoved = true;
			marionettePos++;
			StartCoroutine(showLoopResultsInGame());

			//StartCoroutine(showLoopResultsInGame());
		}
		else if (marionetteLevel >= rand && marionettePos > 0 && musicBoxScr.spriteCounter < musicBoxScr.maxSprites)
        {
			marionetteMoved = true;
			marionettePos--;
			StartCoroutine(showLoopResultsInGame());
		}
	}

	IEnumerator showLoopResultsInGame()
	{
		for (int i = 0; i < camScr.camsBackup.Length; i++)
		{
			camScr.cams[i] = camScr.camsBackup[i];
		}
		for (int i = 0; i < camScr.camsBackupLit.Length; i++)
        {
			flashlightScr.camsLit[i] = camScr.camsBackupLit[i];
		}

		bool stageMovement = setStageImages();
		bool pAsMovement = setPartsAndServiceImages();
		bool prizeCounterMovement = setPrizeCounterImages();
		bool balloonBoyMovement = setBalloonBoyImages();

        //---freddy---
        //-> hallway
        if (freddyPos == 1)
        {
            Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + freddyLocations[0]);
            camScr.cams[6] = timelySprite;
            Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + freddyLocationsLit[0]);
            flashlightScr.camsLit[6] = timelySprite2;
        }
        //-> party room 03
        else if (freddyPos == 2)
        {
            Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + freddyLocations[1]);
            camScr.cams[2] = timelySprite;
            Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + freddyLocationsLit[1]);
            flashlightScr.camsLit[2] = timelySprite2;
        }
        //-> office hallway close
        else if (freddyPos == 3)
        {
            //office sprite
        }
		//-> in office
		else if (freddyPos == 4)
		{
			//office sprite
		}

		//---bonnie---
		//-> hallway
		if (bonniePos == 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + bonnieLocations[0]);
			camScr.cams[6] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + bonnieLocationsLit[0]);
			flashlightScr.camsLit[6] = timelySprite2;
		}
		//-> office hallway far
		else if (bonniePos == 2)
        {
			//office sprite
		}
		//-> party room 01
		else if (bonniePos == 3)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + bonnieLocations[2]);
			camScr.cams[0] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + bonnieLocationsLit[2]);
			flashlightScr.camsLit[0] = timelySprite2;

			playVentAlarmAudio();
		}
		//-> vent
		else if (bonniePos == 4)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + bonnieLocations[3]);
			camScr.cams[4] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + bonnieLocationsLit[3]);
			flashlightScr.camsLit[4] = timelySprite2;
		}
		//-> in office vent
		else if (bonniePos == 5)
        {
			//office sprite
		}
		//-> in office
		else if (bonniePos == 6)
		{
			//office sprite
		}

		//---chica---
		//-> party room 04
		if (chicaPos == 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + chicaLocations[0]);
			camScr.cams[3] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + chicaLocationsLit[0]);
			flashlightScr.camsLit[3] = timelySprite2;
		}
		//-> party room 03
		else if (chicaPos == 2)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + chicaLocations[1]);
			camScr.cams[2] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + chicaLocationsLit[1]);
			flashlightScr.camsLit[2] = timelySprite2;

			playVentAlarmAudio();
		}
		//-> vent
		else if (chicaPos == 3)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + chicaLocations[2]);
			camScr.cams[5] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + chicaLocationsLit[2]);
			flashlightScr.camsLit[5] = timelySprite2;
		}
		//-> in office vent
		else if (chicaPos == 4)
		{
			//office sprite
		}
		//-> in office
		else if (chicaPos == 5)
        {
			//office sprite
		}

		//---toy freddy---
		//-> game area
		if (toyFreddyPos == 1)
        {
			if (bbPos < 1)
            {
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyFreddyLocations[0]);
				camScr.cams[9] = timelySprite;
				Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyFreddyLocationsLit[0]);
				flashlightScr.camsLit[9] = timelySprite2;
			}
            else
            {
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + gameAreaCams[1]);
				camScr.cams[9] = timelySprite;
				Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + gameAreaCamsLit[1]);
				flashlightScr.camsLit[9] = timelySprite2;
			}
		}
		//-> office hallway far
		else if (toyFreddyPos == 2)
        {
			//office sprite
		}
		//-> office hallway close
		else if (toyFreddyPos == 3)
        {
			//office sprite
		}
		//-> in office
		else if (toyFreddyPos == 4)
        {
			//office sprite
		}

		//---toy bonnie---
		//-> party room 03 or -> party room 04 (RNG based)
		if (toyBonniePos == 1)
        {
			double i = Random.Range(0, 50);

			if (i < 35)
            {
				//pr3
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/empty/" + toyBonnieLocations[0]);
				camScr.cams[2] = timelySprite;
				Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyBonnieLocationsLit[0]);
				flashlightScr.camsLit[2] = timelySprite2;
			}
            else
            {
				//pr4
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyBonnieLocations[3]);
				camScr.cams[3] = timelySprite;
				Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyBonnieLocationsLit[3]);
				flashlightScr.camsLit[3] = timelySprite2;
			}
			
		}
		//-> party room 02
		if (toyBonniePos == 2)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/empty/" + toyBonnieLocations[1]);
			camScr.cams[1] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyBonnieLocationsLit[1]);
			flashlightScr.camsLit[1] = timelySprite2;

			playVentAlarmAudio();
		}
		//-> vent
		if (toyBonniePos == 3)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/empty/" + toyBonnieLocations[2]);
			camScr.cams[5] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyBonnieLocationsLit[2]);
			flashlightScr.camsLit[5] = timelySprite2;
		}
		//-> in office vent
		if (toyBonniePos == 4)
		{
			//office sprite
		}
		//-> in office
		if (toyBonniePos == 5)
		{
			//office sprite
		}

		//---toy chica---
		//-> hallway
		if (toyChicaPos == 1)
        {
			//Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocations[0]);
			//camScr.cams[6] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocationsLit[0]);
			flashlightScr.camsLit[6] = timelySprite2;
		}
		//-> office hallway far
		if (toyChicaPos == 2)
		{
			//office sprite
		}
		//-> party room 04
		if (toyChicaPos == 3)
		{
			//Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocations[1]);
			//camScr.cams[3] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocationsLit[1]);
			flashlightScr.camsLit[3] = timelySprite2;
		}
		//-> office hallway close
		if (toyChicaPos == 4)
		{
			//office sprite
		}
		//-> party room 02
		if (toyChicaPos == 5)
		{
			//Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocations[2]);
			//camScr.cams[1] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocationsLit[2]);
			flashlightScr.camsLit[1] = timelySprite2;
		}
		//-> vent 
		if (toyChicaPos == 6)
		{
			//Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocations[3]);
			//camScr.cams[5] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + toyChicaLocationsLit[3]);
			flashlightScr.camsLit[5] = timelySprite2;
		}
		//-> in office vent 
		if (toyChicaPos == 7)
		{
			//office sprite
		}
		//-> in office
		if (toyChicaPos == 8)
		{
			//office sprite
		}

		//---balloon boy---
		//-> 
		//-> party room
		//-> vent
		//-> in office vent
		//-> in office

		if ((stageMovement == true || pAsMovement == true || prizeCounterMovement == true || balloonBoyMovement == true))
		{
			staticOverlay.color = fxColor;
			if (camScr.isOn)
			{
				move.Play();
			}
			camScr.switchCamera(camScr.whichCam);
			yield return new WaitForSeconds(2.5f);
			staticOverlay.color = normalColor;
		}
		

		Resources.UnloadUnusedAssets();

		if (freddyMoved)
			freddyMoved = false;
		if (bonnieMoved)
			bonnieMoved = false;
		if (chicaMoved)
			chicaMoved = false;
		if (foxyMoved)
			foxyMoved = false;

		if (toyFreddyMoved)
			toyFreddyMoved = false;
		if (toyBonnieMoved)
			toyBonnieMoved = false;
		if (toyChicaMoved)
			toyChicaMoved = false;
		if (mangleMoved)
			mangleMoved = false;
		if (bbMoved)
			bbMoved = false;
		if (marionetteMoved)
			marionetteMoved = false;
	}

	void playVentAlarmAudio()
    {
		if (hallwaySfxPlayer.isPlaying == false)
        {
			hallwaySfxPlayer.Play();
		}
    }
	void stopVentAlarmAudio()
    {
		hallwaySfxPlayer.Stop();
    }

	void playWalkAudio()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, walkSfx.Length - 1));
		walkSfxPlayer.clip = walkSfx[(int)rand];
		walkSfxPlayer.Play();
	}

	void playVentWalkAudio()
    {
		ventWalkSfxPlayer.Play();
	}

	void playBbAudio()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, bbSfx.Length - 1));
		bbSfxPlayer.clip = bbSfx[(int)rand];
		if (bbPos != 5)
		{
			bbSfxPlayer.volume = 0.1f;
		}
		else
		{
			bbSfxPlayer.volume = 1f;

		}
		bbSfxPlayer.Play();
	}

	void playMarionetteAudio()
    {
		marionetteSfxPlayer.Play();
    }

	bool setStageImages()
	{
		bool returnBool = false;

		if (toyBonniePos <= 0 && toyChicaPos >= 1)
		{
			toyChicaPos = 0;

			returnBool = false;
		}
		if (toyFreddyPos >= 1 && (toyChicaPos <= 0 || toyBonniePos <= 0))
		{
			toyFreddyPos = 0;

			returnBool = false;
		}


		if (toyBonniePos >= 1 && toyChicaPos <= 0)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[0]);
			camScr.cams[8] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCamsLit[0]);
			flashlightScr.camsLit[8] = timelySprite2;

			if ((toyFreddyMoved || toyBonnieMoved || toyChicaMoved))
				returnBool = true;
		}
		if (toyBonniePos >= 1 && toyChicaPos >= 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[1]);
			camScr.cams[8] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCamsLit[1]);
			flashlightScr.camsLit[8] = timelySprite2;

			if ((toyFreddyMoved || toyBonnieMoved || toyChicaMoved))
				returnBool = true;
		}

		if (toyFreddyPos >= 1 && toyBonniePos >= 1 && toyChicaPos >= 1)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[2]);
			camScr.cams[8] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCamsLit[2]);
			flashlightScr.camsLit[8] = timelySprite2;

			if ((toyFreddyMoved || toyBonnieMoved || toyChicaMoved))
				returnBool = true;
		}

		return returnBool;
	}

	bool setPartsAndServiceImages()
    {
		bool returnBool = false;

		if (bonniePos <= 0 && chicaPos >= 1)
		{
			chicaPos = 0;

			returnBool = false;
		}
		if (foxyPos >= 1 && (freddyPos <= 0 || chicaPos <= 0 || bonniePos <= 0))
		{
			foxyPos = 0;

			returnBool = false;
		}
		if (freddyPos >= 1 && (chicaPos <= 0 || bonniePos <= 0))
		{
			freddyPos = 0;

			returnBool = false;
		}

		if (bonniePos >= 1 && chicaPos <= 0)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCams[0]);
			camScr.cams[7] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCamsLit[0]);
			flashlightScr.camsLit[7] = timelySprite2;

			if ((freddyMoved || bonnieMoved || chicaMoved || foxyMoved))
				returnBool = true;
		}
		if (bonniePos >= 1 && chicaPos >= 1)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCams[0]);
			camScr.cams[7] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCamsLit[1]);
			flashlightScr.camsLit[7] = timelySprite2;

			if ((freddyMoved || bonnieMoved || chicaMoved || foxyMoved))
				returnBool = true;
		}

		if (freddyPos >= 1 && bonniePos >= 1 && chicaPos >= 1 && foxyPos <= 0)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCams[0]);
			camScr.cams[7] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCamsLit[2]);
			flashlightScr.camsLit[7] = timelySprite2;

			if ((freddyMoved || bonnieMoved || chicaMoved || foxyMoved))
				returnBool = true;
		}
		if (freddyPos >= 1 && bonniePos >= 1 && chicaPos >= 1 && foxyPos >= 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCams[0]);
			camScr.cams[7] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCamsLit[3]);
			flashlightScr.camsLit[7] = timelySprite2;

			if ((freddyMoved || bonnieMoved || chicaMoved || foxyMoved))
				returnBool = true;
		}
		if (freddyPos >= 1 && bonniePos >= 1 && chicaPos >= 1 && foxyPos >= 2)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCams[0]);
			camScr.cams[7] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + partsAndServiceCams[0]);
			flashlightScr.camsLit[7] = timelySprite2;

			if ((freddyMoved || bonnieMoved || chicaMoved || foxyMoved))
				returnBool = true;
		}

		return returnBool;
	}

	bool setPrizeCounterImages()
    {
		bool returnBool = false;

		if (marionettePos == 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + marionetteLocations[0]);
			camScr.cams[10] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + marionetteLocationsLit[0]);
			flashlightScr.camsLit[10] = timelySprite2;

			if (marionetteMoved)
				returnBool = true;
		}

		if (marionettePos == 2)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + marionetteLocations[0]);
			camScr.cams[10] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + marionetteLocationsLit[1]);
			flashlightScr.camsLit[10] = timelySprite2;
			
			if (marionetteMoved)
				returnBool = true;
		}

		if (marionettePos == 3)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + marionetteLocations[0]);
			camScr.cams[10] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + marionetteLocationsLit[2]);
			flashlightScr.camsLit[10] = timelySprite2;

			if (!marionetteSfxPlayer.isPlaying)
            {
				Button windButton = musicBoxScr.windButton.GetComponent<Button>();
				windButton.enabled = false;
				musicBoxScr.musicBox.enabled = false;

				playMarionetteAudio();

				StartCoroutine(startWaitingForMarionetteJumpscare());
			}

			if (marionetteMoved)
				returnBool = true;
		}

		return returnBool;
	}

    bool setBalloonBoyImages()
    {
		bool returnBool = false;

		if (bbPos >= 1)
        {
			if (freddyPos > 1 || freddyPos == 0)
            {
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + gameAreaCams[0]);
				camScr.cams[9] = timelySprite;
				Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + gameAreaCamsLit[0]);
				flashlightScr.camsLit[9] = timelySprite2;
			}
            else
            {
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + gameAreaCams[1]);
				camScr.cams[9] = timelySprite;
				Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + gameAreaCamsLit[1]);
				flashlightScr.camsLit[9] = timelySprite2;
			}

            if (bbMoved)
            {
				returnBool = true;
				int i = Random.Range(0, bbSfx.Length);
				playBbAudio();

			}
				
		}

		return returnBool;
    }

	IEnumerator startWaitingForMarionetteJumpscare()
    {
		yield return new WaitForSeconds(Random.Range(10, 20));
		whichJumpscare = 4;
		startJumpscare(whichJumpscare);
	}

	void startJumpscare(int jumpscareID)
	{
		if (camScr.isOn == true)
        {
			camScr.cam();
        }

		PlayerPrefs.SetInt("prev_jumpscare_game:" + nightScr._whichGame.ToString(), jumpscareID);
		PlayerPrefs.Save();

		SceneManager.LoadSceneAsync("jumpScare_" + nightScr._whichGame.ToString(), LoadSceneMode.Additive);

	}
}
