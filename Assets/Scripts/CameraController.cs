using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 thirdPersonCameraPosition = new Vector3(0, 4.7f, -29.8f);
    private Quaternion thirdPersonCameraRotation = Quaternion.Euler(27f, 0, 0);
    private float thirdPersonFieldOfView = 74f;
    private float firstPersonFieldOfView = 105f;
    private bool isThirdPerson = true;
    public Camera mainCamera;

    public GameObject sonic;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isThirdPerson)
            {
                TriggerFirstPersonView();
            }
            else
            {
                TriggerThirdPersonView();
            }

        }
        if (!isThirdPerson)
        {

            mainCamera.transform.position = sonic.transform.position + new Vector3(0f, 0.3f, -0.1f);
        }
    }



    public void TriggerThirdPersonView()
    {
        mainCamera.transform.position = thirdPersonCameraPosition;
        mainCamera.transform.rotation = thirdPersonCameraRotation;
        mainCamera.fieldOfView = thirdPersonFieldOfView;
        isThirdPerson = true;
    }

    public void TriggerFirstPersonView()
    {
        mainCamera.fieldOfView = firstPersonFieldOfView;
        isThirdPerson = false;
    }



}
