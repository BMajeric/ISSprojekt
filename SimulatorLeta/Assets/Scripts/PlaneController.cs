using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
    [Header("Plane stats")]
    [Tooltip("How much the throttle ramps up or down.")]
    public float throttleIncrement = 1f;
    [Tooltip("Maximum engine thrust when at 100% throttle.")]
    public float maxThrust = 700f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 30f;

    [Tooltip("How much lift force this plane generates as it gains speed.")]
    public float lift = 135f;

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
    [SerializeField] TextMeshProUGUI hud;

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
        if (Input.GetKey(KeyCode.LeftShift)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.Space)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInputs();
        UpdateHUD();
    }

    private void FixedUpdate()
    {
        // Apply forces to our plane
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier);

        // adding upward draft force
        rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);
    }

    private void UpdateHUD() 
    {
        hud.text = "Throttle " + throttle.ToString("F0") + "%\n";
        hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + "m\n";
    }

}
