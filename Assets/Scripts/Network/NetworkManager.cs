using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("alpha 0.01");
	}
	
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
		
	}
	
	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}
	
	void OnJoinedRoom()
	{
		GameObject myShip = PhotonNetwork.Instantiate("Ship1", Vector3.zero, Quaternion.identity, 1);
	}
}
