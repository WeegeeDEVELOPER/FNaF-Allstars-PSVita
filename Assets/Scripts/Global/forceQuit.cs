using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forceQuit : MonoBehaviour {

	void Update () {
		if ((Input.GetKey(KeyCode.JoystickButton6) && Input.GetKey(KeyCode.JoystickButton4) && Input.GetKeyUp(KeyCode.JoystickButton5)) || (Input.GetKey(KeyCode.Q))){
			Resources.UnloadUnusedAssets();
			SceneManager.LoadSceneAsync("Launcher");
        }
	}
}
