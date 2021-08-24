using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private GameObject enemyBullet;
    
    [Header("Shoot settings")]
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject bulletSpawnPoint;
    
    private float currentTime;

    private GameObject player;
    private Transform bulletSpawn;

    private bool shoot;
    private Shoot shootComponent;
    
    public float Health
    {
        get => health;
        set => health = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shootComponent = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(health);
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
