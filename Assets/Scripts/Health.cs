using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;

    public float MyHealth
    {
        get => health;
        set => health = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MyHealth <=0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (MyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
