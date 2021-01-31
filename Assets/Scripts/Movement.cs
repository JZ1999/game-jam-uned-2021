using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	protected int velocity = 1000;
	private Camera cam;
    private Vector3 posWorld;

	public GameObject pivotPrefab;
    private Transform pivot;

	private GameSetupController gameController;

	private float[] pastPositionXZ = { 0, 0 };

    public bool isClick = false;

	public ParticleSystem system;

	// Use this for initializations
	void Awake()
	{

		system = GetComponentInChildren<ParticleSystem>();

		gameController = FindObjectOfType<GameSetupController>();
		gameController.players.Add(GetComponent<PhotonView>().OwnerActorNr, gameObject);

        if (GetComponent<PhotonView>().isMine)
            FindObjectOfType<Camera>().GetComponent<CamaraMovement>().enabled = true;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == pivot)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {

		if (!GetComponent<PhotonView>().isMine)
			return;

		if(pastPositionXZ[0] != transform.position.x || pastPositionXZ[1] != transform.position.z)
		{
			gameController.GetComponent<GameSetupController>().SendMessage(transform.position.x, transform.position.z);
			if(!system.isPlaying)
			{
				system.Play();
			}
		}


        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
        }else if(Input.GetMouseButtonUp(0)){
            isClick = false;
        }// Pulsamos el botón izquierdo del ratón

        if(isClick){RaycastHit hit;

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