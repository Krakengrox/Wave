using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public string scene;

    public void Trigger()
    {
        SceneManager.LoadScene(scene);
    }
}
