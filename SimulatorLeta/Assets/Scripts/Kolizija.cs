using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Kolizija : MonoBehaviour
{
    

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Siguran"))
        {
            
            SceneManager.LoadScene(3);
             
            
        }

       
    }
}
