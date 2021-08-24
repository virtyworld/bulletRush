using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float aliveTime;
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;

    
     private GameObject enemyTriggered;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // transform.rotation = bulletSpawn.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= 1 * Time.deltaTime;

        if (aliveTime <= 0)
        {
            Destroy(gameObject);
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().MyHealth -= damage;
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Health -= damage;
            Destroy(gameObject);
        }
        if (other.tag == "Box")
        {
            other.gameObject.GetComponent<Health>().MyHealth -= damage;
            Destroy(gameObject);
        }
    }
}
