using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IsUIOver
{
    public static bool isUiOn;
}
public class SlotView : MonoBehaviour
{
	#region -------------------------------------- Private Variables --------------------------------------
  
    private ObjectModel objectModel=new ObjectModel();
    
    [SerializeField]
    private Transform parent;

    [SerializeField]
    private Camera playerCamera;    
    [SerializeField]
    private Material[] materials;
    private bool locked=false;

    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Public Variables --------------------------------------

    public int slotIndex;
    public GameObject slotItem;
    public SlotController slotController;
    public GameObject extraWall;
    public GameObject backgroungPanel;
    public GameObject costUI;
    public GameObject joystickContainerPanel;
    public CostController costController;

    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Private Methods --------------------------------------
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OnDeactivateUI();
        }
    }
    public void OnMouseDown()
    {
        if (costUI.activeInHierarchy)
        {            
            costController.EmptyCostList();
            costUI.SetActive(false);  
            slotController.LoadCatalog(objectModel,slotIndex);
            if(joystickContainerPanel.activeInHierarchy)
            {
                joystickContainerPanel.SetActive(false);
            }                    
        }
        else if(!IsUIOver.isUiOn)
        {
            slotController.LoadCatalog(objectModel,slotIndex);
            if(joystickContainerPanel.activeInHierarchy)
            {
                joystickContainerPanel.SetActive(false);
            }  
            IsUIOver.isUiOn = true;
        }
    }

    #endregion----------------------------------------------------------------------------
    
    #region -------------------------------------- Public Methods --------------------------------------
    
    public void UpdateSlotModel(ObjectModel newObjectModel,bool lockStatus=false,SlotStatus status=SlotStatus.Unset)
    {
        locked=lockStatus;        
        this.gameObject.GetComponent<MeshRenderer>().material=materials[(int)status];
        objectModel=newObjectModel;
        IsUIOver.isUiOn = false;
		backgroungPanel.SetActive(false);
        //Debug.Log("UPDATED MODEL ID : "+objectModel.id);                    

        switch(objectModel.objectType){
            case "floor":
                        slotItem.GetComponent<MeshRenderer>().material=Resources.Load("Materials/"+objectModel.objectType+"/"+objectModel.texture) as Material;
                        break;
            case "wall":
                        extraWall.GetComponent<MeshRenderer>().material=Resources.Load("Materials/"+objectModel.objectType+"/"+objectModel.texture) as Material;                            
                        slotItem.GetComponent<MeshRenderer>().material=Resources.Load("Materials/"+objectModel.objectType+"/"+objectModel.texture) as Material;
                        break;
            case "featurewall":
                        slotItem.GetComponent<MeshRenderer>().material=Resources.Load("Materials/"+objectModel.objectType+"/"+objectModel.texture) as Material;
                        break;
            default:    
                        Destroy(slotItem);                       
                        slotItem = Instantiate(Resources.Load("Models/" + newObjectModel.model),parent) as GameObject;      
                        break;                                                
        }    
    }    

    public void UpdateSlotIcon(SlotStatus status){
        this.gameObject.GetComponent<MeshRenderer>().material=materials[(int)status];
    }

    public void UpdateMaterial(Material holoMat){
        MeshRenderer[] tempList=slotItem.GetComponentsInChildren<MeshRenderer>();
        for(int i=0;i<tempList.Length;i++)
            tempList[i].material=holoMat;
    }

    public ObjectModel GetObjectModel(){
        return objectModel;
    }
    
    public int getSlotIndex(){
        return slotIndex;
    }

    public void UpdateLock(bool lockStatus){
        locked=lockStatus;
    }
    
    public void OnDeactivateUI()
    {        
        IsUIOver.isUiOn = false;
    }
    #endregion----------------------------------------------------------------------------
}
