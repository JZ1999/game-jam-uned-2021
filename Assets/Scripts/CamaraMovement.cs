using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 diff;
    private Vector3 inicialPosition;

    void Start()
    {
        inicialPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        diff = player.transform.position - inicialPosition;  
        Debug.Log(diff.normalized);
        transform.position += diff.normalized * 0.05f;
       
    }
}
