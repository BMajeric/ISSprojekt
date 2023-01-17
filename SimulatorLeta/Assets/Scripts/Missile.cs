using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : MonoBehaviour
{
    Rigidbody _rb;
    

    [Header("Missile attributes")]

    [Tooltip("Transforms to calculate the raycast direction.")]
    [SerializeField] private Transform RaycastStart1;
    [SerializeField] private Transform RaycastStart2;

    [Tooltip("The speed at which the missile is fired.")]
    [SerializeField] private float _speed = 20f;

    [Tooltip("Smoke trail model.")]
    [SerializeField] private GameObject _smokeTrail;

    [Tooltip("Explosion model.")]
    [SerializeField] private GameObject _explosion;

    [Tooltip("The indicator if the missle is fired or if its still loaded.")]
    private bool isFired;

    [Tooltip("The initial offset in position between the plane and the missile.")]
    private Vector3 positionOffset;

    [Tooltip("The initial offset in rotation between the plane and the missile.")]
    private Quaternion rotationOffset;

    [Tooltip("The result of a Raycast hit.")]
    private RaycastHit hit;
    private Vector3 targetPosition;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        isFired = false;
        positionOffset = _rb.transform.localPosition;
        rotationOffset = _rb.transform.localRotation;
    }

    void Start()
    {
        _smokeTrail.SetActive(false);
        Physics.IgnoreLayerCollision(3, 6);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Destructable"))
        {
            Instantiate(_explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.collider.gameObject);
            SceneManager.LoadScene(2);
             
            
        }

        Destroy(gameObject);
    }

    private void FireMissile()
    {
        
        _smokeTrail.SetActive(true);
        _rb.transform.LookAt(targetPosition);
        Vector3 localForward = transform.forward;
        _rb.AddForce(localForward * _speed, ForceMode.Impulse);
    }
   

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused){
            Vector3 RaycastDirection = RaycastStart1.position - RaycastStart2.position;
            Ray ray = new Ray(RaycastStart1.position, RaycastDirection);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(RaycastStart1.position, RaycastDirection * hit.distance, Color.red);
            targetPosition = hit.point;
            

            if (Input.GetButtonDown("Fire1") && !isFired)
            {
                
                FireMissile();
                isFired = true;
            }
            else if (!isFired)
            {
                _rb.transform.localPosition = positionOffset;
                _rb.transform.localRotation = rotationOffset;
            }
        } 
        else
        {
            Debug.DrawRay(RaycastStart1.position, RaycastDirection * 100000, Color.green);

            if (Input.GetButtonDown("Fire1") && !isFired)
            {
                FireMissile();
                isFired = true;
            }
            else if (!isFired)
            {
                _rb.transform.localPosition = positionOffset;
                _rb.transform.localRotation = rotationOffset;
            }
        }
          
        }
       

    }

    
}
