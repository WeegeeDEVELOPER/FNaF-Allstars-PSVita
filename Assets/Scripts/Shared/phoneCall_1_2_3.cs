using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneCall_1_2_3 : MonoBehaviour {

	public GameObject _endCall;
	public AudioSource _callAudioSource;
	public AudioClip[] _phoneCalls;
	public bool inCall = true;


	[Header("Shared scripts")]
	public whichNight _nightScript;

	// Use this for initialization
	void Start () {
		startCall();
	}

	public void startCall()
    {
		_endCall.SetActive(true);
		_callAudioSource.clip = _phoneCalls[_nightScript._whichNight - 1];
		_callAudioSource.Play();
    }

	public void endCall()
    {
		_endCall.SetActive(false);
		inCall = false;
		_callAudioSource.Stop();
    }
	
	void Update () {
		if ((Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.A)) && inCall)
        {
			endCall();
        }
		if (_callAudioSource.isPlaying == false)
        {
			endCall();
        }
	}
}
