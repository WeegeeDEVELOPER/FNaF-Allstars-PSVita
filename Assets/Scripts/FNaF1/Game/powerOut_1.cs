using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class powerOut_1 : MonoBehaviour {

	public Animator freddy;
	public Image powerOutImage;
	public Sprite powerDownSprite;
	public AudioSource musicBox;
	public AudioSource fullPowerDown;

	// Use this for initialization
	void Start () {
		StartCoroutine(timer());
	}
	
	IEnumerator timer()
    {
		yield return new WaitForSeconds(3);
		freddy.enabled = true;
		musicBox.Play();
		yield return new WaitForSeconds(10);
		freddy.enabled = false;
		musicBox.Stop();
		fullPowerDown.Play();
		powerOutImage.sprite = powerDownSprite;
		yield return new WaitForSeconds(5);
		PlayerPrefs.SetInt("prev_jumpscare_game:1", 0);
		PlayerPrefs.Save();
		SceneManager.LoadSceneAsync("jumpScare_1");
	}
}
