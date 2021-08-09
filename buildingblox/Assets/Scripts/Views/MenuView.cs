using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperBlur;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public enum GameMode
{
    EDIT_MODE,
    VIEW_MODE,
    VR_MODE
}
public class MenuView : MonoBehaviour
{

    #region -------------------------------------- Private Variables --------------------------------------
    [SerializeField]
    private RecomendationController recomendationController;
    public GameObject costUI;
    public GameObject catalogUI;
    public CostController costController;

    [SerializeField]
    private Button feelingLucky;

    [SerializeField]
    private Button modify;
    private GameMode gameMode = GameMode.EDIT_MODE;

    [SerializeField]
    public GameObject joystickPanel;


    [SerializeField]
    private Button startFromScratch;
   
   
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject slotViewPanel;
    [SerializeField]
    private GameObject editModeUI;
    [SerializeField]
    private GameObject loadingPanel;
    [SerializeField]
    private GameObject logoPanel;
    [SerializeField]
    private GameObject menuButtons;
    [SerializeField]
    private GameObject objectSelectUI;
    [SerializeField]
    private GameObject ExitButton;
    [SerializeField]
    private GameObject exitPanel;
    [SerializeField]
    private GameObject vrPointer;
    [SerializeField]
    private GameObject vrStuff;
    [SerializeField]
    private SuperBlurBase superBlur;
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Variables --------------------------------------
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Private Methods --------------------------------------

    private void Start()
    {
        modify.interactable = false;
    }

    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Methods --------------------------------------
    bool firstTime = true;
    private IEnumerator FakeLoader()
    {
        while (superBlur.interpolation > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            superBlur.interpolation -= Time.deltaTime;
            if (superBlur.interpolation < 0)
                superBlur.interpolation = 0;
            if (superBlur.iterations >= 1)
                superBlur.iterations -= 1;
        }
        superBlur.enabled = false;
        loadingPanel.SetActive(false);
    }
    public void OnFeelingLuckyClick()
    {
        if(firstTime)
        {
            modify.interactable = true;
            firstTime = false;
            logoPanel.SetActive(false);
            loadingPanel.SetActive(true);
            StartCoroutine(FakeLoader());
        }
        recomendationController.FeelingLucky();
    }

    public void OnClickStartFromScratch()
    {
        StartCoroutine(FakeLoader());
        recomendationController.StartFromScratch();
        FakeLoading();
    }

    public void OnClickModify()
    {
        FakeLoading();
    }

    public void EnableView()
    {
        gameMode = GameMode.VIEW_MODE;
        objectSelectUI.SetActive(false);
        editModeUI.SetActive(false);
    }

    public void FakeLoading()
    {
        joystickPanel.SetActive(true);
        logoPanel.SetActive(false);
        menuButtons.SetActive(false);
        editModeUI.SetActive(true);
        ExitButton.SetActive(true);
        slotViewPanel.SetActive(true);
    }

    public void OnExitClickYes()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadSceneAsync("buildingblox");
    }
    public void OnExitClickNo()
    {
        if(!joystickPanel.activeInHierarchy)
        {
            joystickPanel.SetActive(true);
        }
       IsUIOver.isUiOn=false;
    }

    public void OnVRView()
    {
        if (XRSettings.loadedDeviceName == "Cardboard")
        {
            StartCoroutine(LoadDevice("None"));
            Debug.Log("none vr");
        }
        else
        {
            editModeUI.SetActive(false);
            vrStuff.SetActive(true);
            vrPointer.SetActive(true);
            StartCoroutine(LoadDevice("Cardboard"));
            Debug.Log("VR cardboard");
        }
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }

    public void OnExitClick()
    {
        if (gameMode == GameMode.VIEW_MODE)
        {
            editModeUI.SetActive(true);
            objectSelectUI.SetActive(true);
            gameMode = GameMode.EDIT_MODE;
        }
        else if (gameMode == GameMode.EDIT_MODE)
        {
            if(costUI.activeInHierarchy)
            {
                costUI.SetActive(false);
                costController.EmptyCostList();
            }
            exitPanel.SetActive(true);  
        }
        else if (gameMode == GameMode.VR_MODE)
        {
            editModeUI.SetActive(true);
            objectSelectUI.SetActive(true);
            gameMode = GameMode.EDIT_MODE;
        }
    }
    #endregion----------------------------------------------------------------------------
}
