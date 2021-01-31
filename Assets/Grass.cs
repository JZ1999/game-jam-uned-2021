using Photon.Pun;
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
		if (GetComponent<PhotonView>() && !GetComponent<PhotonView>().isMine) return; 

		if (other.CompareTag("Grass"))
		{
			Debug.Log("in");
			Color color = other.GetComponentsInChildren<MeshRenderer>()[0].material.color;
			color.a = alpha;
	
			foreach (MeshRenderer o in other.GetComponentsInChildren<MeshRenderer>())
			{
				o.material.color = color;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (GetComponent<PhotonView>() && !GetComponent<PhotonView>().isMine) return;

		if (other.CompareTag("Grass"))
		{
			Debug.Log("out");
			Color color = other.GetComponentsInChildren<MeshRenderer>()[0].material.color;
			
			color.a = 1;
			foreach (MeshRenderer o in other.GetComponentsInChildren<MeshRenderer>())
			{
				o.material.color = color;
			}
		}
	}
}
