using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tank : MonoBehaviour
{
    //public static bool playershot = false;
    //private static bool player1turn;
    //private static bool player2turn;
    //public static string player1check;
    //public static string player2check;
    public Camera MainCam;
    public GameObject bullet;
    public GameObject FiringEnd;

    public int ID;

    private float Moving;
    public float Rotate;
    public int MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
      //player1turn = TurnBaseManager.player1turn;
      //player2turn = TurnBaseManager.player2turn;
      //player1check = "Player1_Tank";
      //player2check = "Player2_Tank";
    }

    // Update is called once per frame
    void Update()
    {
        //if(tag.Equals(player1check))
        if (TurnBaseManager.PlayerTurn == ID)
        {
            Moving = Input.GetAxis("Vertical") * MoveSpeed;
            Rotate = Input.GetAxis("Horizontal") * 5;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject clone = Instantiate(bullet);
                clone.transform.position = FiringEnd.transform.position;
                clone.GetComponent<Rigidbody>().velocity = FiringEnd.transform.right * 10;

                TurnBaseManager.EndTurn();
            }

        }
        else if(TurnBaseManager.PlayerTurn >= 2)
        {
            TurnBaseManager.PlayerTurn = 0;
        }
        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = FiringEnd.transform.right * Moving;
        this.transform.Rotate(transform.up * Rotate);
    }
}
