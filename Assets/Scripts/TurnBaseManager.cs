using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBaseManager : MonoBehaviour
{
    //public static bool player1turn = true;
    //public static bool player2turn = false;
    //private static bool playershot;

    public static int PlayerTurn;
    static float delay;
    void Start()
    {
        //playershot = Tank.playershot;
    }

    //public int turnstat = 0;
    //public float timeSinceTurnStarted = 0;
    void Update()
    {
        /*timeSinceTurnStarted = 0;
        if (turnstat == 0)
        {
            turnstat = 1;
        }
        else
        {
            turnstat = 0;
        }*/
        
    }

    public static void EndTurn()
    {
        PlayerTurn++;
    }
    /*private void Update()
    {
        timeSinceTurnStarted += Time.deltaTime;

    }*/


    
}
