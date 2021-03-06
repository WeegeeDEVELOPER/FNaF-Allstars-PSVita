using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		if (bbLevel != 0)
			bbLevel++;
		if (marionetteLevel != 0)
			marionetteLevel++;

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
			StartCoroutine(showLoopResultsInGame());
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
			StartCoroutine(showLoopResultsInGame());
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
			StartCoroutine(showLoopResultsInGame());
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
			StartCoroutine(showLoopResultsInGame());
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
			StartCoroutine(showLoopResultsInGame());
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
			StartCoroutine(showLoopResultsInGame());
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
			StartCoroutine(showLoopResultsInGame());
		}
	}

	void marionetteLoop()
    {
		double rand = System.Math.Round(UnityEngine.Random.Range(0f, 20f));
		rand++;
		Debug.Log("marionette random number = " + rand);
		if (marionetteLevel >= rand)
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
			StartCoroutine(showLoopResultsInGame());
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
			yield return new WaitForSeconds(3);
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
		if (nightScr._whichNight >= 6)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF1/Game/Cameras/anni/" + stageCams[5]);
			camScr.cams[0] = timelySprite;
		}

		if (toyBonniePos >= 1 && toyChicaPos <= 0)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[0]);
			camScr.cams[0] = timelySprite;
		}
		else if (toyBonniePos <= 0 && toyChicaPos >= 1)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[1]);
			camScr.cams[0] = timelySprite;
		}

		if (toyFreddyPos <= 0 && toyBonniePos >= 1 && toyChicaPos >= 1)
		{
			if (nightScr._whichNight < 5)
			{
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[2]);
				camScr.cams[0] = timelySprite;
			}
			else
			{
				Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[3]);
				camScr.cams[0] = timelySprite;
			}
		}

		if (toyFreddyPos >= 1 && toyBonniePos >= 1 && toyChicaPos >= 1)
		{
			Sprite timelySprite = Resources.Load<Sprite>("gfx/FNaF2/Game/Cameras/anni/" + stageCams[4]);
			camScr.cams[0] = timelySprite;
		}
	}
}
