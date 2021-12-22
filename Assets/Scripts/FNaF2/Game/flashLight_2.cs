using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashLight_2 : MonoBehaviour {

	public Image _office;
	public Sprite _defaultOfficeSprite;
	public Sprite[] _officeSprites;
	public AudioSource _lightBuzz;

	[Header("for the buttons")]
	public Image _leftButton;
	public Image _rightButton;
	public Sprite[] _leftSprites;
	public Sprite[] _rightSprites;

	[Header("shared office script")]
	public officeScript_1_2_3 _officeScript;
	public mask_2 maskScript;
	public cameraScript_1_2_3 camScript;

	[Header("for the camera lights")]
	public Sprite[] camsLit;

	void leftLightOn()
    {
		_office.sprite = _officeSprites[0];
		_lightBuzz.Play();

		_leftButton.sprite = _leftSprites[1];
	}

	void middleLightOn()
    {
		_office.sprite = _officeSprites[1];
	}

	void rightLightOn()
    {
		_office.sprite = _officeSprites[2];
		_lightBuzz.Play();

		_rightButton.sprite = _rightSprites[1];
	}


	void lightOff()
    {
		_office.sprite = _defaultOfficeSprite;
		_lightBuzz.Pause();

		_leftButton.sprite = _leftSprites[0];
		_rightButton.sprite = _rightSprites[0];
    }

	void camLightOn()
    {
		for (int i = 0; i < camScript.cams.Length; i++)
        {
			camScript.cams[i] = camsLit[i];
			camScript.camScreenImg.sprite = camScript.cams[camScript.whichCam];
		}
    }

	void camLightOff()
    {
		for (int i = 0; i < camScript.cams.Length; i++)
		{
			camScript.cams[i] = camScript.camsBackup[i];
			camScript.camScreenImg.sprite = camScript.cams[camScript.whichCam];
		}
	}


	void useLight () {
		if ((Input.GetKeyDown(KeyCode.JoystickButton0)) || (Input.GetKeyDown(KeyCode.X)) && maskScript.isOn == false)
        {
			if (_officeScript.currentLimit == _officeScript.camLimit[1] && camScript.isOn == false)
			{
				Debug.Log("Left light on");
				leftLightOn();
			}
			else if (_officeScript.currentLimit == _officeScript.camLimit[0] && camScript.isOn == false)
			{
				Debug.Log("Right light on");
				rightLightOn();
			}
			else if ((_officeScript.currentLimit > _officeScript.camLimit[0] + 50) && (_officeScript.currentLimit < _officeScript.camLimit[1] - 50) && camScript.isOn == false)
			{
				Debug.Log("Middle light on");
				middleLightOn();
			}
			else if (camScript.isOn == true)
            {
				Debug.Log("Cam light on");
				camLightOn();
            }
		}
		else if ((Input.GetKeyUp(KeyCode.JoystickButton0)) || (Input.GetKeyUp(KeyCode.X)))
		{
			if (camScript.isOn == false)
            {
				lightOff();
			}
            else
            {
				lightOff();
				camLightOff();
			}
		}
	}
	
	void Update () {
		useLight();
	}
}
