using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using Photon.Pun;
//using Photon.Realtime;
//using PN = Photon.Pun.PhotonNetwork;

public class UiManager : MonoBehaviour //GameManager
{

    #region elements

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

    protected GameObject FindElement(string path)
    {
        return Instantiate(Resources.Load<GameObject>($"Prefabs/UI/{path}"), canvasOBJ.transform);
    }

    protected virtual GameObject FindElement(GameObject parent, string name)
    {
        return parent.transform.Find(name).gameObject;
    }

    protected virtual Button SetButton(GameObject parent, string name)
    {
        return parent.transform.Find(name).GetComponent<Button>();
    }

    public void Init()
    {
        DontDestroyOnLoad(this);

        sceneUICanvas  = GetComponentInChildren<Canvas>();
        canvasOBJ      = sceneUICanvas.gameObject;

        loaddingPanel  = FindElement("LoadingPanel");

        titlePanel     = FindElement("TitlePanel");
        lobbyPanel     = FindElement("LobbyPanel2");//Resources.Load<GameObject>("Prefabs/LobyPanel");
        lobbyMenuPanel = FindElement(lobbyPanel, "OptionMenus");

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
    }

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


    #region server
    public void OnConnectedToMaster()
    {
        loaddingPanel.SetActive(false);
    }

    #endregion

    #region button
    public void OnClickStartInTitle()
    {
        GameManager.instance.OnClickStartInTitle();
    }
    public void OnClickStartInLobby()
    {
        GameManager.instance.OnClickStartInLobby();
    }
    public void OnClickExit()
    {
        GameManager.instance.OnClickExit();
    }
    public void OnClickOption()
    {
        GameManager.instance.OnClickOption();
    }
    public void OnClickInfo()
    {
        GameManager.instance.OnClickInfo();
    }
    public void OnClickMaker()
    {
        GameManager.instance.OnClickMaker();
    }
    #endregion

    public void ShowUI(Scene nowScene)
    {
        titlePanel.SetActive(nowScene == Scene.title);
        lobbyPanel.SetActive(nowScene == Scene.lobby);

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