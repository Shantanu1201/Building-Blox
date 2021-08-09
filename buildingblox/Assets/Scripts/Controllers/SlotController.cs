using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    #region -------------------------------- Private Variables --------------------
    #endregion----------------------------------------------------------------

    #region -------------------------------- Public Variables ---------------------

    public int lastChangedView;
    public SlotView[] slotViews;
    public bool[] slotLocks;    
    public SlotStatus[] slotStatus;
    public RecomendationController recommendationController;
    public CatalogController catalogController;
    public CostController costController;
    public Material holoMat;

    #endregion----------------------------------------------------------------

    #region -------------------------------- Private Methods ----------------------
    private void Start(){
        slotLocks=new bool[slotViews.Length];
        slotStatus=new SlotStatus[slotViews.Length];
        for(int i=0;i<slotLocks.Length;i++){
            slotLocks[i]=false;
            slotStatus[i]=SlotStatus.Unset;
        }
    }

    #endregion----------------------------------------------------------------

    #region -------------------------------- Public Methods ---------------------

    public void UpdateSlotView(int slotID, ObjectModel obj,bool locked=false,SlotStatus status=SlotStatus.Unset)
    {
        for (int i = 0; i < slotViews.Length; i++)
        {               
            if (slotViews[i].getSlotIndex() == slotID)
            {
                if(slotLocks[i])
                    break;                
                slotLocks[i]=locked;        
                slotStatus[i]=status;        
                slotViews[i].UpdateSlotModel(obj,locked,status);
                slotViews[i].OnDeactivateUI();
                break;                
            }
        }
        costController.UpdateCost(slotViews);
    }

    public void StartFromScratch(){
        for(int i=0;i<slotViews.Length;i++){            
            Debug.Log(slotViews[i].GetObjectModel().name);
            if(slotViews[i].getSlotIndex()==(int)SlotIndex.floor){
                ObjectModel temp=slotViews[i].GetObjectModel();
                temp.texture="Floor7";                
                slotViews[i].UpdateSlotModel(temp);
            }

            else if(slotViews[i].getSlotIndex()==(int)SlotIndex.wall){
                ObjectModel temp=slotViews[i].GetObjectModel();
                temp.texture="Cream";
                slotViews[i].UpdateSlotModel(temp);                    
            }
            else if(slotViews[i].getSlotIndex()==(int)SlotIndex.featurewall){
                ObjectModel temp=slotViews[i].GetObjectModel();
                temp.texture="Cream";
                slotViews[i].UpdateSlotModel(temp);
            }
            
            else{
                slotViews[i].UpdateMaterial(holoMat);
            }
        }

    }

    public void LoadCatalog(ObjectModel objectModel,int slotID)
    {               
        recommendationController.GenerateCatalogList(objectModel,slotID,slotLocks[slotID]);
    }

    public void LockSlot(int slotID,bool lockStatus){
        Debug.Log("Slot "+slotID+" is "+(lockStatus?"Locked":"Unlocked"));
        slotLocks[slotID]=lockStatus;
        for (int i = 0; i < slotViews.Length; i++)
        {               
            if (slotViews[i].getSlotIndex() == slotID)
            {
                slotViews[i].UpdateSlotIcon(lockStatus?SlotStatus.Lock:SlotStatus.Set);
            }
        }
    }

    public void LoadCostList(){
        costController.GenerateCostList(slotViews);
    }
    
    public void EmptyCostList(){
        costController.EmptyCostList();
    }
    public void UpdateLastChangedView(int viewIndex)
    {

    }

    #endregion----------------------------------------------------------------
}