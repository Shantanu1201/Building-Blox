using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRToggle : MonoBehaviour
{
    public GameObject controller;
    public List<GameObject> togglers;
    public List<GameObject> vrTogglers;
    public void ToggelVR()
    {
        if (XRSettings.loadedDeviceName == "Cardboard")
        {
            StartCoroutine(LoadDevice("None"));
            Debug.Log("none vr");
        }
        else
        {
            controller.SetActive(false);
            for (int i = 0; i < togglers.Count; i++)
            {
                togglers[i].SetActive(false);
            }
            for (int j = 0; j < vrTogglers.Count; j++)
            {
                vrTogglers[j].SetActive(true);
            }
            StartCoroutine(LoadDevice("Cardboard"));
            Debug.Log("VR cardboard");
        }
    }
    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }

}
