using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    public static AimManager Instance;
    private LookAtEnemy[] _lookAtEnemies;

    private List<GameObject> enemiesList = new List<GameObject>();

    public GameObject closestEnemy;
    [SerializeField] private float maxRange = 1000;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        _lookAtEnemies = GetComponentsInChildren<LookAtEnemy>();
        Enemy[] enemiesInScene = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemiesInScene)
        {
            enemiesList.Add(enemy.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ClosestEnemy();
    }

    void ClosestEnemy()
    {
        Debug.Log("ClosestEnemy");
        float range = maxRange;

        foreach (GameObject enemyGameObject in enemiesList)
        {
            float dist = Vector3.Distance(enemyGameObject.transform.position, transform.position);


            if (dist < range)
            {
                Debug.Log("dist < maxRange");
                range = dist;
                closestEnemy = enemyGameObject;
            }
        }

        foreach (LookAtEnemy lookAtEnemy in _lookAtEnemies)
        {
            lookAtEnemy.enemy = closestEnemy;
        }
    }


    public void Remove(GameObject closeseEnemy)
    {
        enemiesList.Remove(closeseEnemy);
    }
}