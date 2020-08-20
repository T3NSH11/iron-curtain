using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Material HitMaterial;
    public int CaputuredControl;
    public int Player1Score;
    int Player2Score;
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
        if (bulletTarget.gameObject.CompareTag("Bullet"))
        {
            GetComponentInChildren<MeshRenderer>().material = HitMaterial; 
            Debug.Log("Ouch");
            Player1Score = 1;
            CAP = true;
        }
        else
        {
            Debug.Log("Ouch");
            Player1Score = 0;
            CAP = true;
        }
        
    }
}
