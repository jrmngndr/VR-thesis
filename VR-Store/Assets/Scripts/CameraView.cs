using UnityEngine;

public class CameraView : MonoBehaviour
{
    public delegate void CameraInput();
    public static event CameraInput OnCameraInput;

    void Update() //kinda useless class, rewrite??
    {
        if (Input.GetMouseButton(0))
        {
            OnCameraInput();
        }
    }
}
