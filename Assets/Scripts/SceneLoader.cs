using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public void OnLoad(string sceneName) {
        Debug.Log("SceneLoader.OnLoad: " + sceneName);
        if (SceneUtility.GetBuildIndexByScenePath(sceneName) != -1) {
            Debug.Log("SceneLoader.OnLoad: " + sceneName + " is loaded.");
            SceneManager.LoadScene(sceneName);
        }
    }
}
