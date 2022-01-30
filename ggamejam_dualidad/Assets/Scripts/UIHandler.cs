using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIHandler : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
