using System.Collections;
using System.Collections.Generic;
using EasyJoystick;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator anim;

    private LookAtEnemy _lookAtEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        _lookAtEnemy = GetComponent<LookAtEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float zMovement = joystick.Vertical();

        transform.position += new Vector3(xMovement, 0f, zMovement)*speed*Time.deltaTime;

        if (!_lookAtEnemy.enemy)
        {
            transform.forward = new Vector3(xMovement, 0f, zMovement) * speed * Time.deltaTime; 
        }
      
        
        
       
        if (joystick.Vertical() == 0)
        {
           //anim.SetBool("Walking",false);
        }
        else
        {
            //anim.SetBool("Walking",true);
        }
         
         
    }
}
