using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{

	public GameObject quickStartButton;
	public GameObject quickCancelButton;
	public int roomSize;

	public override void OnConnectedToMaster()
	{
		base.OnConnectedToMaster();
		Debug.Log("Connected " + PhotonNetwork.CloudRegion);
		PhotonNetwork.AutomaticallySyncScene = true;
		quickStartButton.SetActive(true);
	}

	public void QuickStart()
	{
		quickStartButton.SetActive(false);
		quickCancelButton.SetActive(true);
		PhotonNetwork.JoinRandomRoom();
	}

	// Start is called before the first frame update
	void Start()
    {
		PhotonNetwork.ConnectUsingSettings();
    }

	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		base.OnJoinRandomFailed(returnCode, message);
		Debug.Log("Failed to join room returnCode: "+returnCode+" message: "+message);
		CreateRoom();
	}

	void CreateRoom()
	{
		Debug.Log("Creating room");
		int randomRoomNumber = Random.Range(0, 10_000);
		RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte) roomSize };
		PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOptions);
		Debug.Log(randomRoomNumber);
	}

	public override void OnCreateRoomFailed(short returnCode, string message)
	{
		base.OnCreateRoomFailed(returnCode, message);
		CreateRoom();
	}

	public void QuickCancel()
	{
		quickCancelButton.SetActive(false);
		quickStartButton.SetActive(true);
		PhotonNetwork.LeaveRoom();
	}
}
