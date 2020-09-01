using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{

    public Camera MainCam;
    public GameObject bullet;
    public GameObject FiringEnd;
    public GameObject healthobject;

    public int ID;
    private float Moving;
    public float Rotate;
    public float collisiondelay;
    public int damage;
    public int MoveSpeed;
    public int Recoil;
    public int health;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


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
            SceneManager.LoadScene("player2wins", LoadSceneMode.Single);
        }
        if (ID == 1 && health == 0)
        {
            SceneManager.LoadScene("player1wins", LoadSceneMode.Single);
        }

        healthobject.GetComponent<Slider>().value = health;
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
            health = health - damage;
        }
    }
}
