using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiTest : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.NickName = "1";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("OnLine");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("OnLobby");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("CreateRoom");

        PhotonNetwork.JoinRandomOrCreateRoom(
            null, 2, Photon.Realtime.MatchmakingMode.FillRoom,
            null, null, "firstRoom",
            new Photon.Realtime.RoomOptions { MaxPlayers = 2 });

        Debug.Log("CreateRoom");
        Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Faild");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
        Debug.Log("Start");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.Disconnect();
            Debug.Log("Exit");
        }
    }
}
