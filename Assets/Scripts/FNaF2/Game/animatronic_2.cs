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

		if (!lit)
		{
			camScr.SaveCamArray();
		}

		//setStageImages();
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
	}

	IEnumerator showLoopResultsInGame()
	{

		//clear all frames
		for (int i = 0; i < camScr.cams.Length; i++)
		{
			camScr.cams[i] = camScr.camsBackup[i];
		}

		//setDoorImages();
		setStageImages();

		/*
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
		else if (freddyPos >= 5)
		{
			freddyPos = 5;
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
		else if (bonniePos >= 7)
		{
			bonniePos = 7;
			if (!hallWaySfxPlayer.isPlaying && bonnieAtDoor == false)
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
		else if (chicaPos >= 8)
		{
			chicaPos = 8;
			if (!hallWaySfxPlayer.isPlaying && chicaAtDoor == false)
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
		else if (foxyPos >= 3)
		{
			foxyPos = 3;
			if (nightScr._whichNight < 5)
			{
				camScr.cams[2] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + foxyLocations[3]);
			}
			else
			{
				camScr.cams[2] = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + foxyLocations[4]);
			}

			if (!foxyAtDoor)
			{
				StartCoroutine(foxyAttack());
			}
		}

		*/
		
		if (freddyMoved || bonnieMoved || chicaMoved || foxyMoved || toyFreddyMoved || toyChicaMoved || toyBonnieMoved || mangleMoved || bbMoved || marionetteMoved)
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

	void setStageImages()
	{
		/*
		if (nightScr._whichNight >= 6)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[5]);
			camScr.cams[0] = timelySprite;
		}
		*/

		
		if (toyBonniePos >= 1 && toyChicaPos <= 0)
		{
			Debug.Log("gfx/FNaF2/Game/Cameras/anni/" + stageCams[0]);
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[0]);
			camScr.cams[8] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCamsLit[0]);
			flashlightScr.camsLit[8] = timelySprite2;
		}
		else if (toyBonniePos >= 1 && toyChicaPos >= 1)
        {
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[1]);
			camScr.cams[8] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCamsLit[1]);
			flashlightScr.camsLit[8] = timelySprite2;
		}
		else if (toyBonniePos <= 0 && toyChicaPos >= 1)
		{
			toyChicaPos = 0;
		}
		else if (toyFreddyPos >= 1 && (toyChicaPos <= 0 || toyBonniePos <= 0))
		{
			toyFreddyPos = 0;
		}

		if (toyFreddyPos >= 1 && toyBonniePos >= 1 && toyChicaPos >= 1)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[2]);
			camScr.cams[8] = timelySprite;
			Sprite timelySprite2 = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCamsLit[2]);
			flashlightScr.camsLit[8] = timelySprite2;
		}
	}
}
