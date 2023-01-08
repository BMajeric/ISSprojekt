using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] private Transform RaycastStart;
    
    [Header("Missile attributes")]
    [Tooltip("The speed at which the missile is fired.")]
    public float _speed = 10f;
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

    void FireMissile()
    {
        Vector3 localForward = _rb.transform.right;
        _rb.AddForce(localForward * _speed, ForceMode.Impulse);
    }

    void RotateMissileToTraget()
    {
        Vector3 missileDirection = targetPosition - _rb.transform.position;
        Quaternion rotation = Quaternion.LookRotation(missileDirection);
        _rb.MoveRotation(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Drawing the Raycast beam in the scene and checking if it hit something
        Ray ray = new Ray(RaycastStart.position, -RaycastStart.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(RaycastStart.position, -RaycastStart.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            targetPosition = hit.point;
            RotateMissileToTraget();

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
            Debug.DrawRay(RaycastStart.position, -RaycastStart.TransformDirection(Vector3.forward) * 100000, Color.green);

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
