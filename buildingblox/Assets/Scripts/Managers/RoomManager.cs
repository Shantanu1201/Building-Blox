using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class RoomManager : MonoBehaviour
{

    #region -------------------------------------- private varialbes --------------------------------------
    [SerializeField]
    private PrefabChanger tvBox;
    [SerializeField]
    private PrefabChanger coffeeTable;
    [SerializeField]
    private PrefabChanger diningTable;
    [SerializeField]
    private PrefabChanger sofa;
    #endregion----------------------------------------------------------------------------

    #region -------------------------------------- public varialbes --------------------------------------

    public List<Recommendations> recommendations;

    #endregion

    #region -------------------------------------- private methods --------------------------------------
    void Start()
    {
        LoadJsonText();
    }

    #endregion

    #region -------------------------------------- public methods --------------------------------------

    public void LoadJsonText()
    {
        TextAsset dataJson = Resources.Load("recomendations") as TextAsset;
        string dataAsJson = dataJson.text;
        Debug.Log(dataAsJson);

        RecommendationList loadedRecommendations = JsonUtility.FromJson<RecommendationList>(dataAsJson);

        for (int i = 0; i < loadedRecommendations.recommendationList.Length; i++)
        {
            recommendations.Add(loadedRecommendations.recommendationList[i]);
        }
    }
    #endregion----------------------------------------------------------------------------
}
