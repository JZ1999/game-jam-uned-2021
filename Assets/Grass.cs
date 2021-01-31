using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
	[Range(0, 1)]
	public float alpha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("grass"))
		{
			Color color = other.GetComponent<MeshRenderer>().material.color;
			color.a = alpha;
			other.GetComponent<MeshRenderer>().material.color = color;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("grass"))
		{
			Color color = other.GetComponent<MeshRenderer>().material.color;
			color.a = 1;
			other.GetComponent<MeshRenderer>().material.color = color;
		}
	}
}
