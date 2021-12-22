using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whichNight : MonoBehaviour {

	public int _whichNight;
	public int _whichGame;

	void Awake () {
		if (PlayerPrefs.HasKey("save_game:" + _whichGame.ToString()))
		{
			_whichNight = PlayerPrefs.GetInt("save_game:" + _whichGame.ToString());
		}
	}
	
}
