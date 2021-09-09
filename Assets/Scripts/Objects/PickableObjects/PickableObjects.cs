using UnityEngine;

public class PickableObjects : MonoBehaviour
{
    
    protected void TriggerEvent(Collider other,string objectName)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Shoot>().ChangeTypeBullet(objectName);
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<Shoot>().ChangeTypeBullet(objectName);
        }
    }
}
