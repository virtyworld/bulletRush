using UnityEngine;

public class TargetObject : MonoBehaviour
{
    private void Awake()
    {
        WindowPointer ui = GetComponentInParent<WindowPointer>();
        if (ui == null)
        {
            ui = GameObject.Find("World").GetComponent<WindowPointer>();
        }

        if (ui == null) Debug.LogError("No UIController component found");

        ui.AddTargetIndicator(this.gameObject);
    }
}