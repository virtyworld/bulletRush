using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{

    public GameObject enemy;
    public GameObject fovStartPoint;

    public float lookSpeed = 200;
    public float maxAngle = 90;

    private Quaternion targerRotation;
    private Quaternion lookAt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            targerRotation = Quaternion.LookRotation(direction);
            lookAt = Quaternion.RotateTowards(transform.rotation, targerRotation, Time.deltaTime * lookSpeed);
            transform.rotation = lookAt; 
        }
        else
        {
            // targerRotation = Quaternion.Euler(0,0,0);
            // transform.localRotation =
            //     Quaternion.RotateTowards(transform.localRotation, Quaternion.identity, Time.deltaTime * lookSpeed);
           
        }
       
    }

    // bool EnemyInFieldView(GameObject looker)
    // {
    //     Vector3 targetDir = enemy.transform.position - transform.position;
    //     float angle = Vector3.Angle(targetDir, looker.transform.forward);
    //
    //     if (angle < maxAngle)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }
}
