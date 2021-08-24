using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletsPrefab;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float  fireRate;

    private Transform _bullet;
    private int numberOfBullet;
    
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
        _bullet =  Instantiate(bulletsPrefab[numberOfBullet].transform, bulletSpawn.transform.position, Quaternion.identity);
        _bullet.rotation = bulletSpawn.transform.rotation;
    }

    public void ChangeTypeBullet(string bulletType)
    {
        if (bulletType == "Burger")
        {
            numberOfBullet = 1;
        }
        
    }
}
