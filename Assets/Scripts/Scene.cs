using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    public void ScenePlay()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MenuUtama()
    {
        SceneManager.LoadScene("Main");
    }

   
	
}
