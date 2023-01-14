using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpplayermove : MonoBehaviour
{
    public AnimationCurve acccurve;
    public float maxspeed = 20f;
    [SerializeField]
    float acc;


    //gameobjects and prefabs
    Rigidbody rb;
    public GameObject trailprefab;
    Trail calltrail;
    BoxCollider box;


    [SerializeField]
    float accmag = 1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject a = Instantiate(trailprefab);
        calltrail = a.GetComponent<Trail>();
        //calltrail.straight(transform.position);
        box = GetComponent<BoxCollider>();

    }

    private void Update()
    {
        acc = acccurve.Evaluate((Vector3.Magnitude(rb.velocity)) / maxspeed);
        if (Input.GetButtonDown("Z"))
        {

            float spd = Vector3.Magnitude(rb.velocity);
            rb.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles += new Vector3(0, -90, 0);
            rb.velocity = transform.forward * spd;
            Invoke("turn", Time.deltaTime);

        }
        else if (Input.GetButtonDown("C"))
        {
            float spd = Vector3.Magnitude(rb.velocity);
            rb.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles += new Vector3(0, 90, 0);
            rb.velocity = transform.forward * spd;
            Invoke("turn", Time.deltaTime);
        }

        Invoke("straight", Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.velocity += transform.forward * acc * accmag;
    }

    void straight()
    {
        calltrail.straight(transform.position);
    }
    void turn()
    {
        calltrail.turn(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
