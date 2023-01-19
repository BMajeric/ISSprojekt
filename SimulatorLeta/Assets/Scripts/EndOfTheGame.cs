using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheGame : MonoBehaviour
{
    public void GoBack (){
        
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        SceneManager.LoadScene(0);
    }

    
}
