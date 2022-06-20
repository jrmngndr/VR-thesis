using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void OnEnable()
    {
        CameraView.OnCameraInput += MoveCamera;
    }

    private void OnDisable()
    {
        CameraView.OnCameraInput -= MoveCamera;
    }

    private void MoveCamera()
    {
        float mouseY = Input.GetAxis("Mouse Y") * ScenarioData.mouseSensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * ScenarioData.mouseSensitivity * Time.deltaTime;

        ScenarioData.xRotation -= mouseY;
        ScenarioData.xRotation = Mathf.Clamp(ScenarioData.xRotation, ScenarioData.xRotationMin, ScenarioData.xRotationMax);
        ScenarioData.mainCamera.transform.localRotation = Quaternion.Euler(ScenarioData.xRotation, 0f, 0f);

        ScenarioData.playerTransform.Rotate(Vector3.up * mouseX);
    }
}
