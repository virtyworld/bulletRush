using UnityEngine;

public class Burger : PickableObjects
{

    private void OnTriggerEnter(Collider other)
    {
        TriggerEvent(other,"Burger");
    }
}
