using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Plane stats")]
    [Tooltip("How much the throttle ramps up or down.")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum engine thrust when at 100% throttle.")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 10f;

    private float throttle;     // Percentage of maximum engine thrust currently being used.
    private float roll;         // Tilting left to right.
    private float pitch;        // Tilting front to back.
    private float yaw;          // "Turning" left to rigth.

    private float responseModifier { // Value used to tweak responsiveness to suit plane's mass.
        get {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    Rigidbody rb;

    // Start is called before the first frame update
    private void Start() // Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs() 
    {
        // Set rotational values from our axis inputs
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        // Handle throttle value being sure to clamp it between 0 and 100.
        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInputs();
    }

    private void FixedUpdate()
    {
        // Apply forces to our plane
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier);
    }

}
