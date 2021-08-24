using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    private float health;

    public float Health
    {
        get => health;
        set => health = value;
    }

    private Shoot shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        shoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.MyHealth -= 1;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.Instance.MyHealth += 1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            shoot.Fire();
        }

        if (health <= 0)
        {
            Die();
        }

        HealthUpdate();
    }

    private void Die()
    {
        Debug.Log("Player Die");
    }

    void HealthUpdate()
    {
        GameManager.Instance.MyHealth = health;
    }
}
