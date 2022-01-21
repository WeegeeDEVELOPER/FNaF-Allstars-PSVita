using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class customNight_1_2 : MonoBehaviour {

	public int[] levels;
	public Text[] levelText;
	public int whichGame;
	public string[] anniName;

	public void subtract(int ID)
    {
        if (levels[ID] > 0)
            levels[ID]--;
        levelText[ID].text = levels[ID].ToString();
    }

	public void add(int ID)
    {
        if (levels[ID] < 20)
            levels[ID]++;
        levelText[ID].text = levels[ID].ToString();
    }

	public void startGame()
    {
        for (int i=0; i<anniName.Length; i++)
        {
            PlayerPrefs.SetInt("CN_" + whichGame.ToString() + "_" + anniName[i].ToString() + ":", levels[i]);
            PlayerPrefs.Save();
        }

        int whichNight = 7;
        PlayerPrefs.SetInt("save_game:" + whichGame.ToString(), whichNight);
        PlayerPrefs.Save();

        SceneManager.LoadSceneAsync("showNight_" + whichGame.ToString());
    }

	public void cancel()
    {
        SceneManager.LoadSceneAsync("MainMenu_" + whichGame.ToString());
    }
}
