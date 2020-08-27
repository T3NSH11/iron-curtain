using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{

    //public static bool playershot = false;
    //private static bool player1turn;
    //private static bool player2turn;
    //public static string player1check;
    //public static string player2check;

    //public int id;
    //public TurnBaseManager turnmanager;
    public Camera MainCam;
    public GameObject bullet;
    public GameObject FiringEnd;

    public int ID;
    private float Moving;
    public float Rotate;
    public float collisiondelay;
    public int MoveSpeed;
    public int Recoil;
    public int health;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        collisiondelay += Time.deltaTime;

        if (TurnBaseManager.PlayerTurn == ID && health != 0)
        {
            Moving = Input.GetAxis("Vertical") * MoveSpeed;
            Rotate = Input.GetAxis("Horizontal") * 5;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject clone = Instantiate(bullet);
                clone.transform.position = FiringEnd.transform.position;
                clone.GetComponent<Rigidbody>().velocity = FiringEnd.transform.right * 10;
                rb.AddForce(transform.right * -Recoil);
                TurnBaseManager.EndTurn();
            }

        }
        else if(TurnBaseManager.PlayerTurn >= 2)
        {
            TurnBaseManager.PlayerTurn = 0;
        }

        if (ID == 0 && health == 0)
        {
            SceneManager.LoadScene("player2wins", LoadSceneMode.Additive);
        }
        if (ID == 1 && health == 0)
        {
            SceneManager.LoadScene("player1wins", LoadSceneMode.Additive);
        }
    }

    private void FixedUpdate()
    {
        if (TurnBaseManager.PlayerTurn == ID)
        {
            GetComponent<Rigidbody>().velocity = FiringEnd.transform.right * Moving;
            this.transform.Rotate(transform.up * Rotate);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collisiondelay > 0.3 && (collision.gameObject.tag == "Bullet_2" | collision.gameObject.tag == "Bullet_1"))
        {
            collisiondelay = 0;
            health = health - 1;
        }
    }
}
