using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletTarget;
    public Color HitColor;
    public Texture HitTexture;
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
        GetComponent<MeshRenderer>().material = HitMaterial;
        Debug.Log("Ouch");
    }
}
