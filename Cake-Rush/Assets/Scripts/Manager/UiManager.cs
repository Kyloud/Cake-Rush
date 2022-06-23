using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;
using PN = Photon.Pun.PhotonNetwork;

public class UiManager : MonoBehaviourPunCallbacks
{

    #region elements

    public enum Scene
    {
        title, lobby, inGame, victory, defeat
    };

    public Scene nowScene;

    private Image infoImage;
    private Image mapImage;

    private Text playTimeText;
    private Text unitSizeText;
    private Text eventText;
    private Text curCost;

    private PlayerController player;

    private Canvas sceneUICanvas;
    private GameObject canvasOBJ;
    private GameObject titlePanel;
    private GameObject lobbyPanel;
    private GameObject lobbyMenuPanel;
    private GameObject commandPanel;
    private GameObject loaddingPanel;

    private Button startInTitle;
    private Button optionInTitle;
    private Button exitInTitle;

    private Button startInLobby;
    private Button optionInLobby;
    private Button exitInLobby;
    private Button infoInLobby;

    private Button skillCokeShot;
    private Button skillCakeRush;
    private Button skillShotingStar;
    private Button skillLightning;

    #endregion

    #region find Function
    GameObject FindElement(string path)

    {
        return Instantiate(Resources.Load<GameObject>($"Prefabs/UI/{path}"), canvasOBJ.transform);
    }

    GameObject FindElement(GameObject parent, string name)
    {
        return parent.transform.Find(name).gameObject;
    }

    Button SetButton(GameObject parent, string name)
    {
        return parent.transform.Find(name).GetComponent<Button>();
    }
    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this);

        sceneUICanvas  = GetComponentInChildren<Canvas>();
        canvasOBJ      = sceneUICanvas.gameObject;

        loaddingPanel  = FindElement("LoadingPanel");

        titlePanel     = FindElement("TitlePanel");
        lobbyPanel     = FindElement("LobbyPanel2");//Resources.Load<GameObject>("Prefabs/LobyPanel");
        lobbyMenuPanel = FindElement(lobbyPanel, "OptionMenus");
        //commandPanel   = FindElement("CommandPanel");

        startInTitle  = SetButton(titlePanel, "StartButton");
        optionInTitle = SetButton(titlePanel, "OptionButton");
        exitInTitle   = SetButton(titlePanel, "ExitButton");

        startInLobby  = SetButton(lobbyPanel, "StartButton");
        optionInLobby = SetButton(lobbyMenuPanel, "OptionButton");
        exitInLobby   = SetButton(lobbyMenuPanel, "ExitButton");
        infoInLobby   = SetButton(lobbyMenuPanel, "InfoButton");

        //skillCokeShot    = SetButton(commandPanel, "CokeShot");
        //skillCakeRush    = SetButton(commandPanel, "CakeRush");
        //skillShotingStar = SetButton(commandPanel, "ShotingStar");
        //skillLightning   = SetButton(commandPanel, "Lightning");



        loaddingPanel.transform.SetAsLastSibling();
    }

    private void Start()
    {
        startInTitle.onClick.AddListener(OnClickStartInTitle);
        exitInTitle.onClick.AddListener(OnClickExit);
        optionInTitle.onClick.AddListener(OnClickOption);

        startInLobby.onClick.AddListener(OnClickStartInLobby);
        exitInLobby.onClick.AddListener(OnClickExit);
        optionInLobby.onClick.AddListener(OnClickOption);
        infoInLobby.onClick.AddListener(OnClickInfo);

        //skillCakeRush.onClick.AddListener(OnClickCakeRush);
        //skillShotingStar.onClick.AddListener(OnClickShotingStar);
        //skillCokeShot.onClick.AddListener(OnClickCokeShot);
        //skillLightning.onClick.AddListener(OnClickLightning);

        SetScene("title");//inGame");
    }


    #region Scene or Server

    public override void OnCreatedRoom()
    {
        Debug.Log("In Room");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("new Player");
        if (PN.CurrentRoom.MaxPlayers == PN.CurrentRoom.PlayerCount)
        {
            Debug.Log("Game Start");
            //PN.Disconnect();
            SetScene("inGame");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected server");

        loaddingPanel.SetActive(false);
    }

    /// discard될 경우 이유
    public override void OnDisconnected(DisconnectCause cause)
    {
        switch(cause)
        {
            case DisconnectCause.None:
                Debug.Log("None");
                break;

            case DisconnectCause.DisconnectByDisconnectMessage:
                Debug.Log("DisconnectByDisconnectMessage");
                break;

            case DisconnectCause.OperationNotAllowedInCurrentState:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.DisconnectByClientLogic:
                Debug.Log("플레이어가 직접 끈 경우");

                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
                    Application.Quit();
                break;

            case DisconnectCause.DisconnectByOperationLimit:
                Debug.Log("DisconnectByOperationLimit");
                break;

            default:
                Debug.Log("what?");
                break;
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("is Loby");
        SetScene("loby");
    }

    public override void OnJoinedRoom()
    {
        if (PN.CurrentRoom.MaxPlayers == PN.CurrentRoom.PlayerCount)
        {
            Debug.Log("Game Start");
            SetScene("inGame");
        }
    }
    #endregion

    #region button
    public void OnClickStartInTitle()
    {
        Debug.Log("ClickStart");
        if (PN.IsConnected)
        {
            PN.JoinLobby();
        }
    }

    public void OnClickStartInLobby()
    {
        Debug.Log("Click Create Room or Join Room");
        PN.JoinRandomOrCreateRoom(
            null, 2, Photon.Realtime.MatchmakingMode.FillRoom,
            null, null, $"{Random.Range(0, 100)}", new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public void OnClickExit()
    {
        if (PN.IsConnected)
            PN.Disconnect();
    }
    public void OnClickOption()
    {
        Debug.Log("Option");
    }

    public void OnClickInfo()
    {
        Debug.Log("Infomation of it");
    }

    public void OnClickMaker()
    {
        Debug.Log("Maker");
    }
    #endregion

    #region skill



    public void OnClickShotingStar()
    {

    }

    public void OnClickLightning()
    {

    }

    public void OnClickCokeShot()
    {

    }

    public void OnClickCakeRush()
    {

    }
    #endregion

    public void SetScene(string targetScene)
    {
        if (targetScene.Equals("title"))
        {
            if(!PN.IsConnected)
            {
                PN.ConnectUsingSettings();
            }
            nowScene = Scene.title;
        }
        if (targetScene.Equals("loby"))
        {
            nowScene = Scene.lobby;
        }
        if (targetScene.Equals("inGame"))
        {
            nowScene = Scene.inGame;
            SceneManager.LoadScene("InGame");
        }
        if (targetScene.Equals("victory"))
        {
            nowScene = Scene.victory;
        }
        if (targetScene.Equals("defeat"))
        {
            nowScene = Scene.defeat;
        }

        titlePanel.SetActive(nowScene == Scene.title);
        lobbyPanel.SetActive(nowScene == Scene.lobby);
        //commandPanel.SetActive(nowScene == Scene.inGame);

    }


    // If select entity, on UI
    void SetUI()
    {

    }

    // Event notice method. use Fade in/out
    void Notice()
    {

    }
}