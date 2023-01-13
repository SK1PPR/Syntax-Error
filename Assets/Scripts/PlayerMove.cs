using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public AnimationCurve acccurve;
    public float maxspeed = 20f;
    float acc;

    Rigidbody rb;


    [SerializeField]
    float accmag = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        acc = acccurve.Evaluate((Vector3.Magnitude(rb.velocity))/maxspeed);
    }

    private void Update()
    {

        if (Input.GetButtonDown("Left"))
        {

            float spd = Vector3.Magnitude(rb.velocity) - 3f;
            rb.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles += new Vector3(0, -90, 0);
            rb.velocity = transform.forward * spd;
        }
        else if (Input.GetButtonDown("Right"))
        {
            float spd = Vector3.Magnitude(rb.velocity) - 3f;
            rb.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles += new Vector3(0, 90, 0);
            rb.velocity = transform.forward * spd;
        }
    }


    private void FixedUpdate()
    {
        
        rb.velocity += transform.forward * acc * accmag;
    }

}
