using Photon.Pun;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameSetupController : MonoBehaviourPun, IPunObservable
{

	public PhotonView photonView;

	public IDictionary<int, GameObject> players;

	public Transform[] spawns;

	// Start is called before the first frame update
	void Start()
    {
		players = new Dictionary<int, GameObject>();
		photonView = gameObject.AddComponent<PhotonView>();
		photonView.ViewID = 1;
		CreatePlayer();
		//Send message
		photonView.RPC("SendChat", RpcTarget.All, PhotonNetwork.LocalPlayer, "test");
		
	}

	public void SendMessage(params object[] messages)
	{
		photonView.RPC("SendChat", RpcTarget.All, PhotonNetwork.LocalPlayer, messages);
	}

	[PunRPC]
	void SendChat(Photon.Realtime.Player sender, string message)
	{
		Debug.Log(string.Format("{0} {1} {2} {3} {4}", sender.IsLocal, sender.UserId, sender.IsMasterClient, sender.NickName, sender.HasRejoined));
		Debug.Log(message);
	}

	[PunRPC]
	void SendChat(Photon.Realtime.Player sender, object[] directions)
	{
		
		if (sender.IsLocal)
			return;

		Debug.Log(string.Format("{0} {1} {2} {3} {4} {5}", sender.IsLocal, sender.UserId, sender.IsMasterClient, sender.NickName, sender.HasRejoined, sender.ActorNumber));
		Debug.Log(string.Format("x: {1}  z: {1}", directions[0], directions[1]));

		players[sender.ActorNumber].transform.position = new Vector3((float) directions[0], 1, (float) directions[1]);
	}

	private void CreatePlayer()
	{
		Debug.Log("Creating Player");
		Vector3 spawn;
		int playersInRoom = PhotonNetwork.CurrentRoom.Players.Keys.Count;
		spawn = spawns[playersInRoom % 2].position;
		spawn.z += playersInRoom % 4;
		GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), spawn, Quaternion.identity);
		
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		Debug.Log(stream);
		Debug.Log(info);
	}
}
