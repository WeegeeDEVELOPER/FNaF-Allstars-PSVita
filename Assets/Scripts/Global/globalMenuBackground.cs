using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class globalMenuBackground : MonoBehaviour {

	public float _changeTime = 2f;
	public double _whichBackground = 0;
	public int _whichBackgroundOut = 0;
	public Image _background;
	public Sprite[] _randomBackgrounds;

	void Start () {
		StartCoroutine(randombackground());
	}
	
	IEnumerator randombackground()
    {
		_whichBackground = System.Math.Round(UnityEngine.Random.Range(0f, _randomBackgrounds.Length - 1));
		_whichBackgroundOut = (int)_whichBackground;

		yield return new WaitForSeconds(_changeTime);

		_background.sprite = _randomBackgrounds[_whichBackgroundOut];

		yield return new WaitForSeconds(0.1f);

		_background.sprite = _randomBackgrounds[0];

		StartCoroutine(randombackground());
    }
}
