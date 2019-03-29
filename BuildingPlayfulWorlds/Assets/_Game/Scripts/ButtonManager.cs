using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void NewGameBTN(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void QuitGameBTN()
    {
        Application.Quit();
    }
}
