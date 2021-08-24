using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float  fireRate;

    private Transform _bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Fire()
    {
        _bullet =  Instantiate(bulletPrefab.transform, bulletSpawn.transform.position, Quaternion.identity);
        _bullet.rotation = bulletSpawn.transform.rotation;
    }
}
