using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_1 : MonoBehaviour {

	[Header("for the buttons")]
	public Image _leftButton;
	public Image _rightButton;
	public Sprite[] _leftButtonSprites;
	public Sprite[] _rightButtonSprites;

	[Header("shared scripts")]
	public flashLight_1 _lightScript;
	public door_1 _doorScript;


	void Update () {

		if (_lightScript.status == "leftOn" && _doorScript.leftStatus == "leftClosed")
		{
			_leftButton.sprite = _leftButtonSprites[3];
		}
		else if (_lightScript.status == "leftOn")
		{
			_leftButton.sprite = _leftButtonSprites[2];
		}
		else if (_doorScript.leftStatus == "leftClosed")
		{
			_leftButton.sprite = _leftButtonSprites[1];
		}
		else
        {
			_leftButton.sprite = _leftButtonSprites[0];
		}

		if (_lightScript.status == "rightOn" && _doorScript.rightStatus == "rightClosed")
        {
			_rightButton.sprite = _rightButtonSprites[3];
        }
		else if (_lightScript.status == "rightOn")
		{
			_rightButton.sprite = _rightButtonSprites[2];
		}
		else if (_doorScript.rightStatus == "rightClosed")
		{
			_rightButton.sprite = _rightButtonSprites[1];
		}
		else
        {
			_rightButton.sprite = _rightButtonSprites[0];
        }
	}
}
