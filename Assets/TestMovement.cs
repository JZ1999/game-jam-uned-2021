using UnityEngine;
using Photon.Pun;


public class TestMovement : MonoBehaviour
{

	public float speed;                //Floating point variable to store the player's movement speed.

	private Rigidbody rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

	private GameSetupController gameController;

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody>();
		gameController = FindObjectOfType<GameSetupController>();
		gameController.players.Add(GetComponent<PhotonView>().OwnerActorNr, gameObject);
		foreach (int p in gameController.players.Keys)
			Debug.Log(string.Format("({2}) Key: {0}, Value: {1}", p, gameController.players[p], gameController.players[p].GetComponent<PhotonView>().isMine));
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		if (!GetComponent<PhotonView>().isMine)
			return;
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis("Vertical");
		Move(gameObject, speed, moveHorizontal, moveVertical);

		if (moveHorizontal != 0f || moveVertical != 0f)
		{
			Debug.Log(gameController);
			Debug.Log(gameController.GetComponent<GameSetupController>());
			gameController.GetComponent<GameSetupController>().SendMessage(moveHorizontal, moveVertical);
		}
	}

	static public void Move(GameObject g, float speed, float moveHorizontal, float moveVertical)
	{
		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector3(moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		g.GetComponent<Rigidbody>().AddForce(movement * speed);
	}
}