using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [Header("VARIABLES")]
    [SerializeField] private float camSpeed = 5.0f;
    [SerializeField] private float offset = 10.0f;
    [SerializeField] private float limit = 35.0f;
    private float moveDir = 0.0f;
    private float direction;

    private void Awake()
    {
        transform.eulerAngles = Vector3.zero;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseHPos = Input.mousePosition.x;
        float screnSize = Screen.width / 2;

        direction = (mouseHPos > screnSize + offset) ? 1.0f :
                    (mouseHPos < screnSize - offset) ? -1.0f : 0.0f;

        moveDir += camSpeed * direction * Time.deltaTime;
        moveDir = Mathf.Clamp(moveDir, -limit, limit);
        transform.eulerAngles = new Vector3 (0, moveDir, 0);
    }
}
