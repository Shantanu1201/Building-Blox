using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CostController : MonoBehaviour
{
	#region -------------------------------------- Private Variables --------------------------------------
    private float currentCost=0;
    #endregion----------------------------------------------------------------------------

    #region -------------------------------------- Public Variables --------------------------------------
    [HideInInspector]
    public List<GameObject> itemSummaryList;
    public ScrollRect itemScrollRect;
    public GameObject itemDetailPrefab;
    public EditModeView editModeView;
    public List<CostView> costViews;
    public GameObject costDetailPanel;
    public Text finalCost;
    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Private Methods --------------------------------------
    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Public Methods --------------------------------------
    
    public void UpdateCost(SlotView[] viewList){
        currentCost=0;
        for(int i=0;i<viewList.Length;i++){
            currentCost+=viewList[i].GetObjectModel().cost;
        }
        finalCost.text= "₹ " + currentCost.ToString();
        editModeView.UpdateCost(currentCost.ToString());
    }

    public void GenerateCostList(SlotView[] viewList)
    {        
        for(int i=0;i<viewList.Length;i++)
        {
            itemSummaryList.Add(Instantiate(itemDetailPrefab,itemScrollRect.content.transform) as GameObject);
            costViews.Add(itemSummaryList[i].GetComponent<CostView>()); 
            costViews[i].UpdateCostRow(i+1,viewList[i].GetObjectModel());                        
        }
        costDetailPanel.SetActive(true);
    }

    public void EmptyCostList(){
        costDetailPanel.SetActive(false);
        for(int i=0;i<itemSummaryList.Count;i++){
            Destroy(itemSummaryList[i]);
        }
        itemSummaryList.Clear();
        costViews.Clear();
    }
    #endregion----------------------------------------------------------------------------
}
#region -------------------------------------- Private Variables --------------------------------------
#endregion----------------------------------------------------------------------------
#region -------------------------------------- Public Variables --------------------------------------
#endregion----------------------------------------------------------------------------
#region -------------------------------------- Private Methods --------------------------------------
#endregion----------------------------------------------------------------------------
#region -------------------------------------- Public Methods --------------------------------------
#endregion----------------------------------------------------------------------------