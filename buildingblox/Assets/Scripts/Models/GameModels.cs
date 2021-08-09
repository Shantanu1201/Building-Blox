using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectModel
{
    public int id;
    public string name;
    public string texture;
    public string model;
    public string thumbnail;
    public float cost;
    public float width;
    public float height;
    public float rotationAngle;
    public float pivotPoint;
    public string objectType;
}
    
public enum SlotIndex{tvBox,coffeeTable,diningTable,sofa,floor,wall,featurewall};
public enum SlotStatus{Unset,Set,Recommendation,Lock}

[System.Serializable]
public class SlotModel
{
    public int slotIndex;
    public float slotX;
    public float slotY;
    public int objectId;
}

[System.Serializable]
public class RoomModel
{
    public int roomId;
    public string roomType;
    public SlotModel[] slot;
}

[System.Serializable]
public class SetModel
{
    public RoomModel[] rooms;
}

[System.Serializable]
public class ObjectsJsonData
{
    public List<ObjectModel> floor;
    public List<ObjectModel> featurewall;
    public List<ObjectModel> wall;
    public List<ObjectModel> diningTable;
    public List<ObjectModel> coffeeTable;
    public List<ObjectModel> tvBox;
    public List<ObjectModel> sofa;
}

[System.Serializable]
public class Recommendations
{
    public int roomNo;
    public int tvBox;
    public int coffeeTable;
    public int diningTable;
    public int sofa;
}

[System.Serializable]
public class RecommendationList
{
    public Recommendations[] recommendationList;
}