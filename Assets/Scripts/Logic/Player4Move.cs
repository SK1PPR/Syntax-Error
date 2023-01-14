using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Move : MonoBehaviour
{
    public AnimationCurve acccurve;
    public float maxspeed = 20f;
    [SerializeField]
    float acc;


    //gameobjects and prefabs
    Rigidbody rb;
    public GameObject trailprefab;
    Trail calltrail;
    trailcolision trailcoll;
    public GameObject trail2;

    [SerializeField]
    float accmag = 1f;

    bool can = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject a = Instantiate(trailprefab);
        calltrail = a.GetComponent<Trail>();
        GameObject b = Instantiate(trail2,transform);
        trailcoll = b.GetComponent<trailcolision>();
    }

    private void Update()
    {   if (can)
        {
            calltrail.specialpos(transform.position);
        }
        can = false;
        acc = acccurve.Evaluate((Vector3.Magnitude(rb.velocity)) / maxspeed);
        if (Input.GetKeyDown(KeyCode.I))
        {

            float spd = Vector3.Magnitude(rb.velocity);
            rb.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles += new Vector3(0, -90, 0);
            rb.velocity = transform.forward * spd;
            Invoke("turn", Time.deltaTime);

        }
        else if (Input.GetKeyDown(KeyCode.P))
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
        trailcoll.straight(transform.position);
    }
    void turn()
    {
        calltrail.turn(transform.position);
        GameObject b = Instantiate(trail2,transform);
        trailcoll = b.GetComponent<trailcolision>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trail"))
        {
            Debug.Log("collided");
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Bounds")){
            Debug.Log("exited");
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(gameObject);
    //}
}
