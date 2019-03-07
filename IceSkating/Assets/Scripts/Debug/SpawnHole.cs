using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHole : MonoBehaviour
{
    [SerializeField] private GameObject iceBlockPrefab;
    [SerializeField] private LayerMask holeLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                SpawnIceHole(hit.point);
            }
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    SpawnIceHole(hit.point);
                }
            }
        }
    }

    private void SpawnIceHole(Vector3 position)
    {
        if (Physics.OverlapSphere(position, 1.5f, holeLayer).Length == 0)
        {
            Instantiate(iceBlockPrefab, position, Quaternion.identity);
        }
    }
}
