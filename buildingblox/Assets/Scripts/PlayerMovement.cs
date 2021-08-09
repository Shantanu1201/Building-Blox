    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    #region -------------------------------------- Public Variables --------------------------------------
    private GameObject player;
    public float speed;
    public float maxLookAngle;
    public float minLookAngle;
    private Camera playerCamera;
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
        playerCamera = this.GetComponent<Camera>();
        moveModel = new MoveModel();
        moveModel.speed = speed;
        moveModel.maxLookAngle = maxLookAngle;
        moveModel.minLookAngle = minLookAngle;
        moveModel.mouseSensitivity = 1.5f;
        moveModel.cameraRotationFactor = 3f;
        player = this.transform.parent.gameObject;
        rb = player.GetComponent<Rigidbody>();
    }
    public void HandlePlayerWithJoystick(Vector3 inputVector , JoystickType joystickType)
    {
        if(joystickType == JoystickType.PLAYER_MOVEMENT)
        {
            MovePlayer(inputVector);
        }
        else
        {
            RotatePlayer(inputVector);
        }
    }

    private void MovePlayer(Vector3 movementVector)
    {
        moveVector = new Vector3(movementVector.x,0,movementVector.y);
        moveVector = rb.transform.rotation *moveVector;
        rb.transform.Translate(moveVector * moveModel.speed,Space.World);
    }

    private void RotatePlayer(Vector3 rotationVector)
    {    
        rb.transform.Rotate(0, rotationVector.x * moveModel.mouseSensitivity * moveModel.cameraRotationFactor, 0);
        verticalRotation -= rotationVector.y* moveModel.mouseSensitivity *moveModel.cameraRotationFactor;
        verticalRotation = Mathf.Clamp(verticalRotation,minLookAngle,maxLookAngle);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
    #endregion----------------------------------------------------------------------------


}