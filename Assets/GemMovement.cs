using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMovement : MonoBehaviour
{
	public float floatUp = .005f;
	private float rotate = 90f;
	public Transform spawn;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position += new Vector3(0, Mathf.Sin(Time.fixedTime) * floatUp);
		transform.RotateAround(transform.position, transform.forward, Time.deltaTime * rotate);
	}
}
