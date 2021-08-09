using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EditModeView : MonoBehaviour {

#region -------------------------------------- Private Variables --------------------------------------

[SerializeField]
private Text realTimeCost;
[SerializeField]
private RecomendationController recommendationController;
[SerializeField]
private SlotController slotController;
//public GameObject catalogUI;
public GameObject joystickContainerPanel;
public GameObject catalogUI;
public GameObject backgroundPanel;
public CatalogController catalogController;

private bool costPanelOpen=false;
#endregion----------------------------------------------------------------------------
#region -------------------------------------- Public Variables --------------------------------------
#endregion----------------------------------------------------------------------------
#region -------------------------------------- Private Methods --------------------------------------
#endregion----------------------------------------------------------------------------
#region -------------------------------------- Public Methods --------------------------------------

public void FeelingLucky(){
	recommendationController.FeelingLucky();
}

public void UpdateCost(string cost){
	realTimeCost.text=cost;
}

public void OpenCostPanel(){
	if(catalogUI.activeInHierarchy){
		catalogController.EmptyCatalog();
		catalogUI.SetActive(false);
		backgroundPanel.SetActive(false);
		slotController.LoadCostList();
		if(joystickContainerPanel.activeInHierarchy)
        	{
         	   joystickContainerPanel.SetActive(false);
       		}
		//IsUIOver.isUiOn=true;
		}
	else if(!costPanelOpen)
	{
		slotController.LoadCostList();
		if(joystickContainerPanel.activeInHierarchy)
        	{
         	   joystickContainerPanel.SetActive(false);
       		}
		IsUIOver.isUiOn=true;	   
	}
	else if (costPanelOpen)
	{	
		slotController.EmptyCostList();
		//backgroundPanel.SetActive(false);
		if(!joystickContainerPanel.activeInHierarchy)
        {
     	   joystickContainerPanel.SetActive(true);
   		}
		IsUIOver.isUiOn=false;		
	}
	costPanelOpen=!costPanelOpen;
}


#endregion----------------------------------------------------------------------------
}
