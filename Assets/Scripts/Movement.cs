using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public int velocity = 200;
	private Camera cam;
    private Vector3 posWorld;

	public GameObject pivotPrefab;
    private Transform pivot;

	private GameSetupController gameController;

	private float[] pastPositionXZ = { 0, 0 };

	// Use this for initializations
	void Start()
    {
		gameController = FindObjectOfType<GameSetupController>();
		gameController.players.Add(GetComponent<PhotonView>().OwnerActorNr, gameObject);

		foreach (int p in gameController.players.Keys)
			Debug.Log(string.Format("({2}) Key: {0}, Value: {1}", p, gameController.players[p], gameController.players[p].GetComponent<PhotonView>().isMine));

		pastPositionXZ[0] = transform.position.x;
		pastPositionXZ[1] = transform.position.z;

		pivot = Instantiate(pivotPrefab).transform;
        cam = Camera.main;
        posWorld = pivot.position;
        transform.LookAt(transform); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

		if (!GetComponent<PhotonView>().isMine)
			return;

		if(pastPositionXZ[0] != transform.position.x || pastPositionXZ[1] != transform.position.z)
		{
			gameController.GetComponent<GameSetupController>().SendMessage(transform.position.x, transform.position.z);
		}

        
        if (Input.GetMouseButtonDown(0))
        {  // Pulsamos el botón izquierdo del ratón
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                posWorld = hit.point;
                pivot.position = posWorld;
                transform.LookAt(pivot.transform);
                GetComponent<Rigidbody>().velocity = (transform.forward) * velocity * Time.fixedDeltaTime;
			}
            
        }
    
    }
}