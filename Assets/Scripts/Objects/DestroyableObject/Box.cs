using UnityEngine;

public class Box : MonoBehaviour
{

    private Health health;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.MyHealth <= 0)
        {
            Destroy(gameObject,5f);
        }
    }
    
    
    
}
