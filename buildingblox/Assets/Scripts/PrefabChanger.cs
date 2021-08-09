using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabChanger : MonoBehaviour
{
    #region --------------------------------------Public Variables--------------------------------------
    public List<GameObject> models;
    public MouseDetector detect;
    public Button recommendationButton;
    public Image recommendationImage;
    #endregion----------------------------------------------------------------------------
    #region --------------------------------------Private Variables--------------------------------------
    [SerializeField]
    private string objectType;
    private int lastActive = 10;
    private int recommendation;
    [SerializeField]
    private RoomManager roomManager;
    #endregion----------------------------------------------------------------------------

    #region --------------------------------------Public Methods--------------------------------------
    public void ApplyModel(int modelIndex)
    {
        Debug.Log(modelIndex);
        if (modelIndex == lastActive)
        {
            detect.OnDeactivatePanel();
            return;
        }
        Debug.Log(models[modelIndex].name);

        for (int i = 0; i < models.Count; i++)
            if (models[i].activeInHierarchy)
            {
                models[i].SetActive(false);
            }
        models[modelIndex].SetActive(true);
        lastActive = modelIndex;
        detect.OnDeactivatePanel();
    }

    public int getCount()
    {
        return models.Count;
    }

    public void saveRecommendation(int index)
    {
        recommendation = index;
        Debug.Log("Recommendation for " + objectType + " is = " + recommendation);
    }

    public void OnModelClick(int index)
    {
        if (IsUIOver.isUiOn)
        {
            ApplyModel(index);
        }
    }
    #endregion----------------------------------------------------------------------------
}
