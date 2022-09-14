using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    
    public Rigidbody theRB;
    public float
    forwardAccel = 8f,
    reverseAccel = 6f,
    maxSpeed = 50f,
    turnStrength = 180;

    private float speedInput, turnInput;
    void Start()
    {
        theRB.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0f;

        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));

        transform.localPosition = theRB.transform.position;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(speedInput) > 0)
        {
            theRB.AddForce(transform.forward * forwardAccel * 300f);
        }
    }
}
