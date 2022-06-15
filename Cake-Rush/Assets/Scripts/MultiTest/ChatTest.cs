using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ChatTest : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject inputBox;
    [SerializeField]
    private GameObject[] textBoxs;
    [SerializeField]
    private TMP_InputField input;
    [SerializeField]
    private GameObject scrollView;
    [SerializeField]
    private TMP_Text[] texts = new TMP_Text[5];
    private int maxLenght = 5;
    private bool isChat;
    PhotonView PV;

    private void Start()
    {
        isChat = false;
        for(int i = 0; i < maxLenght; i++)
        {
            texts[i] = textBoxs[i].GetComponent<TMP_Text>();
        }
        input = inputBox.GetComponent<TMP_InputField>();
        inputBox.SetActive(false);
        scrollView.SetActive(false);
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(!isChat)
            {
                isChat = true;
                inputBox.SetActive(true);
                scrollView.SetActive(true);
                //input.Select();
                input.ActivateInputField();
            }
            else
            {
                if(input.text == "")
                {
                    input.Select();
                    isChat = false;
                    inputBox.SetActive(false);
                    scrollView.SetActive(false);
                    return;
                }
                else
                {
                    PV.RPC("Chat", RpcTarget.All, $"{PhotonNetwork.LocalPlayer.NickName} : {input.text}");
                    input.text = "";
                    Debug.Log("Chat");
                    input.ActivateInputField();
                }
            }
        }
    }


    [PunRPC]
    void Chat(string str)
    {
        for (int i = maxLenght - 1; i > 0; i--)
        {
            texts[i].text = texts[i - 1].text;
        }
        texts[0].text = str;
    }
}
