using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    public GameObject enemy;


    public float lookSpeed = 200;

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
    }
}