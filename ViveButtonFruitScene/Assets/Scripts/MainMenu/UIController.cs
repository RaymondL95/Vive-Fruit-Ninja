using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour {

      public void LevelLoader(string level)
    {
        Debug.Log("Loading " + level);
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
