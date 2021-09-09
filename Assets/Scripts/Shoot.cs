using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletsPrefab;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] private AnimationScript anim;

    private Transform _bullet;
    private int numberOfBullet;

    private float currentTime;
    private bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<AnimationScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Fire()
    {
        if (gameObject.tag == "Enemy")
        {
        }

        if (currentTime == 0)
        {
            shoot = true;
            StartCoroutine(Shooting());
        }

        if (shoot && currentTime < fireRate)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if (currentTime >= fireRate)
        {
            currentTime = 0;
            shoot = false;
        }
    }

    public void ChangeTypeBullet(string bulletType)
    {
        if (bulletType == "Burger")
        {
            numberOfBullet = 1;
        }

        if (bulletType == "Apple")
        {
            numberOfBullet = 2;
        }
    }

    public void TestFire()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        anim.AnimationPrefab.SetTrigger("Throw");

        yield return new WaitForSeconds(0.5f);
        _bullet = Instantiate(bulletsPrefab[numberOfBullet].transform, bulletSpawn.transform.position,
            Quaternion.identity);
        _bullet.rotation = bulletSpawn.transform.rotation;
    }
}