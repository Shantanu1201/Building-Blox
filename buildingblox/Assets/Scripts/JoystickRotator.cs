using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public enum JoystickType
{
	PLAYER_MOVEMENT,
	PLAYER_ROTATION
}
public class JoystickRotator : MonoBehaviour , IDragHandler , IPointerDownHandler , IPointerUpHandler 
{
	[SerializeField]
	private JoystickType joystickType;
	private Image joystickContainer;
	private Image joystick;

	[SerializeField]
	private PlayerMovement playerMovement;
	private Vector3 userInputVector;

	void Start()
	{
		joystickContainer = this.GetComponent<Image>();
		joystick = joystickContainer.transform.GetChild(0).GetComponent<Image>();
		userInputVector = Vector3.zero;
	}
	public void OnPointerDown(PointerEventData pointData)
	{
		OnDrag(pointData);
	}
	public void OnDrag(PointerEventData pointData)
	{
		Vector2 positionVector = Vector2.zero;

		if(RectTransformUtility.ScreenPointToLocalPointInRectangle
		(joystickContainer.rectTransform,
		pointData.position,
		pointData.pressEventCamera,
		out positionVector))
		{
			positionVector.x = (positionVector.x / joystickContainer.rectTransform.sizeDelta.x);
			positionVector.y = (positionVector.y / joystickContainer.rectTransform.sizeDelta.y);
		

			float x = (joystickContainer.rectTransform.pivot.x == 1f) ? positionVector.x *2 + 1 : positionVector.x *2 - 1;
            float y = (joystickContainer.rectTransform.pivot.y == 1f) ? positionVector.y *2 + 1 : positionVector.y *2 - 1;
			userInputVector = new Vector3(x,y,0);
			//Debug.Log(userInputVector);
			userInputVector = (userInputVector.magnitude > 1) ? userInputVector.normalized : userInputVector; 
			playerMovement.HandlePlayerWithJoystick(userInputVector,joystickType);
			joystick.rectTransform.anchoredPosition = 
			new Vector2(userInputVector.x * (joystickContainer.rectTransform.sizeDelta.x /3) ,
			userInputVector.y *(joystickContainer.rectTransform.sizeDelta.y/3));
		}
	}

	public void OnPointerUp(PointerEventData pointData)
	{
		userInputVector = Vector3.zero;	
		joystick.rectTransform.anchoredPosition = Vector2.zero;
	}
	
}
