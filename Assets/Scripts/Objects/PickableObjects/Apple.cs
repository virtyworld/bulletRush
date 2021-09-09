using UnityEngine;

public class Apple : PickableObjects
{
    private void OnTriggerEnter(Collider other)
    {
        TriggerEvent(other,"Apple");
    }
}
