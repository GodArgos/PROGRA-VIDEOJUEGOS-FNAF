using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras;
    [SerializeField] public GameObject currentCamera;
    [SerializeField] private int cameraIndex;
    [SerializeField] public bool isActive = false;

    [SerializeField] private GameObject mainCamera;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;
        mainCamera = gameManager.mainCamera;

        foreach (var cam in cameras)
        {
            cam.GetComponent<Camera>().enabled = false;
        }

        ConnectButtonsToCameras();

        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isActive && Input.GetKeyDown(KeyCode.Space))
        {
            isActive = false;
            this.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }
    }

    public void DeactivateCameras()
    {
        mainCamera.gameObject.SetActive(false);
        foreach (GameObject go in this.cameras)
        {
            if (go == currentCamera)
            {
                go.GetComponent<Camera>().enabled = true;
            }
            else
            {
                go.GetComponent<Camera>().enabled = false;
            }
        }
    }

    private void ConnectButtonsToCameras()
    {
        List<GameObject> buttons = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            buttons.Add(child.gameObject);
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<CameraButtonController>().designedCamera = cameras[i];
        }
    }
}
