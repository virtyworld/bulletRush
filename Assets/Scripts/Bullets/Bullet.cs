using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float aliveTime;
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject bulletHolePrefub;
    
    private GameObject enemyTriggered;
    
    
    // Start is called before the first frame update
   

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
       
        if (other.tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {
            other.gameObject.GetComponent<Health>().MyHealth -= damage;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            other.gameObject.GetComponent<Health>().MyHealth -= damage;
            Destroy(gameObject);
        }
        if (other.tag == "Box")
        {
            other.gameObject.GetComponent<Health>().MyHealth -= damage;
            Destroy(gameObject);
        }
        if (other.tag == "Barell")
        {
            other.gameObject.GetComponent<Health>().MyHealth -= damage;
            Destroy(gameObject);
        }

        if (other.tag == "Tree")
        {
            RaycastHit raycastHit;
            Ray ray = new Ray(transform.position, other.transform.position - transform.position);
            if (Physics.Raycast(ray,out raycastHit))
            {
                SpawnDecal(raycastHit);
                DestroyBullet(gameObject);
            }
        }
    }
    
    private void SpawnDecal(RaycastHit raycastHit)
    {
        var decal = Instantiate(bulletHolePrefub);
        decal.transform.position = raycastHit.point;
        decal.transform.forward = raycastHit.normal * -1;
        Destroy(decal,15f);
    }

    private void DestroyBullet(GameObject gameObject)
    {
       Destroy(gameObject);
    }
}
