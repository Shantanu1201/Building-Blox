using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperBlur;

public class BlurController : MonoBehaviour
{
    public List<GameObject> optionsToggle;
    public GameObject menuToggle;

    public void OnClickOption()
    {
        for (int i = 0; i < optionsToggle.Count; i++)
        {
            optionsToggle[i].SetActive(true);
        }
        menuToggle.SetActive(false);
        this.GetComponent<SuperBlurBase>().enabled = false;
    }
}
