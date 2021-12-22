using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookScript_4 : MonoBehaviour {

	public string[] status;
	public string[] posNames;
	public string[] animNames;
	public string _actualStatus;
	public string _actualAnimNames;
	public string _actualPosNames;
	public int whichStatus;
	public int whichAnims = 1;
	public int whichPos = 1;
	public float animTime;
	public float runTimeToAdd;

	[Header("main stuff")]
	public Image _roomImage;
	public Sprite _mainRoomSprite;

	[Header("Animations Stuff")]
	public Animator animSystem;
	public GameObject carpetAnim;
	public GameObject leftDoor;
	public GameObject rightDoor;
	public GameObject closetDoor;
	public Animator _leftDoor;
	public Animator _rightDoor;
	public Animator _closetDoor;
	public GameObject bed;

	[Header("DoorSprites")]
	public Sprite[] leftLight;
	public Sprite[] middleLight;
	public Sprite[] rightLight;
	public Sprite[] bedLight;

	[Header("about flaslight")]
	public bool usingLight;
	public AudioSource flashLightSfx;

	[Header("Audio stuff")]
	public AudioSource carpetSfx;
	public AudioSource[] doorSfx;

	// Use this for initialization
	void Start () {
		
	}

	
	IEnumerator lookLeft()
    {
		if (_actualStatus == "animating")
        {
			yield break;
        }
        else
        {
			whichStatus = 1;
			if (_actualPosNames == "lookingLeft" || _actualPosNames == "atLeft" || _actualPosNames == "atMiddle" || _actualPosNames == "atRight" || _actualPosNames == "atBed")
            {
				whichStatus = 0;
				Debug.Log("cant do that again");
				yield break;
            }
			else if (_actualPosNames == "lookingMiddle")
            {
				animSystem.SetTrigger("lookLeft_middle");
				yield return new WaitForSeconds(animTime);
				whichPos = 0;
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "lookingRight")
            {
				animSystem.SetTrigger("lookLeft_right");
				yield return new WaitForSeconds(animTime);
                whichPos = 1;
				whichStatus = 0;
				yield break;
            }
		}
    }

	IEnumerator lookRight()
    {
		if (_actualStatus == "animating")
		{
			yield break;
		}
		else
		{
			whichStatus = 1;
			if (_actualPosNames == "lookingRight" || _actualPosNames == "atLeft" || _actualPosNames == "atMiddle" || _actualPosNames == "atRight" || _actualPosNames == "atBed")
			{
				whichStatus = 0;
				Debug.Log("cant do that again");
				yield break;
			}
			else if (_actualPosNames == "lookingMiddle")
			{
				animSystem.SetTrigger("lookRight_middle");
				yield return new WaitForSeconds(animTime);
				whichPos = 2;
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "lookingLeft")
			{
				animSystem.SetTrigger("lookRight_left");
				yield return new WaitForSeconds(animTime);
				whichPos = 1;
				whichStatus = 0;
				yield break;
			}
		}
	}

	IEnumerator goForward()
    {
		if (_actualStatus == "animating")
		{
			yield break;
		}
		else
		{
			whichStatus = 1;
			if (_actualPosNames == "atLeft" || _actualPosNames == "atMiddle" || _actualPosNames == "atRight" || _actualPosNames == "atBed")
            {
				Debug.Log("Cant do that now!");
				whichStatus = 0;
				yield break;
            }
			else if (_actualPosNames == "lookingLeft")
            {
				animSystem.SetTrigger("runLeft");
				yield return new WaitForSeconds(animTime);
				flashLightSfx.Play();
				carpetAnim.SetActive(true);
				carpetSfx.Play();
				yield return new WaitForSeconds(animTime + runTimeToAdd);
				carpetAnim.SetActive(false);
				leftDoor.SetActive(true);
				doorSfx[0].Play();
				whichPos = 3;
				whichStatus = 0;
				yield break;
            }
			else if (_actualPosNames == "lookingMiddle")
			{
				animSystem.SetTrigger("runMiddle");
				yield return new WaitForSeconds(animTime);
				flashLightSfx.Play();
				carpetAnim.SetActive(true);
				carpetSfx.Play();
				yield return new WaitForSeconds(animTime + runTimeToAdd);
				carpetAnim.SetActive(false);
				closetDoor.SetActive(true);
				//doorSfx[0].Play();
				whichPos = 4;
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "lookingRight")
			{
				animSystem.SetTrigger("runRight");
				yield return new WaitForSeconds(animTime);
				flashLightSfx.Play();
				carpetAnim.SetActive(true);
				carpetSfx.Play();
				yield return new WaitForSeconds(animTime + runTimeToAdd);
				carpetAnim.SetActive(false);
				rightDoor.SetActive(true);
				doorSfx[0].Play();
				whichPos = 5;
				whichStatus = 0;
				yield break;
			}
		}
	}

	IEnumerator goBackwards()
    {
		if (_actualStatus == "animating")
		{
			yield break;
		}
		else
		{
			whichStatus = 1;
			/*
			if (_actualPosNames == "atLeft" || _actualPosNames == "atMiddle" || _actualPosNames == "atRight")
			{
				Debug.Log("Cant do that now!");
				whichStatus = 0;
				yield break;
			}
			*/
			if (_actualPosNames == "lookingLeft" || _actualPosNames == "lookingMiddle" || _actualPosNames == "lookingRight")
            {
				if (usingLight)
				{
					flashLightSfx.Play();
				}
				animSystem.SetTrigger("middle");
				bed.SetActive(true);
				yield return new WaitForSeconds(animTime);
				whichPos = 6;
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "atBed")
			{
				if (usingLight)
                {
					flashLightSfx.Play();
				}
				animSystem.SetTrigger("middle");
				bed.SetActive(false);
				yield return new WaitForSeconds(animTime);
				whichPos = 1;
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "atLeft")
			{
				if (usingLight)
				{
					flashLightSfx.Play();
				}
				animSystem.SetTrigger("left");
				leftDoor.SetActive(false);
				carpetAnim.SetActive(true);
				carpetSfx.Play();
				doorSfx[1].Play();
				yield return new WaitForSeconds(animTime + runTimeToAdd);
				carpetAnim.SetActive(false);
				flashLightSfx.Play();
				whichPos = 0;
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "atMiddle")
			{
				if (usingLight)
				{
					flashLightSfx.Play();
				}
				animSystem.SetTrigger("middle");
				closetDoor.SetActive(false);
				carpetAnim.SetActive(true);
				carpetSfx.Play();
				//doorSfx[1].Play();
				yield return new WaitForSeconds(animTime + runTimeToAdd);
				carpetAnim.SetActive(false);
				flashLightSfx.Play();
				whichPos = 1;
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "atRight")
			{
				if (usingLight)
				{
					flashLightSfx.Play();
				}
				animSystem.SetTrigger("right");
				rightDoor.SetActive(false);
				carpetAnim.SetActive(true);
				carpetSfx.Play();
				doorSfx[1].Play();
				yield return new WaitForSeconds(animTime + runTimeToAdd);
				carpetAnim.SetActive(false);
				flashLightSfx.Play();
				whichPos = 2;
				whichStatus = 0;
				yield break;
			}
		}
	}

	void useFlashLight()
	{
		if ((Input.GetKeyDown(KeyCode.JoystickButton0)) || (Input.GetKeyDown(KeyCode.X)))
		{
			if (_actualPosNames == "atBed")
			{
				bed.GetComponent<Image>().sprite = bedLight[1];
			}

			if (_actualPosNames == "atLeft")
			{
				leftDoor.GetComponent<Animator>().enabled = false;
				leftDoor.GetComponent<Image>().sprite = leftLight[1];
			}

			if (_actualPosNames == "atMiddle")
			{
				closetDoor.GetComponent<Animator>().enabled = false;
				closetDoor.GetComponent<Image>().sprite = middleLight[1];
			}

			if (_actualPosNames == "atRight")
			{
				rightDoor.GetComponent<Animator>().enabled = false;
				rightDoor.GetComponent<Image>().sprite = rightLight[1];
			}

			if (!(_actualPosNames == "lookingLeft" || _actualPosNames == "lookingMiddle" || _actualPosNames == "lookingRight"))
            {
				flashLightSfx.Play();
				usingLight = true;
			}
		}
		else if ((Input.GetKeyUp(KeyCode.JoystickButton0)) || (Input.GetKeyUp(KeyCode.X)))
		{
			if (_actualPosNames == "atBed")
            {
				bed.GetComponent<Image>().sprite = bedLight[0];
			}

			if (_actualPosNames == "atLeft")
			{
				leftDoor.GetComponent<Animator>().enabled = true;
				leftDoor.GetComponent<Image>().sprite = leftLight[0];
			}

			if (_actualPosNames == "atMiddle")
			{
				closetDoor.GetComponent<Animator>().enabled = true;
				closetDoor.GetComponent<Image>().sprite = middleLight[0];
			}

			if (_actualPosNames == "atRight")
			{
				rightDoor.GetComponent<Animator>().enabled = true;
				rightDoor.GetComponent<Image>().sprite = rightLight[0];
			}

			if (!(_actualPosNames == "lookingLeft" || _actualPosNames == "lookingMiddle" || _actualPosNames == "lookingRight"))
			{
				flashLightSfx.Play();
				usingLight = false;
			}
		}
	}

	IEnumerator closeDoor()
    {
		if (_actualStatus == "animating")
        {
			Debug.Log("cant close doors now lel");
			yield break;
        }
        else
        {
			whichStatus = 1;
			if (_actualPosNames == "lookingLeft" || _actualPosNames == "lookingMiddle" || _actualPosNames == "lookingRight" || _actualPosNames == "atBed")
            {
				Debug.Log("No doors in sight");
				whichStatus = 0;
				yield break;
            }
			else if (_actualPosNames == "atLeft")
            {
				_leftDoor.SetTrigger("closeLeft");
				doorSfx[3].Play();
				yield return new WaitForSeconds(animTime);
				whichStatus = 0;
			}
			else if (_actualPosNames == "atMiddle")
			{
                _closetDoor.SetTrigger("closeCloset");
				doorSfx[2].Play();
				yield return new WaitForSeconds(animTime);
				whichStatus = 0;
			}
			else if (_actualPosNames == "atRight")
			{
				_rightDoor.SetTrigger("closeRight");
				doorSfx[3].Play();
				yield return new WaitForSeconds(animTime);
				whichStatus = 0;
			}
		}
    }

	IEnumerator openDoor()
	{
		if (_actualStatus == "animating")
		{
			Debug.Log("cant open doors now lel");
			yield break;
		}
		else
		{
			whichStatus = 1;
			if (_actualPosNames == "lookingLeft" || _actualPosNames == "lookingMiddle" || _actualPosNames == "lookingRight" || _actualPosNames == "atBed")
			{
				Debug.Log("No doors in sight");
				whichStatus = 0;
				yield break;
			}
			else if (_actualPosNames == "atLeft")
			{
				_leftDoor.SetTrigger("openLeft");
				doorSfx[0].Play();
				yield return new WaitForSeconds(animTime);
				whichStatus = 0;
			}
			else if (_actualPosNames == "atMiddle")
			{
				_closetDoor.SetTrigger("openCloset");
				doorSfx[2].Play();
				yield return new WaitForSeconds(animTime);
				whichStatus = 0;
			}
			else if (_actualPosNames == "atRight")
			{
				_rightDoor.SetTrigger("openRight");
				doorSfx[1].Play();
				yield return new WaitForSeconds(animTime);
				whichStatus = 0;
			}
		}
	}


	void Update () {
        if ((Input.GetKeyDown(KeyCode.JoystickButton11)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
			StartCoroutine(lookLeft());
        }
        else if ((Input.GetKeyDown(KeyCode.JoystickButton9)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
			StartCoroutine(lookRight());
        }
		else if ((Input.GetKeyDown(KeyCode.JoystickButton8)) || (Input.GetKeyDown(KeyCode.UpArrow)))
		{
			StartCoroutine(goForward());
		}
		else if ((Input.GetKeyDown(KeyCode.JoystickButton10)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
			StartCoroutine(goBackwards());
        }
		
		
		if ((Input.GetKeyDown(KeyCode.JoystickButton1)) || (Input.GetKeyDown(KeyCode.O)))
        {
			StartCoroutine(closeDoor());
        }
		else if ((Input.GetKeyUp(KeyCode.JoystickButton1)) || (Input.GetKeyUp(KeyCode.O)))
        {
			StartCoroutine(openDoor());
		}

			_actualStatus = status[whichStatus];
		_actualAnimNames = animNames[whichAnims];
		_actualPosNames = posNames[whichPos];

		useFlashLight();
	}
}
