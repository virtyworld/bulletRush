using System.Collections.Generic;
using UnityEngine;


public class WindowPointer : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private List<TargetIndicator> targetIndicators = new List<TargetIndicator>();
    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject targetIndicatorPrefub;


    private void Update()
    {
        if (targetIndicators.Count > 0)
        {
            for (int i = 0; i < targetIndicators.Count; i++)
            {
                targetIndicators[i].UpdateTargetIndicator();
            }
        }
    }

    public void AddTargetIndicator(GameObject target)
    {
        TargetIndicator indicator = GameObject.Instantiate(targetIndicatorPrefub, canvas.transform)
            .GetComponent<TargetIndicator>();
        indicator.InitialiseTargetIndicator(target, MainCamera, canvas);
        targetIndicators.Add(indicator);
    }

    public void DeleteFromList(TargetIndicator target)
    {
        targetIndicators.Remove(target);
    }
}