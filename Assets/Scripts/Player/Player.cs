using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    private Health health;
    private AnimationScript anim;
    private MovePlayer mp;


    private Shoot shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        health.MyHealth = maxHealth;
        
        shoot = GetComponent<Shoot>();
        anim = GetComponent<AnimationScript>();
        mp = GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //    health.MyHealth -= 1;
        // }
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     health.MyHealth += 1;
        // }
        // if (Input.GetMouseButtonDown(0))
        // {
        //       shoot.TestFire();
        // }
        //
        // if (health.MyHealth <= 0)
        // {
        //     StartCoroutine(Die());
        // }

        // HealthUpdate();
    }
   
    
    public IEnumerator Die()
    {
        if (health.MyHealth <= 0)
        {
            anim.AnimationPrefab.Play("Death");
            gameObject.GetComponent<MovePlayer>().enabled = false;
            gameObject.GetComponent<Shoot>().enabled = false;
            
            yield return new WaitForSeconds(2);
             Destroy(gameObject);
        }
    }
}
