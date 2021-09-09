using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Shoot settings")]
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private float range;
    
     private WindowPointer windowPointer;
     public GameObject targetIndicator;
     private EnemyPatrol EnemyPatrol;

     public GameObject TargetIndicator
     {
         get => targetIndicator;
         set => targetIndicator = value;
     }

     private float currentTime;
    private AnimationScript anim;

    private GameObject player;
    private Transform bulletSpawn;

    private bool shoot;
    private Shoot shootComponent;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shootComponent = GetComponent<Shoot>();
        anim = GetComponent<AnimationScript>();
        EnemyPatrol = GetComponent<EnemyPatrol>();
        windowPointer = GetComponentInParent<WindowPointer>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (player)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);

            if (range > dist)
            {
         
                transform.LookAt(player.transform);

                if (currentTime == 0)
                {
                    shootComponent.Fire();
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
    }
    

    public IEnumerator Die()
    {
        AimManager.Instance.Remove(gameObject);
        EnemyPatrol.enabled = false;
        shootComponent.enabled = false;
        anim.AnimationPrefab.Play("Death");
        windowPointer.DeleteFromList(targetIndicator.GetComponent<TargetIndicator>());
        yield return new WaitForSeconds(2);
        
        Destroy(targetIndicator);
        Destroy(gameObject);
    }

}
