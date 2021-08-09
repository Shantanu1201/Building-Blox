using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPick : MonoBehaviour
{
    #region -------------------------------------- Private Variables --------------------------------------
    private Material currMat;
    private Renderer color;
    #endregion----------------------------------------------------------------------------

    #region -------------------------------------- Public Variables --------------------------------------
    public List<Material> materialColor;
    public MouseDetector detect;
    #endregion----------------------------------------------------------------------------

    #region -------------------------------------- Private Methods --------------------------------------
    void Start()
    {
        color = this.GetComponent<Renderer>();
    }
    void ApplyColor(int colorIndex)
    {
        color.material = materialColor[colorIndex];
        currMat = color.material;
        detect.OnDeactivatePanel();
    }
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Methods --------------------------------------
    public void OnMaterialClick(int index)
    {
        if (IsUIOver.isUiOn)
        {
            ApplyColor(index);
        }
    }
    #endregion----------------------------------------------------------------------------
}
