using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public void loadScene()
    {
        Application.LoadLevel("Scene2");
    }
    public void nextScene()
    {
        Application.LoadLevel("Scene3");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        Application.LoadLevel("Scene3");
    }
}
