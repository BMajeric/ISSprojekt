using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody _rb;
    public GameObject _go;
    
    [Header("Missile attributes")]
    [Tooltip("The speed at which the missile is fired.")]
    public float _speed = 10f;
    [Tooltip("The indicator if the missle is fired or if its still loaded.")]
    private bool isFired;
    [Tooltip("The initial offset in position between the plane and the missile.")]
    private Vector3 positionOffset;
    [Tooltip("The initial offset in rotation between the plane and the missile.")]
    private Quaternion rotationOffset;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        isFired = false;
        positionOffset = _rb.transform.localPosition;
        rotationOffset = _rb.transform.localRotation;
    }

    void FireMissile()
    {
        // Vector3 localForward = _rb.transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        Vector3 localForward = _rb.transform.right;
        _rb.AddForce(localForward * _speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
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
