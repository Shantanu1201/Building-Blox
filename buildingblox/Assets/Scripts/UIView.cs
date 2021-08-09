using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour {
	public GameObject catalog; 
	public GameObject backgroungPanel;
	public CatalogController catalogController;
	public GameObject joystickContainerPanel;
	public void OnBgClick()
	{
		if(catalog.activeInHierarchy)
		{
			Debug.Log("Bg is clicked");
			catalogController.EmptyCatalog();
			backgroungPanel.SetActive(false);
		}
	}	
}
