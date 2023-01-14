using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFluidity : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 inittrans = new Vector3(0.2f, 2.5f, -7);
    public Vector3 finaltrans = new Vector3(0.2f, 1.5f, -8.75f);
    public float maxplayerspeed = 200f;
    public AnimationCurve yaxis;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        transform.localPosition = inittrans;
    }
    private void Update()
    {
        float spd = Vector3.Magnitude(rb.velocity);
        Vector3 pos = new Vector3(0, 0, 0);
        pos.y= inittrans.y + yaxis.Evaluate(spd / maxplayerspeed) * (finaltrans.y - inittrans.y);
        pos.z = inittrans.z + yaxis.Evaluate(spd / maxplayerspeed) * (finaltrans.z - inittrans.z);
        transform.localPosition = pos;
    }
}
