using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class staticScene : MonoBehaviour {

	public float duration = 10;
	public Image staticImage;
	public Color staticColor;
	public int whichGame;

	// Use this for initialization
	void Start () {
		StartCoroutine(staticTimer());
	}
	
	IEnumerator staticTimer()
    {
		staticImage.color = staticColor;

		yield return new WaitForSeconds(duration);

		SceneManager.LoadSceneAsync("MainMenu_" + whichGame.ToString());
    }
}
