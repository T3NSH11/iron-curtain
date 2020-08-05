using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Animations;

public class Bullet : MonoBehaviour
{
    public Vector3 Move;
    public BoxCollider Collide;
    public GameObject thisobject;
    public int BounceLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = this.GetComponent<Rigidbody>().velocity;
        if (Input.GetKey(KeyCode.B))
        {
            Destroy(this.gameObject);
        }
        else
        {
            GetComponent<TrailRenderer>().time = 999;
        }
        if(BounceLimit == 0)
        {
            Destroy(Collide);
            Destroy(thisobject);
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.transform.localRotation.y > 0)
        {
            Move.z = -Move.z;
            --BounceLimit;
            GetComponent<Rigidbody>().velocity = Move;
        }
        else
        {
            Move.x = -Move.x;
            --BounceLimit;
            GetComponent<Rigidbody>().velocity = Move;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
