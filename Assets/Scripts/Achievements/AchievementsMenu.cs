using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementsMenu : MonoBehaviour {

	[Header("Selection information")]
	public GameObject[] achMenus;
	public int whichGameSelected = 0;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Joystick1Button11) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (whichGameSelected > 0)
            {
				achMenus[whichGameSelected].SetActive(false);
				whichGameSelected -= 1;
				achMenus[whichGameSelected].SetActive(true);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (whichGameSelected < 3)
			{
				achMenus[whichGameSelected].SetActive(false);
				whichGameSelected += 1;
				achMenus[whichGameSelected].SetActive(true);
			}
		}

		if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.I))
		{
			SceneManager.LoadSceneAsync("Launcher");
		}
	}
}
