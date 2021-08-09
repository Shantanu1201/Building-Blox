using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecomendationController : MonoBehaviour {	

#region -------------------------------------- Private Variables --------------------------------------	
	private string objectsJsonFile = "ObjectData";
    private string setsJsonFile = "sets/set";
	[SerializeField]
    private SlotController slotController;
    private Dictionary<string, List<ObjectModel>> objectsList = new Dictionary<string, List<ObjectModel>>();
#endregion----------------------------------------------------------------------------

#region -------------------------------------- Public Variables --------------------------------------
	public List<SetModel> sets=new List<SetModel>();    
    public CatalogController catalogController;
#endregion----------------------------------------------------------------------------

#region -------------------------------------- Private Methods --------------------------------------

	private void Start()
    {
        ParseObjects();        
    }

    private void ParseObjects()
    {
        TextAsset objectJsonObj = Resources.Load(objectsJsonFile) as TextAsset;
        ObjectsJsonData objectListReceived = JsonUtility.FromJson<ObjectsJsonData>(objectJsonObj.ToString());
        objectsList.Add("wall", objectListReceived.wall);
        objectsList.Add("floor", objectListReceived.floor);
        objectsList.Add("featurewall", objectListReceived.featurewall);
        objectsList.Add("diningTable", objectListReceived.diningTable);
        objectsList.Add("coffeeTable", objectListReceived.coffeeTable);
        objectsList.Add("sofa", objectListReceived.sofa);
        objectsList.Add("tvBox", objectListReceived.tvBox);
        Debug.Log("Objects Loaded");

		Debug.Log("Set Parser called");				
		for(int setcount=1;setcount<=5;setcount++)
		{
    		TextAsset setJsonObj = Resources.Load(setsJsonFile+setcount.ToString()) as TextAsset;
        	Debug.Log(setJsonObj.text);
    		sets.Add(JsonUtility.FromJson<SetModel>(setJsonObj.ToString()));       
		}		
		Debug.Log("Sets Parsed");	
	}	
#endregion----------------------------------------------------------------------------

#region -------------------------------------- Public Methods --------------------------------------
	
    public void FeelingLucky()
    {
        
        int randomSet = UnityEngine.Random.Range(0, sets.Count); 
		int randomRoom=UnityEngine.Random.Range(0,sets[randomSet].rooms.Length);                               
		for(int i=0;i<sets[randomSet].rooms[randomRoom].slot.Length;i++){            			
			slotController.UpdateSlotView(sets[randomSet].rooms[randomRoom].slot[i].slotIndex,objectsList[((SlotIndex)(sets[randomSet].rooms[randomRoom].slot[i].slotIndex)).ToString()][sets[randomSet].rooms[randomRoom].slot[i].objectId]);
		}
    }

    public void StartFromScratch(){        
		for(int i=0;i<sets[0].rooms[0].slot.Length;i++){            			
			slotController.UpdateSlotView(sets[0].rooms[0].slot[i].slotIndex,objectsList[((SlotIndex)(sets[0].rooms[0].slot[i].slotIndex)).ToString()][sets[0].rooms[0].slot[i].objectId]);
		}
        slotController.StartFromScratch();
    }

    public void UpdateLocks(ObjectModel objectModel){
        
    }

    public void GenerateCatalogList(ObjectModel objectModel,int slotID,bool locked){
            
        catalogController.GenerateCatalog(objectModel,objectsList[((SlotIndex)slotID).ToString()],slotID,locked);       
    }

#endregion----------------------------------------------------------------------------
}
