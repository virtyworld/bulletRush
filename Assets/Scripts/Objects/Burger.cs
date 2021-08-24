using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
   

    // private GameObject player;
   
    
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Shoot>().ChangeTypeBullet("Burger");
            Destroy(gameObject);
        }
        
    }
}
