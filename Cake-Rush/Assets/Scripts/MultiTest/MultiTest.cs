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
        Debug.Log("OnLobby");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("CreateRoom");


        Debug.Log("CreateRoom");
        PhotonNetwork.JoinRandomOrCreateRoom(
            null, 2, Photon.Realtime.MatchmakingMode.FillRoom,
            null, null, "firstRoom",
            new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Faild");
        //Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
    }

    public override void OnCreatedRoom()
    {
        //Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
        Debug.Log("Start");
    }
}
