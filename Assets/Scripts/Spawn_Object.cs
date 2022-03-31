using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Object : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject virus;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)){
            transform.position = raycastHit.point;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.position = transform.position + new Vector3(0.0f, 0.3134493f, 0.0f);;
            // Instantiate(virus).transform.position = transform.position;
            Instantiate(virus, transform.position, Quaternion.identity);
        }
    }
}
