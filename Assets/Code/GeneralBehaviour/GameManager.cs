using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private CameraMapController cmController;
    [SerializeField] public GameObject mainCamera;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cmController.isActive == false)
        {
            cmController.gameObject.SetActive(true);
            cmController.isActive = true;
        }
    }
}
