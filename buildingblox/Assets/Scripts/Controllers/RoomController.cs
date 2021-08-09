using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomController : MonoBehaviour
{

    #region -------------------------------------- private variables --------------------------------------
    //[SerializeField]
    //private ObjectController objectController;
    [Space]
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject diningTable;
    [SerializeField]
    private GameObject coffeeTable;
    [SerializeField]
    private GameObject tvBox;
    [SerializeField]
    private GameObject sofa;

    #endregion----------------------------------------------------------------------------

    #region -------------------------------------- public variables --------------------------------------
    public List<Recommendations> recommendations;
    #endregion

    #region -------------------------------------- private methods --------------------------------------

    private void Start()
    {
        LoadRecommendations();
        StartCoroutine(test());
    }

    private IEnumerator test()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("STARTING");
        while (true)
        {
            yield return new WaitForSeconds(2);
            FeelingLucky();
            yield return new WaitForSeconds(2);
        }
    }

    private void LoadRecommendations()
    {
        TextAsset dataJson = Resources.Load("recomendations") as TextAsset;
        string dataAsJson = dataJson.text;
        Debug.Log(dataAsJson);
        RecommendationList loadedRecommendations = JsonUtility.FromJson<RecommendationList>(dataAsJson);
        for (int i = 0; i < loadedRecommendations.recommendationList.Length; i++)
        {
            recommendations.Add(loadedRecommendations.recommendationList[i]);
        }
        Debug.Log("Recommendations Loaded");
    }

    private void Spawn(ref GameObject obj, ObjectModel model)
    {
        Destroy(obj);
        obj = Instantiate(Resources.Load("models/" + model.model) as GameObject);
        obj.transform.SetParent(parent);
    }

    #endregion----------------------------------------------------------------------------

    #region -------------------------------------- public methods --------------------------------------
    public void FeelingLucky()
    {       
    }

    #endregion
}
