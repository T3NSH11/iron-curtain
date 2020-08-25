using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tank : MonoBehaviour
{
    public int id;
    public TurnBaseManager turnmanager;
    public Camera MainCam;
    public GameObject bullet;
    public GameObject FiringEnd;
    

    private float Moving;
    public float Rotate;
    public int MoveSpeed;

    float MouseX;
    float MouseZ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (turnmanager.turnstat == id && turnmanager.timeSinceTurnStarted>.2f)
        {
            Moving = Input.GetAxis("Vertical") * MoveSpeed;
            Rotate = Input.GetAxis("Horizontal") * 5;

            MouseX = Input.mousePosition.x;
            MouseZ = Input.mousePosition.y;



            if (Input.GetKeyDown(KeyCode.Space))
            {
                turnmanager.EndTurn();
                GameObject clone = Instantiate(bullet);
                clone.transform.position = FiringEnd.transform.position;
                clone.GetComponent<Rigidbody>().velocity = FiringEnd.transform.right * 10;
            }

        }
        
    }

    private void FixedUpdate()
    {
        if (turnmanager.turnstat == id)
        {
            GetComponent<Rigidbody>().velocity = FiringEnd.transform.right * Moving;
            this.transform.Rotate(transform.up * Rotate);
        }
    }
}
