using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuSelection : MonoBehaviour {

	public Text[] _options;
	public string[] _defaultOptions;
	public string[] _states;
	public string blankCursor;
	public string cursor;
	public string endCursor;
	public int whichNight;
	public int _whichOption = 0;
	public int _gameType;
	public int _extraOptionsAmount;
	public Color locked;
	public Color unlocked;

	[Header("splash")]
	public bool _fnaf4;
	public float _fadeDuration = 2;
	public globalMenuBackground _gmbg;
	public Animator _staticOverlayAnim;
	public Animation _splashFadeAnim;

	[Header("exit")]
	public Image _staticOverlay;
	public Color _flashExitColor;
	public AudioSource _static;
	public AudioSource _mainMusic;

	void Start()
    {
		getStates();
    }

	void getStates()
    {
		whichNight = 1;

		if (!PlayerPrefs.HasKey("save_game:" + _gameType.ToString()))
        {
			PlayerPrefs.SetInt("save_game:" + _gameType.ToString(), whichNight);
        }

		_states[0] = "unlocked";
		_states[1] = "unlocked";
		if (_extraOptionsAmount > 2)
        {
			_states[2] = "locked";
		}
		if (_extraOptionsAmount > 3)
        {
			_states[3] = "locked";
		}
		

		for (int i=0; i<_states.Length; i++)
        {
			if (!PlayerPrefs.HasKey("gss_game:" + _gameType.ToString() + "_var:" + i.ToString()))
			{
				PlayerPrefs.SetString("gss_game:" + _gameType.ToString() + "_var:" + i.ToString(), _states[i]);
			}
		}

		PlayerPrefs.Save();

		_states[0] = PlayerPrefs.GetString("gss_game:" + _gameType.ToString() + "_var:" + (0).ToString());
		_states[1] = PlayerPrefs.GetString("gss_game:" + _gameType.ToString() + "_var:" + (1).ToString());
		if (_extraOptionsAmount > 2)
		{
			_states[2] = PlayerPrefs.GetString("gss_game:" + _gameType.ToString() + "_var:" + (2).ToString());
		}
		if (_extraOptionsAmount > 3)
		{
			_states[3] = PlayerPrefs.GetString("gss_game:" + _gameType.ToString() + "_var:" + (3).ToString());
		}

		whichNight = PlayerPrefs.GetInt("save_game:" + _gameType.ToString());
	}

	void updateOptions()
    {
		for (int i=0; i<_defaultOptions.Length; i++)
        {
			_options[i].text = blankCursor + _defaultOptions[i];
        }
		
		if (_whichOption == 1)
        {
			_options[_whichOption].text = cursor + _defaultOptions[_whichOption] + " " + whichNight.ToString() + endCursor;
		}
        else
        {
			_options[_whichOption].text = cursor + _defaultOptions[_whichOption] + endCursor;
		}
    }

	void updateColor()
    {
		if (_extraOptionsAmount > 2)
        {
			if (_states[2] == "unlocked")
			{
				_options[2].color = unlocked;
			}
			else
			{
				_options[2].color = locked;
			}
		}

		if (_extraOptionsAmount > 3)
        {
			if (_states[3] == "unlocked")
			{
				_options[3].color = unlocked;
			}
			else
			{
				_options[3].color = locked;
			}
		}
	}

	void updateCursor()
    {
		if (_extraOptionsAmount > 2 && _states[2] == "locked")
		{
			if (_whichOption > 1)
			{
				_whichOption = 1;
			}
		}
		if (_extraOptionsAmount > 3 && _states[3] == "locked")
		{
			if (_whichOption > 2)
			{
				_whichOption = 2;
			}
		}
	}

	void closeGame()
    {
		Resources.UnloadUnusedAssets();
		SceneManager.LoadSceneAsync("Launcher");
	}

	IEnumerator flashClose()
    {
		_static.Play();
		_mainMusic.Pause();
		_staticOverlay.color = _flashExitColor;
		yield return new WaitForSeconds(1f);
		closeGame();
	}

	IEnumerator loadGame()
    {
		if (!_fnaf4)
        {
			StartCoroutine(lowerMusicVolume());

			_gmbg.StopAllCoroutines();
			_staticOverlayAnim.enabled = false;
			_splashFadeAnim.Play("splashFade");
			//_mainMusic.Pause();

			yield return new WaitForSeconds(_fadeDuration);
		}
		else if (_fnaf4)
        {
			_mainMusic.Pause();
		}

		if (_whichOption == 0)
		{
			whichNight = 1;
			PlayerPrefs.SetInt("save_game:" + _gameType.ToString(), whichNight);
			PlayerPrefs.Save();
			SceneManager.LoadSceneAsync("splashScreen_" + _gameType.ToString());
			Debug.Log("reset + new game");
		}

		if (_whichOption == 1 && whichNight < 2)
		{
			SceneManager.LoadSceneAsync("splashScreen_" + _gameType.ToString());
			Debug.Log("new game");
		}
		else
		{
			Debug.Log("continue game");
		}

		if (_whichOption == 2)
		{
			Debug.Log("extra night");
		}

		if (_whichOption == 3)
		{
			Debug.Log("custom night...");
		}
	}

	IEnumerator lowerMusicVolume()
    {
		_mainMusic.volume -= 0.025f;
		yield return new WaitForSeconds(0.1f);
		StartCoroutine(lowerMusicVolume());
    }

	void Update () {
		if ((Input.GetKeyDown(KeyCode.JoystickButton8) && _whichOption > 0) || (Input.GetKeyDown(KeyCode.UpArrow) && _whichOption > 0))
        {
			_whichOption--;
        }
		else if ((Input.GetKeyDown(KeyCode.JoystickButton10) && _whichOption < _options.Length - 1) || (Input.GetKeyDown(KeyCode.DownArrow) && _whichOption < _options.Length - 1))
        {
			_whichOption++;
        }

		if ((Input.GetKeyDown(KeyCode.JoystickButton0)) || (Input.GetKeyDown(KeyCode.X)))
		{
			StartCoroutine(loadGame());
		}

		if ((Input.GetKeyDown(KeyCode.JoystickButton3)) || (Input.GetKeyDown(KeyCode.Z)))
        {
			StartCoroutine(flashClose());
        }

		updateCursor();
		updateOptions();
		updateColor();
	}
}
