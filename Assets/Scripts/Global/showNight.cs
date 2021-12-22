using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showNight : MonoBehaviour {

    public Text _nightText;
    public string _defaultNightText;
    public int _whichNight;
    public int _whichGame;
    public float _continueDelay;
    public string _defaultSceneName;

    [Header("FNaF3")]
    public bool _fnaf3;
    public Image _vhsFlash;
    public Image _clock;
    public Text _title;
    public Color _green;
    public Color _red;

	void Start () {
		if (PlayerPrefs.HasKey("save_game:" + _whichGame.ToString()))
        {
            _whichNight = PlayerPrefs.GetInt("save_game:" + _whichGame.ToString());
        }

        _nightText.text = _defaultNightText + _whichNight.ToString();

        if (_fnaf3)
        {
            _vhsFlash.color = _green;
            _clock.color = _green;

            if (_whichNight == 1)
            {
                _title.color = _green;
                _nightText.color = _green;
            }
            else
            {
                _title.color = _red;
                _nightText.color = _red;
            }
        }

        StartCoroutine(_showNight());
	}

    IEnumerator _showNight()
    {
        yield return new WaitForSeconds(_continueDelay);
        SceneManager.LoadSceneAsync(_defaultSceneName + _whichGame.ToString());
    }
}
