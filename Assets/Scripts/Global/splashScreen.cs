using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour {

	[Header("save system")]
	public int _whichNight;
	public int _whichGame;

	[Header("main")]
	public float _continueDelay;
	public string _mainSceneName;

	void Start () {
		getData();
		StartCoroutine(showSplash());
	}

	void getData()
    {
		if (PlayerPrefs.HasKey("save_game:" + _whichGame.ToString()))
        {
			_whichNight = PlayerPrefs.GetInt("save_game:" + _whichGame.ToString());
        }
    }

	IEnumerator showSplash()
    {
		yield return new WaitForSeconds(_continueDelay);
		SceneManager.LoadSceneAsync(_mainSceneName + _whichGame.ToString());
    }
}
