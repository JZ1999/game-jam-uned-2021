using Photon.Pun;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameSetupController : MonoBehaviourPun, IPunObservable
{

	public PhotonView photonView;

	public IDictionary<int, GameObject> players;

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
		Debug.Log(string.Format("{0} {1} {2} {3} {4}", sender.IsLocal, sender.UserId, sender.IsMasterClient, sender.NickName, sender.HasRejoined));
		Debug.Log(string.Format("h: {1}  v: {1}", directions[0], directions[1]));
		if (sender.IsLocal)
			return;

		TestMovement.Move(players[sender.ActorNumber], 1, (float) directions[0], (float) directions[1]);
	}

	private void CreatePlayer()
	{
		Debug.Log("Creating Player");
		GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		Debug.Log(stream);
		Debug.Log(info);
	}
}
