using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementView : MonoBehaviour
{
    #region -------------------------------------- Public Variables --------------------------------------
    public GameObject player;
    public float speed;
    public float maxLookAngle;
    public float minLookAngle;
    public GameObject playerCamera;
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Private ariables --------------------------------------
    private Rigidbody rb;
    private Vector3 moveVector;
    private MoveModel moveModel;


    private float verticalRotation;
    #endregion----------------------------------------------------------------------------
    #region -------------------------------------- Private Methods --------------------------------------
    private void Start()
    {           
        moveModel = new MoveModel();
        moveModel.speed = speed;
        moveModel.maxLookAngle = maxLookAngle;
        moveModel.minLookAngle = minLookAngle;
        moveModel.mouseSensitivity = 1.5f;
        verticalRotation = 0;
        rb = player.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Movement();
        PlayerRotation();
        CameraRotation();
    }
    private void Movement()
    {
       
        //IsUIOver.isUiOn=true;//Debug.Log("Movement called");
#if UNITY_ANDROID
		moveVector=new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),0,CrossPlatformInputManager.GetAxis("Vertical"));
#else
        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
#endif

        //doesn't work when gravity is set to true for some reason
        //rb.transform.Translate(new Vector3(horizontal, 0, vertical )*moveModel.speed);
        moveVector = rb.transform.rotation *moveVector;
        rb.transform.position += moveVector * moveModel.speed *Time.fixedDeltaTime;
        //Debug.Log("Force = " + moveVector*moveModel.speed);
        //moveVector=transform.rotation*moveVector;

        //rb.transform.position+=transform.forward*moveModel.speed*Time.deltaTime;
        //rb.Move(moveVector*moveModel.speed*Time.deltaTime);

    }
    private void PlayerRotation()
    {
        //Debug.Log("Rotation");
#if UNITY_ANDROID
		rb.transform.Rotate(0, CrossPlatformInputManager.GetAxis("Mouse X") * moveModel.mouseSensitivity, 0);
#else
        rb.transform.Rotate(0, Input.GetAxis("Mouse X") * moveModel.mouseSensitivity , 0);
#endif
    }
    private void CameraRotation()
    {
        //Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        //float cameraRotationXDegree = cameraRotation.x*180;
        //Debug.Log(cameraRotationXDegree);
        //float rotation;
#if UNITY_ANDROID
		verticalRotation -= CrossPlatformInputManager.GetAxis("Mouse Y")* moveModel.mouseSensitivity;
#else
        verticalRotation -= Input.GetAxis("Mouse Y")* moveModel.mouseSensitivity;
#endif
        verticalRotation = Mathf.Clamp(verticalRotation, minLookAngle, maxLookAngle);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        //Debug.Log(cameraRotation.x *180);
        /*
		if(cameraRotation.x * 180 >= maxLookAngle)
		{
			cameraRotation.x = maxLookAngle;
			playerCamera.transform.rotation = cameraRotation;
		}
		else if(cameraRotation.x * 180 <= minLookAngle)
		{
			cameraRotation.x = minLookAngle;
			playerCamera.transform.rotation = cameraRotation;
		}
		Debug.Log(cameraRotation.x + ", " + playerCamera.transform.rotation);
		playerCamera.transform.Rotate(-rotation, 0, 0);
		*/
    }
    /*
	private void Jump()
	{
		Debug.Log("Jump");
		rb.AddForce(0, CrossPlatformInputManager.GetButton("Jump") * moveModel.height, 0);
	}
	*/
    #endregion----------------------------------------------------------------------------


}