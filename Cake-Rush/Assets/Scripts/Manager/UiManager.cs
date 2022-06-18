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
    private GameObject titlePanelResource;
    private GameObject lobbyPanelResource;
    private GameObject titlePanel;
    private GameObject lobbyPanel;
    private GameObject lobbyMenuPanel;

    private Button startButtonInTitle;
    private Button optionButtonInTitle;
    private Button exitButtonInTitle;

    private Button startButtonInLobby;
    private Button optionButtonInLobby;
    private Button exitButtonInLobby;
    private Button infoButtonInLobby;

    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this);

        /// Load패널먼저 로드해서 가시화(Setactive(true)를 해주고 아래 코드 실행

        titlePanelResource = Resources.Load<GameObject>("Prefabs/TitlePanel");
        lobbyPanelResource = Resources.Load<GameObject>("Prefabs/LobbyPanel2"); //Resources.Load<GameObject>("Prefabs/LobyPanel");

        sceneUICanvas = GetComponentInChildren<Canvas>();
        canvasOBJ = sceneUICanvas.gameObject;
        titlePanel = Instantiate(titlePanelResource, canvasOBJ.transform);
        lobbyPanel = Instantiate(lobbyPanelResource, canvasOBJ.transform);

        startButtonInTitle = titlePanel.transform.Find("StartButton").GetComponent<Button>();
        optionButtonInTitle = titlePanel.transform.Find("OptionButton").GetComponent<Button>();
        exitButtonInTitle = titlePanel.transform.Find("ExitButton").GetComponent<Button>();

        startButtonInLobby = lobbyPanel.transform.Find("StartButton").GetComponent<Button>();
        lobbyMenuPanel = lobbyPanel.transform.Find("OptionMenus").gameObject;
        optionButtonInLobby = lobbyMenuPanel.transform.Find("OptionButton").GetComponent<Button>();
        exitButtonInLobby = lobbyMenuPanel.transform.Find("ExitButton").GetComponent<Button>();
        infoButtonInLobby = lobbyMenuPanel.transform.Find("InfoButton").GetComponent<Button>();
    }

    private void Start()
    {
        startButtonInTitle.onClick.AddListener(OnClickStartInTitle);
        exitButtonInTitle.onClick.AddListener(OnClickExit);
        optionButtonInTitle.onClick.AddListener(OnClickOption);

        startButtonInLobby.onClick.AddListener(OnClickStartInLobby);
        exitButtonInLobby.onClick.AddListener(OnClickExit);
        optionButtonInLobby.onClick.AddListener(OnClickOption);
        infoButtonInLobby.onClick.AddListener(OnClickInfo);

        SetScene("title");

        ///여기서 로딩 패널 비가시화
    }

    public void OnClickStartInTitle()
    {
        Debug.Log("ClickStart");
        if(PN.IsConnected)
        {
            PN.JoinLobby();
        }
    }

    public void OnClickStartInLobby()
    {
        Debug.Log("Click Create Room or Join Room");
        PN.JoinRandomOrCreateRoom(
            null, 2, Photon.Realtime.MatchmakingMode.FillRoom,
            null, null, $"{Random.Range(0, 100)}", new Photon.Realtime.RoomOptions{ MaxPlayers = 2 });
    }

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

            case DisconnectCause.ExceptionOnConnect:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.DnsExceptionOnConnect:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.ServerAddressInvalid:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.Exception:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.ServerTimeout:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.ClientTimeout:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.DisconnectByServerLogic:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.DisconnectByServerReasonUnknown:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.InvalidAuthentication:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.CustomAuthenticationFailed:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.AuthenticationTicketExpired:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.MaxCcuReached:
                Debug.Log("ExceptionOnConnect");
                break;

            case DisconnectCause.InvalidRegion:
                Debug.Log("ExceptionOnConnect");
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

    public void OnClickOption()
    {
        Debug.Log("Option");
    }

    public void OnClickInfo()
    {
        Debug.Log("Infomation of it");
    }

    public void OnClickExit()
    {
        if(PN.IsConnected)
            PN.Disconnect();
    }

    public void OnClickMaker()
    {
        Debug.Log("Maker");
    }

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
            //PN.Disconnect();
            SetScene("inGame");
        }
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