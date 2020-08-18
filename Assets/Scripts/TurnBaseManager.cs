using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBaseManager : MonoBehaviour
{
    public static bool player1turn = true;
    public static bool player2turn = false;
    private static bool playershot;
    
    
    void Start()
    {
        playershot = Tank.playershot;
    }


    void Update()
    {
        if (playershot == true && player1turn == true)
        {
            player1turn = false;
            player2turn = true;
            playershot = false;
        }

        if (playershot == true && player1turn == false)
        {
            player1turn = true;
            player2turn = false;
            playershot = false;
        }
    }
}
