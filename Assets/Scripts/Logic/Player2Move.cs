using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public AnimationCurve acccurve;
    public float maxspeed = 20f;
    [SerializeField]
    float acc;
    public GameObject player2lose, check2;
    public AudioSource source;

    //gameobjects and prefabs
    Rigidbody rb;
    public GameObject trailprefab;
    Trail calltrail;
    trailcolision trailcoll;
    public GameObject trail2;

    [SerializeField]
    float accmag = 1f;

    bool can = true;
    public gamelogic4p script;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {

            float spd = Vector3.Magnitude(rb.velocity);
            rb.velocity = new Vector3(0, 0, 0);
            transform.eulerAngles += new Vector3(0, -90, 0);
            rb.velocity = transform.forward * spd;
            Invoke("turn", Time.deltaTime);

        }
        else if (Input.GetKeyDown(KeyCode.E))
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
            source.Play();
            check2.SetActive(true);
            player2lose.SetActive(true);
            Debug.Log("collided");
            script.decrement();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Bounds")){
            player2lose.SetActive(true);
            check2.SetActive(true);
            Debug.Log("exited");
            script.decrement();
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(gameObject);
    //}
}
