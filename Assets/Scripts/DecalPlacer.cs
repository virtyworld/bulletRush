using UnityEngine;

public class DecalPlacer : MonoBehaviour
{
    [SerializeField] private GameObject decalPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                SpawnDecal(raycastHit);
            }
        }
    }

    private void SpawnDecal(RaycastHit raycastHit)
    {
        var decal = Instantiate(decalPrefab);
        decal.transform.position = raycastHit.point;
        decal.transform.forward = raycastHit.normal * -1;
    }
}