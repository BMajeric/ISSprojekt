using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody _rb;
    
    [Header("Missile attributes")]
    [Tooltip("The speed at which the missile is fired.")]
    private float _speed = 10f;
    [Tooltip("The indicator if the missle is fired or if its still loaded.")]
    private bool isFired;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        isFired = false;
    }

    void FireMissile()
    {
        Vector3 localForward = _rb.transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        _rb.AddForce(-localForward * _speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isFired)
        {
            FireMissile();
            isFired = true;
        }
    }
}
