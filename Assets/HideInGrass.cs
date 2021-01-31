using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInGrass : MonoBehaviour
{
	public List<GameObject> inGrassObjects;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject);
		if (other.gameObject.GetComponent<PhotonView>() && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			foreach (GameObject g in inGrassObjects)
			{
				if (g.GetComponent<MeshRenderer>())
					g.GetComponent<MeshRenderer>().enabled = true;
				if (g.GetComponent<SkinnedMeshRenderer>())
					g.GetComponent<SkinnedMeshRenderer>().enabled = true;
			}
			return;
		};
		turnInvisible(other);
		inGrassObjects.Add(other.gameObject);
	}

	private void turnInvisible(Collider other)
	{
		Debug.Log(other.GetComponentsInChildren<MeshRenderer>());
		if (other.GetComponentInChildren<MeshRenderer>())
		{
			foreach (MeshRenderer m in other.GetComponentsInChildren<MeshRenderer>())
			{
				Debug.Log(m);
				m.GetComponent<MeshRenderer>().enabled = !m.GetComponent<MeshRenderer>().enabled;
			}
		}else if (other.GetComponent<MeshRenderer>())
		{
			other.GetComponent<MeshRenderer>().enabled = !other.GetComponent<MeshRenderer>().enabled;
		}

		Debug.Log(other.GetComponentInChildren<SkinnedMeshRenderer>());
		if (other.GetComponentInChildren<SkinnedMeshRenderer>())
		{
			foreach (SkinnedMeshRenderer m in other.GetComponentsInChildren<SkinnedMeshRenderer>())
			{
				m.GetComponent<SkinnedMeshRenderer>().enabled = !m.GetComponent<SkinnedMeshRenderer>().enabled;
			}
		} else if (other.GetComponent<SkinnedMeshRenderer>())
		{
			other.GetComponent<SkinnedMeshRenderer>().enabled = !other.GetComponent<SkinnedMeshRenderer>().enabled;
		}




	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<PhotonView>() && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			foreach (GameObject g in inGrassObjects)
			{
				if (g.GetComponent<MeshRenderer>())
					g.GetComponent<MeshRenderer>().enabled = false;
				if (g.GetComponent<SkinnedMeshRenderer>())
					g.GetComponent<SkinnedMeshRenderer>().enabled = false;
			}
			return;
		};
		turnInvisible(other);
		inGrassObjects.Remove(other.gameObject);
	}
}
