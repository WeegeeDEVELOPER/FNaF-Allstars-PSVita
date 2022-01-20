using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sixAm : MonoBehaviour {

	[Header("UI")]
	public Text sixAmText;
	public string prefix;
	public GameObject endingScreenObject;
	public Image endingScreen;
	public Sprite[] endingScreens;

	[Header("specialSaves")]
	public int selection;

	[Header("gameType")]
	public int whichGame;
	public bool saved = false;
	public bool doSkip = false;

	[Header("fnaf 1 only")]
	public GameObject scrollAnimation;

	[Header("fnaf 3 only")]
	public AudioClip goodEnding;

	[Header("fnaf 4 only")]
	public int loopedAmount;
	public int flickerAmount;
	public GameObject sixAmObject;

	[Header("sfx")]
	public AudioSource audioPlayer;
	public AudioSource specialAudioPlayer;
	public AudioClip[] sounds;
	public AudioClip endingSong;

	[Header("shared scripts")]
	public whichNight wNight;

	// Use this for initialization
	void Start () {
		Resources.UnloadUnusedAssets();

		StartCoroutine(sixAmAnim());
		StartCoroutine(sixAmSound());
	}

	IEnumerator sixAmSound()
    {
		audioPlayer.clip = sounds[0];
		audioPlayer.Play();

		yield return new WaitForSeconds(audioPlayer.clip.length - 3);

		if (sounds[1] != null)
        {
			specialAudioPlayer.clip = sounds[1];
			specialAudioPlayer.Play();

			yield return new WaitForSeconds(specialAudioPlayer.clip.length);
        }

		StartCoroutine(checkEnding());
	}

	IEnumerator sixAmAnim()
    {
		if (whichGame != 1)
        {
			scrollAnimation.SetActive(false);
        }
		
		if (whichGame == 2)
        {
			yield return new WaitForSeconds(3);

			sixAmText.text = "6" + prefix;
		}

		if (whichGame == 3)
        {
			yield return new WaitForSeconds(3);

			sixAmText.text = "6" + prefix;
		}

		if (whichGame == 4)
        {
			int loopLimit = 20;
			int flickerLimit = 10;


			if (loopedAmount <= loopLimit)
            {
				double randVal1;
				double randVal2;
				double randVal3;
				double randVal4;

				yield return new WaitForSeconds(0.2f);

				randVal1 = System.Math.Round(UnityEngine.Random.Range(0f, 6f));
				randVal2 = System.Math.Round(UnityEngine.Random.Range(0f, 6f));
				randVal3 = System.Math.Round(UnityEngine.Random.Range(0f, 6f));
				randVal4 = System.Math.Round(UnityEngine.Random.Range(0f, 6f));

				sixAmText.text = randVal1.ToString() + randVal2.ToString() + ":" + randVal3.ToString() + randVal4.ToString();

				loopedAmount++;

				StartCoroutine(sixAmAnim());
			}
            else
            {
				if (flickerAmount <= flickerLimit)
                {
					yield return new WaitForSeconds(0.4f);

					sixAmText.text = "06:00";

					sixAmObject.SetActive(false);

					yield return new WaitForSeconds(0.4f);

					sixAmObject.SetActive(true);

					flickerAmount++;

					StartCoroutine(sixAmAnim());
				}
			}
		}
    }

	IEnumerator checkEnding()
    {
		if (wNight._whichNight == 5)
        {
			endingScreenObject.SetActive(true);
			endingScreen.sprite = endingScreens[0];

			audioPlayer.clip = endingSong;
			audioPlayer.Play();

			yield return new WaitForSeconds(audioPlayer.clip.length);
        }
		else if (wNight._whichNight == 7 && (wNight._whichGame == 1 || wNight._whichGame == 2))
        {
			endingScreenObject.SetActive(true);
			endingScreen.sprite = endingScreens[1];

			audioPlayer.clip = endingSong;
			audioPlayer.Play();

			yield return new WaitForSeconds(audioPlayer.clip.length);
		}
		else if (wNight._whichNight == 6 && (wNight._whichGame == 3 || wNight._whichGame == 4))
        {
			endingScreenObject.SetActive(true);
			endingScreen.sprite = endingScreens[1];

			if (whichGame != 3)
				audioPlayer.clip = endingSong;
			else if (whichGame == 3)
				audioPlayer.clip = goodEnding;
			audioPlayer.Play();

			yield return new WaitForSeconds(audioPlayer.clip.length);
		}

		saveGame();
    }

	void saveGame()
    {
		if (wNight._whichNight == 5)
        {
			if (selection > 0)
            {
				if (PlayerPrefs.HasKey("gss_game:" + whichGame.ToString() + "_var:" + (2).ToString()))
				{
					PlayerPrefs.SetString("gss_game:" + whichGame.ToString() + "_var:" + (2).ToString(), "unlocked");
					PlayerPrefs.Save();
				}
			}
		}
		if (wNight._whichNight == 6)
        {
			if (selection > 1)
			{
				if (PlayerPrefs.HasKey("gss_game:" + whichGame.ToString() + "_var:" + (3).ToString()))
                {
					PlayerPrefs.SetString("gss_game:" + whichGame.ToString() + "_var:" + (3).ToString(), "unlocked");
					PlayerPrefs.Save();
				}
			}
		}

		if (wNight._whichNight < 5 && saved == false)
        {
			wNight._whichNight++;

			saved = true;
		}
		else if (wNight._whichNight == 5 || wNight._whichNight == 6 || wNight._whichNight == 7)
        {
			doSkip = true;
			wNight._whichNight = 5;
        }

		if (PlayerPrefs.HasKey("save_game:" + whichGame.ToString()))
		{
			PlayerPrefs.SetInt("save_game:" + whichGame.ToString(), wNight._whichNight);
			PlayerPrefs.Save();
		}

		if (wNight._whichNight <= 5 && doSkip == false)
        {
			if (wNight._whichGame != 4)
            {
				SceneManager.LoadSceneAsync("showNight_" + whichGame.ToString());
			}
            else
            {
				SceneManager.LoadSceneAsync("splashScreen_" + whichGame.ToString());
			}
		}
		else if (doSkip == true)
        {
			SceneManager.LoadSceneAsync("MainMenu_" + whichGame.ToString());
		}
	}
}
