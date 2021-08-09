using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public void OnPointerEnter()
    {
        IsUIOver.isUiOn = true;
    }
    public void OnPointerExit()
    {
        IsUIOver.isUiOn = false;
    }
}
