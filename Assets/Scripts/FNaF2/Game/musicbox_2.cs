using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicbox_2 : MonoBehaviour {

	[Header("booleans")]
	public bool allowedToStart = false;
	public bool started = false;

	[Header("audiosources")]
	public AudioSource musicBox;

	[Header("paths")]
	public string musicBoxSpritePath;

	[Header("UI related")]
	public Image winderLevel;
	public GameObject windButton;

	[Header("scripts")]
	public animatronic_2 ani2Script;
	public cameraScript_1_2_3 camScript;

	[Header("numbers")]
	public float unwindDelay;
	public int spriteCounter = 1;
	public int maxSprites = 21;
	
	// Update is called once per frame

	void Start()
    {
		musicBox.Play();
		musicBox.volume = 0;
	}

	void Update () {
		if (allowedToStart && !started)
        {
			StartCoroutine(unwindbox(unwindDelay));
			started = true;
		}
		doMusicBox();
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

		StartCoroutine(unwindbox(unwindDelay));
	}

	public void doMusicBox()
	{
		if (camScript.isOn)
		{

			//audio part
			if (camScript.specialProperty[camScript.whichCam] == "musicbox")
			{
				musicBox.volume = 1;

				windButton.SetActive(true);
			}
			else
			{
				if (musicBox != null)
				{
					musicBox.volume = 0;
				}

				windButton.SetActive(false);
			}
		}
		else if (!camScript.isOn)
		{
			if (musicBox.isPlaying == true)
			{
				musicBox.volume = 0;
			}

			windButton.SetActive(false);
		}
	}
}
