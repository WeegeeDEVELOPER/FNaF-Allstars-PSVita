using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class power_1 : MonoBehaviour {

	public Text _percentageText;
	public int _percentage;
	public float _nightMultiplier;
	public float _secondsPerDrop;

	[Header("shared scripts")]
	public usage_1 _usageScript;
	public whichNight _nightScript;

	void Start()
    {
        StartCoroutine(powerLoop());
	}

	void calculateSecondsPerDrop()
    {
		if (_nightScript._whichNight == 1)
        {
			_secondsPerDrop = 9.6f;
        }
		else if (_nightScript._whichNight == 2)
		{
			_secondsPerDrop = 9.4f;
		}
		else if (_nightScript._whichNight == 3)
		{
			_secondsPerDrop = 9.2f;
		}
		else if (_nightScript._whichNight == 4)
		{
			_secondsPerDrop = 9.0f;
		}
		else if (_nightScript._whichNight == 5)
		{
			_secondsPerDrop = 8.8f;
		}
		else if (_nightScript._whichNight == 6)
		{
			_secondsPerDrop = 8.6f;
		}
        else
        {

        }
	}

	void checkUsageMultiplier()
    {
		if (_usageScript._whichUsage == 1)
        {
			_secondsPerDrop = (_secondsPerDrop / 2);
        }
		else if (_usageScript._whichUsage == 2)
		{
			_secondsPerDrop = (_secondsPerDrop / 2) / 2;
		}
		else if (_usageScript._whichUsage == 3)
		{
			_secondsPerDrop = ((_secondsPerDrop / 2) / 2) / 2;
		}
		else if (_usageScript._whichUsage == 4)
		{
			_secondsPerDrop = (((_secondsPerDrop / 2) / 2) / 2) / 2;
		}
	}

	void Update()
    {
		calculateSecondsPerDrop();
		checkUsageMultiplier();
	}
	
	IEnumerator powerLoop()
    {
		yield return new WaitForSeconds(_secondsPerDrop);

		_percentage--;
		_percentageText.text = "Power left: <size=25>" + _percentage.ToString() + "%</size>";

		StartCoroutine(powerLoop());
    }
}
