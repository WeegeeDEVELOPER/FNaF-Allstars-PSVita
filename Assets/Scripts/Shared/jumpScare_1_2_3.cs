using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jumpScare_1_2_3 : MonoBehaviour {

	public Image jumpscareImage;
	public Animator jumpScares;
	public int whichJumpscare;
	public int whichGame;
	public AudioSource jumpscareSound;

	// Use this for initialization
	void Start () {
		Resources.UnloadUnusedAssets();
		whichJumpscare = PlayerPrefs.GetInt("prev_jumpscare_game:" + whichGame.ToString());
		jumpScares.SetTrigger(whichJumpscare.ToString());

		StartCoroutine(jumpScareTimer());
	}

	IEnumerator jumpScareTimer()
    {
		if (whichGame != 2 && whichGame != 3 && whichGame != 4)
        {
			yield return new WaitForSeconds(1.5f);
		}
        else
        {
			yield return new WaitForSeconds(0.34f);
		}

		SceneManager.LoadSceneAsync("static_" + whichGame.ToString());
    }
}
