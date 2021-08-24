using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private GameObject enemyBullet;
    
    [Header("Shoot settings")]
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private float range;
    
    private float currentTime;

    private GameObject player;
    private Transform bulletSpawn;

    private bool shoot;
    private Shoot shootComponent;
    private Health health;
    
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shootComponent = GetComponent<Shoot>();
        health = GetComponent<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health.MyHealth <= 0)
        {
            Die();
        }
        
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (range > dist)
        {
         
            transform.LookAt(player.transform);

            if (currentTime == 0)
            {
                Shoot();
            }

            if (shoot && currentTime < waitTime)
            {
                currentTime += 1 * Time.deltaTime;
            }

            if (currentTime >= waitTime)
            {
                currentTime = 0;
            } 
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }

    public void Die()
    {
        Destroy(gameObject);

        LevelScript.Instance.EnemyInScene--;
        GameManager.Instance.UpdateLevelProgress();
       AimManager.Instance.Remove(gameObject);
    }

    public void Shoot()
    {
        shoot = true;

        shootComponent.Fire();
       

    }
}
