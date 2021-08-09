using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    public GameObject itemPrefab;
    [HideInInspector]
    public List<GameObject> itemPanelList;
    public ScrollRect itemScrollRect;
    public List<Sprite> spriteList;
    void Start()
    {
        for(int i=0;i<7;i++)
        {
            int temp = i;
            itemPanelList.Add(Instantiate(itemPrefab,itemScrollRect.content.transform) as GameObject);
            itemPanelList[i].GetComponent<ItemView>().infoButton.onClick.AddListener(()=> SetInfo(temp));
            //itemPanelList[i].GetComponent<ItemView>().itemImage.sprite = spriteList[i];
           // itemPanelList[i].GetComponent<ItemView>().itemName.text = spriteList[i];
           // itemPanelList[i].GetComponent<ItemView>().cost.text = spriteList[i];
        }
    }
    private void SetInfo(int infoIndex)
    {
        for(int k=0;k<itemPanelList.Count;k++)
        {
            if(k != infoIndex)
            {
                if(itemPanelList[k].GetComponent<ItemView>().infoPanel.gameObject.activeInHierarchy)
                {
                    itemPanelList[k].GetComponent<ItemView>().infoPanel.SetActive(false);
                }
            }
        }
        if(itemPanelList[infoIndex].GetComponent<ItemView>().infoPanel.gameObject.activeInHierarchy)
        {
            itemPanelList[infoIndex].GetComponent<ItemView>().infoPanel.SetActive(false);
        }
        else 
        {
            itemPanelList[infoIndex].GetComponent<ItemView>().infoPanel.SetActive(true);
        }
    }
}
