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

    public static UiManager instance = null;

    public enum Scene
    {
        title, loby, inGame, victory, defeat
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
    private GameObject lobyPanelResource;
    private GameObject titlePanel;
    private GameObject lobyPanel;

    private Button titleStartButton;
    private Button optionButton;
    private Button exitButton;

    #endregion

    private void Awake()
    {
        /// Load패널먼저 로드해서 가시화(Setactive(true)를 해주고 아래 코드 실행

        titlePanelResource = Resources.Load<GameObject>("Prefabs/TitlePanel");
        lobyPanelResource = Resources.Load<GameObject>("Prefabs/LobyPanel");

        sceneUICanvas = GetComponentInChildren<Canvas>();
        canvasOBJ = sceneUICanvas.gameObject;
        titlePanel = Instantiate(titlePanelResource, canvasOBJ.transform);
        lobyPanel = Instantiate(lobyPanelResource, canvasOBJ.transform);
        
        titleStartButton = titlePanel.transform.Find("StartButton").GetComponent<Button>();
        optionButton = titlePanel.transform.Find("OptionButton").GetComponent<Button>();
        exitButton = titlePanel.transform.Find("ExitButton").GetComponent<Button>();
    }

    private void Start()
    {
        titleStartButton.onClick.AddListener(OnClickStartInTitle);
        exitButton.onClick.AddListener(OnClickExit);
        optionButton.onClick.AddListener(OnClickOption);

        SetScene("title");

        ///여기서 로딩 패널 비가시화
    }

    public void OnClickStartInTitle()
    {
        Debug.Log("ClickStart");
        PN.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected server");
        PN.JoinLobby();
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

    public void OnClickExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }

    public void OnClickMaker()
    {
        Debug.Log("Maker");
    }

    public void SetScene(string targetScene)
    {
        if (targetScene.Equals("title"))
        {
            PN.Disconnect();
            nowScene = Scene.title;
        }
        if (targetScene.Equals("loby"))
        {
            nowScene = Scene.loby;
        }
        if (targetScene.Equals("inGame"))
        {
            nowScene = Scene.inGame;
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
        lobyPanel.SetActive(nowScene == Scene.loby);
        
    }

    public override void OnJoinedLobby()
    {
        SetScene("loby");
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