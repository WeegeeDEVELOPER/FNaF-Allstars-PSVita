using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door_1 : MonoBehaviour {

	public Animator _leftDoor;
	public Animator _rightDoor;
	public float _animTime = 0.2f;
	public string _animStatus = "nothing";
	public string leftStatus = "NaN";
	public string rightStatus = "NaN";
	public AudioSource sfx;

	[Header("stats")]
	public int leftClosed;
	public int rightClosed;

	[Header("shared scripts")]
	public officeScript_1_2_3 _officeScript;
	public cameraScript_1_2_3 camScript;

	// Use this for initialization
	void Start () {
		
	}

	IEnumerator closeLeft()
    {
		if (_animStatus == "animating")
        {
			yield break;
        }
        else
        {
			_animStatus = "animating";
			_leftDoor.SetTrigger("doorLeftClose");
			sfx.Play();
			yield return new WaitForSeconds(_animTime);
			leftStatus = "leftClosed";
			leftClosed = 1;
			_animStatus = "nothing";
			yield break;
		}
    }

	IEnumerator closeRight()
    {
		if (_animStatus == "animating")
		{
			yield break;
		}
        else
        {
			_animStatus = "animating";
			_rightDoor.SetTrigger("doorRightClose");
			sfx.Play();
			yield return new WaitForSeconds(_animTime);
			rightStatus = "rightClosed";
			rightClosed = 1;
			_animStatus = "nothing";
			yield break;
		}
	}

	IEnumerator openLeft()
    {
		if (_animStatus == "animating")
		{
			yield break;
        }
        else
        {
			_animStatus = "animating";
			_leftDoor.SetTrigger("doorLeftOpen");
			sfx.Play();
			yield return new WaitForSeconds(_animTime);
			leftStatus = "NaN";
			leftClosed = 0;
			_animStatus = "nothing";
			yield break;
		}
	}

	IEnumerator openRight()
    {
		if (_animStatus == "animating")
		{
			yield break;
		}
        else
        {
			_animStatus = "animating";
			_rightDoor.SetTrigger("doorRightOpen");
			sfx.Play();
			yield return new WaitForSeconds(_animTime);
			rightStatus = "NaN";
			rightClosed = 0;
			_animStatus = "nothing";
			yield break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.JoystickButton1)) || (Input.GetKeyDown(KeyCode.O)) && (camScript.isOn == false && camScript.status == "nothing"))
		{
			if (_officeScript.currentLimit == _officeScript.camLimit[1])
			{
				Debug.Log("Left door");
				
				if (leftStatus == "NaN")
                {
					StartCoroutine(closeLeft());
                }
                else
                {
					StartCoroutine(openLeft());
				}
			}
			else if (_officeScript.currentLimit == _officeScript.camLimit[0])
			{
				Debug.Log("Right door");

				if (rightStatus == "NaN")
				{
					StartCoroutine(closeRight());
				}
				else
				{
					StartCoroutine(openRight());
				}
			}
		}
	}
}
