using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashLight_1 : MonoBehaviour {

	public Image _office;
	public Sprite _defaultOfficeSprite;
	public Sprite[] _otherOfficeSprites;
	public AudioSource _lightBuzz;
	public string status = "NaN";

	[Header("stats")]
	public int lightOn;

	[Header("for the buttons")]
	public button_1 b1;

	[Header("scripts")]
	public officeScript_1_2_3 _officeScript;
	public cameraScript_1_2_3 camScript;

	void leftLightOn()
    {
		_office.sprite = _otherOfficeSprites[0];
		_lightBuzz.Play();
		lightOn = 1;

		status = "leftOn";
	}

	void rightLightOn()
    {
		_office.sprite = _otherOfficeSprites[1];
		_lightBuzz.Play();
		lightOn = 1;

		status = "rightOn";
	}

	void lightOff()
    {
		_lightBuzz.Pause();
		_office.sprite = _defaultOfficeSprite;
		lightOn = 0;

		status = "NaN";
	}

	void useLight()
    {
		if ((Input.GetKeyDown(KeyCode.JoystickButton0)) || (Input.GetKeyDown(KeyCode.X)) && (camScript.isOn == false && camScript.status == "nothing"))
		{
			if (_officeScript.currentLimit == _officeScript.camLimit[1])
			{
				Debug.Log("Left light on");
				leftLightOn();
			}
			else if (_officeScript.currentLimit == _officeScript.camLimit[0])
			{
				Debug.Log("Right light on");
				rightLightOn();
			}
		}
		else if ((Input.GetKeyUp(KeyCode.JoystickButton0)) || (Input.GetKeyUp(KeyCode.X)))
		{
			lightOff();
		}
	}

	void Update () {
		useLight();
	}
}
