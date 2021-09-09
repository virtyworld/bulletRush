
using System.Collections.Generic;
using UnityEngine;

public class Barell : MonoBehaviour
{
    private Health health;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject barrel;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float  explodeRadius;
    [SerializeField] private float  explodeForce = 700f;


    private List<Collider> listNearbyObjects = new List<Collider>();
    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health.MyHealth <= 0)
        {
            DestroyBarell();
            Explode();
           
        }
    }

    private void  DestroyBarell()
    {
        Destroy(barrel);
        Destroy(gameObject,0.75f);
    }

    void Explode()
    {
        particle.Play();
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            
            if (rb != null )
            {
                rb.AddExplosionForce(explodeForce,transform.position,explodeRadius);
            }
           
            Health health = nearby.GetComponent<Health>();

            if (health != null)
            {
                if (health.MyHealth > 0)
                {
                    listNearbyObjects.Add(nearby);
                    health.MyHealth -= damage;
                } 
            }
            
        }

    }
}
