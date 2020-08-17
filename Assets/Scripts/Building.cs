using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Material HitMaterial;
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
        }
        
    }
}
