using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class power_1 : MonoBehaviour {

	public Text _percentageText;
	public int _percentage;
	public float _nightMultiplier;
	public float _secondsPerDrop;
	public float _droppedValue;
	public float timer;
	//public float _dropValue;

	[Header("shared scripts")]
	public usage_1 _usageScript;
	public whichNight _nightScript;

	void calcDropTime()
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
			_secondsPerDrop = 8.5f;
		}
	}

	void calculateSecondsPerDrop()
    {

		if (_usageScript._whichUsage == 1)
		{
			_secondsPerDrop = _secondsPerDrop /= 2;
		}
		else if (_usageScript._whichUsage == 2)
		{
			_secondsPerDrop = ((_secondsPerDrop) / 2) / 2;
		}
		else if (_usageScript._whichUsage == 3)
		{
			_secondsPerDrop = (((_secondsPerDrop) / 2) / 2) / 2;
		}
		else if (_usageScript._whichUsage == 4)
		{
			_secondsPerDrop = ((((_secondsPerDrop) / 2) / 2) / 2) / 2;
		}
	}

	void Update()
    {
		calcDropTime();
		calculateSecondsPerDrop();

		timer += Time.deltaTime;

		if (timer >= _secondsPerDrop)
        {
			_percentage--;
			_percentageText.text = "Power left: <size=25>" + _percentage.ToString() + "%</size>";

			timer = 0;
		}
	}
}
