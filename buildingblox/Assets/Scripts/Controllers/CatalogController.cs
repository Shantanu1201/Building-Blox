using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogController : MonoBehaviour
{
	#region -------------------------------------- Private Variables --------------------------------------
    
    [SerializeField]
    private SlotController slotController;
    private int currentSlot;
    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Public Variables --------------------------------------
    public List<ItemView> itemViews;   
    [HideInInspector]
    public List<GameObject> CatalogList;
    public ScrollRect itemScrollRect;
    public GameObject itemPrefab;
    public GameObject catalog;
    public GameObject backgroundPanel;
    public GameObject joystickContainerPanel;
    
    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Private Methods --------------------------------------
    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Public Methods --------------------------------------
    
    public void GenerateCatalog(ObjectModel currentObject,List<ObjectModel> items,int slotID,bool locked)
    {
        currentSlot=slotID;        
        bool flag=false;
        int lockedViewIndex=new int();
        for(int i=0;i<items.Count;i++)
        {                        
            CatalogList.Add(Instantiate(itemPrefab,itemScrollRect.content.transform) as GameObject);
            itemViews.Add(CatalogList[i].GetComponent<ItemView>());            
            itemViews[i].UpdateItem(items[i],i);            
            if(locked){
                if(items[i].id==currentObject.id){
                    itemViews[i].Lock(true);                    
                    lockedViewIndex=i;
                    flag=true;
                }
            }                      
        }
        if(flag){
            DisableOthers(lockedViewIndex,true);
        }
        catalog.SetActive(true);
        backgroundPanel.SetActive(true);
        IsUIOver.isUiOn=true;
    }

    public void UpdateLocks(ObjectModel objectModel)
    {

    }

    public void DisableOthers(int index,bool locked){
        if(locked){
            for(int i=0;i<itemViews.Count;i++){
                if(i!=index)                
                    itemViews[i].DisablePanel(true);
            }
        }
        else{
            for(int i=0;i<itemViews.Count;i++)
                itemViews[i].DisablePanel(false);
        }
    }

    public void CloseInfoPanel(int index){
        for(int i=0;i<itemViews.Count;i++)
        {
            if(i!=index)
                itemViews[i].CloseInfoPanel();
        }
    }
    public void ReplaceItem(ObjectModel objectModel,bool locked){        
        if(locked)
            slotController.UpdateSlotView(currentSlot,objectModel,locked,SlotStatus.Lock);
        else
            slotController.UpdateSlotView(currentSlot,objectModel,locked,SlotStatus.Set);                            
        EmptyCatalog();
    }
    
    public void SetLock(bool lockStatus){
        slotController.LockSlot(currentSlot,lockStatus);
    }

    public void EmptyCatalog()
    {
        if(!joystickContainerPanel.activeInHierarchy)
        {
            joystickContainerPanel.SetActive(true);
        }
        catalog.SetActive(false);
        IsUIOver.isUiOn=false;
        for(int i=0;i<CatalogList.Count;i++){
            Destroy(CatalogList[i]);            
        }
        CatalogList.Clear();
        itemViews.Clear();
    }
    #endregion----------------------------------------------------------------------------
}
