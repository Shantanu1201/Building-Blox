using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class IsUIOver
{
    public static bool isUiOn;
}*/

public class MouseDetector : MonoBehaviour
{
    #region -------------------------------------- Public Variable --------------------------------------
    public GameObject detector;
    public Camera playerCamera;
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Private Methods --------------------------------------
    void Start()
    {
        detector.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OnDeactivatePanel();
            
        }
    }
    void OnMouseDown()
    {
        if (!IsUIOver.isUiOn)
        {
            detector.SetActive(true);
        
            IsUIOver.isUiOn = true;
        }
    }
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Methods --------------------------------------
    public void OnDeactivatePanel()
    {
        detector.SetActive(false);
        IsUIOver.isUiOn = false;
    }
    #endregion----------------------------------------------------------------------------
}
