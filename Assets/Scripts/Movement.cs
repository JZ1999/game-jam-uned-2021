using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Camera cam;
    private Vector3 posWorld;

    public Transform pivot;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        posWorld = pivot.position;
        transform.LookAt(transform); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {  // Pulsamos el botón izquierdo del ratón
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                posWorld = hit.point;
                pivot.position = posWorld;
                transform.LookAt(pivot.transform);
                GetComponent<Rigidbody>().velocity = (transform.forward) * 200 * Time.fixedDeltaTime;
            }
            
        }
    
    }
}