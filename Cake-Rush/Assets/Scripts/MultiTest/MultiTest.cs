using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiTest : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.LocalPlayer.NickName = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnLine");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnLobby");

        Debug.Log("CreateRoom");
        PhotonNetwork.JoinRandomOrCreateRoom(
            null, 2, Photon.Realtime.MatchmakingMode.FillRoom,
            null, null, "firstRoom",
            new Photon.Realtime.RoomOptions { MaxPlayers = 2 });

        //PhotonNetwork.CreateRoom("testRoom", new Photon.Realtime.RoomOptions { MaxPlayers = 2 }, null, null);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Faild");
        PhotonNetwork.JoinRoom("testRoom", null);
        //Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Start");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.Instantiate("Prefabs/Units/Player", new Vector3(41, -9.536743e-06f, 40.4f), Quaternion.identity);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Start");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Entered");
        Debug.Log(newPlayer.NickName);
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        
    }
}
