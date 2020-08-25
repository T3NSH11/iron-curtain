using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBaseManager : MonoBehaviour
{
    public int turnstat = 0;
    public float timeSinceTurnStarted = 0;
    public void EndTurn()
    {
        timeSinceTurnStarted = 0;
        if (turnstat == 0)
        {
            turnstat = 1;
        }
        else
        {
            turnstat = 0;
        }
    }
    private void Update()
    {
        timeSinceTurnStarted += Time.deltaTime;

    }


    
}
