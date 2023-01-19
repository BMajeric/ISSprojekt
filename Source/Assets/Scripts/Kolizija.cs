using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Kolizija : MonoBehaviour
{
    
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject kamera;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Siguran"))
        {
            Instantiate(explosion, new Vector3(0,0,0), Quaternion.identity, kamera.transform);
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            SceneManager.LoadScene(3);
             
            
        }

       
    }
}
