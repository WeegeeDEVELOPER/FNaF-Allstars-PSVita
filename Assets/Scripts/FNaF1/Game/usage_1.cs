using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class usage_1 : MonoBehaviour {

	public Image _usageImage;
	public Sprite[] _usageSprites;
	public int _whichUsage;

	[Header("shared scripts")]
	public door_1 _doorScript;
	public flashLight_1 _lightScript;
	public button_1 _buttonScript;

	
	void Update () {
		_whichUsage = _lightScript.lightOn + _doorScript.leftClosed + _doorScript.rightClosed;
		_usageImage.sprite = _usageSprites[_whichUsage];
	}
}
