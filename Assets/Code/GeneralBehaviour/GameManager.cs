using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> cameras;
    public GameObject currentCamera;
    public int cameraIndex;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentCamera = cameras.First();
        cameraIndex = 0;
        DeactivateCameras();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cameraIndex >= cameras.Count() - 1)
            {
                cameraIndex = 0;
            }
            else
            {
                cameraIndex++;
            }

            currentCamera = cameras[cameraIndex];
            DeactivateCameras();
   
        }
    }

    private void DeactivateCameras()
    {
        foreach (GameObject go in cameras)
        {
            if(go == currentCamera)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }
}
