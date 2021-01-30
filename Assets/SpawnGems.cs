using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
	public GameObject[] gems;
	public Transform[] spawns;

	// Start is called before the first frame update
	void Start()
    {
		Shuffle.action(spawns);
		for (int i = 0; i < spawns.Length; i++)
		{
			Instantiate(gems[i], spawns[i]);
		}
    }
}
