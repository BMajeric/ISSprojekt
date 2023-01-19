using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    public GameObject ui;

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused){
            
            if(Input.GetButtonDown("1Key")){
            cam1.SetActive(true);
            cam2.SetActive(false);
            ui.SetActive(true);
        }
        if(Input.GetButtonDown("2Key")){
            cam1.SetActive(false);
            cam2.SetActive(true);
            ui.SetActive(false);
        }
        }
        
    }
}
