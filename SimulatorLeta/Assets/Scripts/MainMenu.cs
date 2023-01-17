using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame (){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetLocationRnadom ()
    {
        Globals.location = 0;
        Debug.Log(Globals.location);
    }

    public void SetLocation1 ()
    {
        Globals.location = 1;
        Debug.Log(Globals.location);
    }

    public void SetLocation2 ()
    {
        Globals.location = 2;
        Debug.Log(Globals.location);
    }

    public void QuitGame(){
        Debug.Log("QUIT");
        Application.Quit();
    }
}
