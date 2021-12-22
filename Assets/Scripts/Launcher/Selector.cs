using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour {

	[Header("For showing the game's icons")]
	public GameObject previous;
	public GameObject next;
	public Image[] _selections;
	public Sprite[] _icons;

	[Header("For showing the game's backgrounds")]
	public Image _backgroundImage;
	public Sprite[] _backgrounds;

	[Header("Selection information")]
	public Text _gameReleaseInfo;
	public string[] _gameReleasesInfo;
	public string[] gameSceneNames;
	public int whichGameSelected = 0;
	public Animation credits;
	public bool opened;
	public bool running = false;
	public bool achMenu;

	[Header("Flash effect")]
	public Color _flashColor;
	public Color _heavyFlashColor;
	public Color _normalColor;
	public Image _staticOverlay;
	public AudioSource _blip;
	public AudioSource _static;
	public AudioSource _music;

	void updateIcons()
    {
		if (whichGameSelected > 0)
        {
			_selections[0].sprite = _icons[whichGameSelected - 1];
		}
		_selections[1].sprite = _icons[whichGameSelected];
		if (whichGameSelected < _icons.Length - 1)
        {
			_selections[2].sprite = _icons[whichGameSelected + 1];
		}

		_backgroundImage.sprite = _backgrounds[whichGameSelected];

		_gameReleaseInfo.text = _gameReleasesInfo[whichGameSelected];
    }

	void launchGame()
    {
		SceneManager.LoadSceneAsync(gameSceneNames[whichGameSelected]);
	}

	IEnumerator openCredits()
    {
		running = true;

		if (!opened)
        {
			credits.Play("Credits_open");
        }
        else if (opened)
        {
			credits.Play("Credits_close");
		}

		yield return new WaitForSeconds(0.22f);

		if (!opened)
		{
			opened = true;
		}
		else if (opened)
		{
			opened = false;
		}

		running = false;
	}

	IEnumerator flash()
    {
		_blip.Play();
		_staticOverlay.color = _flashColor;
		yield return new WaitForSeconds(0.1f);
		_staticOverlay.color = _normalColor;
	}

	IEnumerator flashLaunch()
    {
		_blip.Play();
		_static.Play();
		_music.Pause();
		_staticOverlay.color = _heavyFlashColor;
		yield return new WaitForSeconds(1f);

		if(achMenu) SceneManager.LoadSceneAsync("Achievements");
		else launchGame();
	}

	void Update () {
		if (whichGameSelected == 0)
        {
			previous.SetActive(false);
        }
        else
        {
			previous.SetActive(true);
        }

		if (whichGameSelected == _icons.Length - 1)
        {
			next.SetActive(false);
        }
        else
        {
			next.SetActive(true);
        }

		if ((Input.GetKeyDown(KeyCode.JoystickButton11) && whichGameSelected > 0) || (Input.GetKeyDown(KeyCode.LeftArrow) && whichGameSelected > 0))
        {
			whichGameSelected--;
			StartCoroutine(flash());
		}
		else if ((Input.GetKeyDown(KeyCode.JoystickButton9) && whichGameSelected < _icons.Length - 1) || (Input.GetKeyDown(KeyCode.RightArrow) && whichGameSelected < _icons.Length - 1))
        {
			whichGameSelected++;
			StartCoroutine(flash());
        }

		if ((Input.GetKeyDown(KeyCode.JoystickButton0)) || (Input.GetKeyDown(KeyCode.X)))
		{
			StartCoroutine(flashLaunch());
		}

		if ((Input.GetKeyDown(KeyCode.JoystickButton3)) || (Input.GetKeyDown(KeyCode.I)))
		{
			achMenu = true;
			StartCoroutine(flashLaunch());
		}

		if ((Input.GetKeyDown(KeyCode.JoystickButton5)) || (Input.GetKeyDown(KeyCode.R)))
        {
			if (!running)
            {
				StartCoroutine(openCredits());
			}
        }

		if (whichGameSelected > _icons.Length - 1)
		{
			whichGameSelected = _icons.Length - 1;
		}
		else if (whichGameSelected < 0)
		{
			whichGameSelected = 0;
		}

		updateIcons();
	}
}
