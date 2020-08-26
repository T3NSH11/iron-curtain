using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Material HitMaterial1;
    public Material HitMaterial2;
    public int CaputuredControl;
    public int Player1Score;
    public int Player2Score;
    public bool CAP;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision bulletTarget)
    {
        if (bulletTarget.gameObject.CompareTag("Bullet_1"))
        {
            GetComponentInChildren<MeshRenderer>().material = HitMaterial1;
            Player1Score = 1;
            Player2Score = 0;
            CAP = true;
        }
        else if (bulletTarget.gameObject.CompareTag("Bullet_2"))
        {
            GetComponentInChildren<MeshRenderer>().material = HitMaterial2;
            Player1Score = 0;
            Player2Score = 1;
            CAP = true;
        }
    }
}
