using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<GameObject> CaptureBuildings;
    public int Player1TotalScore;
    public int Player2TotalScore;
    static int temp1;
    static int temp2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Building").Length; i++)
        {
            CaptureBuildings.Add(GameObject.FindGameObjectsWithTag("Building")[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < CaptureBuildings.Count; i++)
        {
            if (CaptureBuildings[i].GetComponent<Building>().CAP)
            {
                CaptureBuildings[i].GetComponent<Building>().CAP = false;
                scoreupdate();
            }
        }
    }

    public void scoreupdate()
    {
        for (int i = 0; i < CaptureBuildings.Count; i++)
        {
            if (CaptureBuildings[i].GetComponent<Building>().Player1Score == 1)
            {
                temp1 += 1;
            }

            if (CaptureBuildings[i].GetComponent<Building>().Player2Score == 1)
            {
                temp2 += 1;
            }
        }
        Player1TotalScore = temp1;
        Player2TotalScore = temp2;
        Debug.Log(Player1TotalScore + " : " + Player2TotalScore);
        temp1 = 0;
        temp2 = 0;
    }
}
