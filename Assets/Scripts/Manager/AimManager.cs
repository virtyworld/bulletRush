using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    public static AimManager Instance;
    private LookAtEnemy[] _lookAtEnemies;

    private List<GameObject> enemiesList = new List<GameObject>();

    private Quaternion targerRotation;
    private Quaternion lookAt;

    public GameObject closestEnemy;
    [SerializeField] private float maxRange = 20;

    private Shoot shoot;

    public float MAXRange => maxRange;

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

        shoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        ClosestEnemy();
    }

    void ClosestEnemy()
    {
        float range = maxRange;

        foreach (GameObject enemyGameObject in enemiesList)
        {
            if (enemyGameObject)
            {
                float dist = Vector3.Distance(enemyGameObject.transform.position, transform.position);


                if (dist < range)
                {
                    range = dist;
                    closestEnemy = enemyGameObject;

                    shoot.Fire();
                }
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
        closestEnemy = null;
    }
}