using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailcolision : MonoBehaviour
{
    BoxCollider box;
    Vector3 initialpos;
    Vector3 finalpos;
    [SerializeField]
    float playerlength = 1f;

    private void Start()
    {
        box = GetComponent<BoxCollider>();
        initialpos = transform.position;
        box.size = new Vector3(0.5f, 1, 0.2f);
        transform.parent = null;

        Physics.IgnoreLayerCollision(7, 7);
    }


    public void straight(Vector3 pos)
    {
        finalpos = pos;
        float dist = Vector3.Magnitude(finalpos - initialpos);
        box.center = new Vector3(0, 0, (dist) / 2 + playerlength / 4);
        if (dist > playerlength / 2)
        {
            box.size = new Vector3(0.5f, 1f, (dist) - playerlength / 2);
        }
        else box.size = new Vector3(0.5f, 1, 0.2f);



    }
}
