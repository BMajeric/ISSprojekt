using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject tankPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(Globals.location == 1){
            Instantiate(tankPrefab,new Vector3(360.5f,11.8f,896.9f),Quaternion.identity);
        }
        if(Globals.location == 2){
            Instantiate(tankPrefab,new Vector3(615.7f, 20f, 162f),Quaternion.identity);
        }
        if(Globals.location == 0){
            Instantiate(tankPrefab,new Vector3(Random.Range(-1838,3033),416,Random.Range(-1838,3033)),Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
