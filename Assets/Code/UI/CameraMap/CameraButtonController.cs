using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonController : MonoBehaviour
{
    [Header("DEPENDENCIES")]
    [SerializeField] private CameraMapController mController;
    [HideInInspector] public GameObject designedCamera;
    
    public void ChangeCamera()
    {
        mController.currentCamera = this.designedCamera;
        mController.DeactivateCameras();
    }
}
