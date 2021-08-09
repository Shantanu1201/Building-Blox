using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostView : MonoBehaviour
{
    #region -------------------------------------- Private Variables --------------------------------------
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Variables --------------------------------------
    public Text itemIndex;
    public Text itemName;
    public Text itemCost;   
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Private Methods --------------------------------------
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Methods --------------------------------------
    public void UpdateCostRow(int index,ObjectModel objectModel){
        itemIndex.text=index.ToString();
        itemName.text=objectModel.name;
        itemCost.text="₹ " + objectModel.cost.ToString();
    }
    #endregion----------------------------------------------------------------------------
}
