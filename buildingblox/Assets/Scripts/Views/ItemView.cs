using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    #region -------------------------------------- Private Variables --------------------------------------
    private ObjectModel objectModel;
    private bool locked=false;
    private int thisViewIndex;
    private bool infoPanelOpen=false;
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Variables --------------------------------------
    public CatalogController catalogController;
    [Space]
    public GameObject infoPanel;
    public GameObject parentPanel;
    public Image itemImage;
    public Image lockImage;
    public GameObject disablePanel;
    public Button infoButton;
    public Button lockButton;
    public Button unlockButton;
    public Text itemName;
    public Text cost;
    public Text infoText;
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Private Methods --------------------------------------
    
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Public Methods --------------------------------------
    
    public void UpdateItem(ObjectModel objectModelCopy,int index)
    {
        thisViewIndex=index;
        if(objectModelCopy != null)
        {        
            catalogController=GameObject.FindObjectOfType<CatalogController>();
            objectModel = objectModelCopy;
            itemName.text=objectModel.name;
            cost.text="₹ " + objectModel.cost.ToString();            
            itemImage.sprite=Resources.Load<Sprite>("ItemsThumbnail/"+objectModel.thumbnail);            
        }

    }

    public void Lock(bool status){
        lockButton.gameObject.SetActive(!status);
        unlockButton.gameObject.SetActive(status);
        locked=status;       
    }
    
    public void OnLock(bool status){
        Lock(status);
        Debug.Log("status sent"+status);
        catalogController.DisableOthers(thisViewIndex,status);  
        if(status){
            catalogController.ReplaceItem(objectModel,status);
        }              
        else{
            catalogController.SetLock(status);
        }
    }

    public void DisablePanel(bool status){        
        disablePanel.SetActive(status);
    }

    public void OnItemClick()
    {        
        catalogController.ReplaceItem(objectModel,locked);        
    }
     
    public void OpenInfoPanel(){
        if(!infoPanelOpen){
            infoPanelOpen=true;
            infoPanel.SetActive(true);
            catalogController.CloseInfoPanel(thisViewIndex);
        }
        else{
            infoPanelOpen=false;
            infoPanel.SetActive(false);
        }
    }

    public void CloseInfoPanel(){
        infoPanelOpen=false;
        infoPanel.SetActive(false);
    }

    #endregion----------------------------------------------------------------------------
}