using EasyJoystick;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Joystick joystick;

    private AnimationScript animScript;

    private AimManager _lookAtEnemy;


    // Start is called before the first frame update
    void Start()
    {
        _lookAtEnemy = GetComponent<AimManager>();
        animScript = GetComponent<AnimationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float zMovement = joystick.Vertical();


        transform.position += new Vector3(xMovement, 0f, zMovement) * speed * Time.deltaTime;


        if (_lookAtEnemy.closestEnemy)
        {
            float dist = Vector3.Distance(_lookAtEnemy.closestEnemy.transform.position, transform.position);

            if (dist < _lookAtEnemy.MAXRange && dist > 0)
            {
            }
            else
            {
                transform.forward = new Vector3(xMovement, 0f, zMovement) * speed * Time.deltaTime;
            }
        }
        else
        {
            transform.forward = new Vector3(xMovement, 0f, zMovement) * speed * Time.deltaTime;
        }


        if (joystick.Vertical() == 0)
        {
            animScript.AnimationPrefab.SetBool("Running", false);
        }
        else
        {
            animScript.AnimationPrefab.SetBool("Running", true);
        }
    }
}