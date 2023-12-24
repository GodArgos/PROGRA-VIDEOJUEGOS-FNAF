using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Header("VARIABLES")]
    [SerializeField] private float angleLimit = 30.0f;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float currentAngle = 0.0f;
    [SerializeField] private int direction = 1;
    [SerializeField] private Vector3 initialRotation;
    [SerializeField] private float waitTime = 1.0f;

    private bool isWaiting = false; // Indica si la c�mara est� en espera

    void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        if (!isWaiting)
        {
            currentAngle += direction * speed * Time.deltaTime;

            if (currentAngle > angleLimit || currentAngle < -angleLimit)
            {
                StartCoroutine(WaitAndChangeDirection());
            }

            transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y + currentAngle, initialRotation.z);
        }
    }

    IEnumerator WaitAndChangeDirection()
    {
        isWaiting = true; // La c�mara comienza a esperar

        // Ajusta el �ngulo y cambia la direcci�n
        currentAngle = Mathf.Clamp(currentAngle, -angleLimit, angleLimit);
        direction *= -1;

        // Espera un segundo
        yield return new WaitForSeconds(waitTime);

        isWaiting = false; // La c�mara termina de esperar
    }
}
