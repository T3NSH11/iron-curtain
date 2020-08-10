using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Animations;

public class Bullet : MonoBehaviour
{
    public Vector3 Move;
    public SphereCollider Collide;
    public GameObject thisobject;
    public int BounceLimit;

    Vector3 reflected;
    // Start is called before the first frame update

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
     Vector3 WallNormal = collision.contacts[0].normal;
     reflected = Vector3.Reflect(Move, WallNormal).normalized;

     GetComponent<Rigidbody>().velocity = reflected * 10;  
    }
}
