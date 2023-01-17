using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject tankPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetButtonDown("Location 1")){
            Instantiate(tankPrefab,new Vector3(252,416,1148),Quaternion.identity);
        }
        if(Input.GetButtonDown("Location 2")){
            Instantiate(tankPrefab,new Vector3(293,416,1138),Quaternion.identity);
        }
        if(Input.GetButtonDown("Location 1")){
            Instantiate(tankPrefab,new Vector3(Random.Range(-1838,3033),416,Random.Range(-1838,3033)),Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
