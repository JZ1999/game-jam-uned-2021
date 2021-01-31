using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInteraction : MonoBehaviour
{

	public List<GameObject> inventory = new List<GameObject>();
	public List<GameObject> baseInventory = new List<GameObject>();
	public GameObject specialEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void loseAGem() {

		GameObject gem = inventory[0];
		if (inventory.Contains(gem))
		{
			inventory.Remove(gem);
			gem.transform.position = gem.GetComponent<GemMovement>().spawn.position;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Gem"))
		{
			other.gameObject.SetActive(false);
			inventory.Add(other.gameObject);
			if (baseInventory.Contains(other.gameObject))
			{
				baseInventory.Remove(other.gameObject);
			}
			Instantiate(specialEffect, transform.position, Quaternion.identity);
		}else if(other.CompareTag("Base"))
		{
			foreach (GameObject gem in inventory)
			{
				Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };

				gem.transform.position = other.transform.position + directions[Random.Range(0,4)] * baseInventory.Count * 2;
				gem.SetActive(true);
				baseInventory.Add(gem);
				if (inventory.Contains(gem))
				{
					inventory.Remove(gem);
				}
				
			}
			
		}
	}
}
