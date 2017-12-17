using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Application.Quit();
    }
}
