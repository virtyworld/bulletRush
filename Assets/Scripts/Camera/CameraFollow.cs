using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 desiredPosition = target.position + offset;
          
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
             transform.position = smoothPosition ;

        }
      
    }
}
