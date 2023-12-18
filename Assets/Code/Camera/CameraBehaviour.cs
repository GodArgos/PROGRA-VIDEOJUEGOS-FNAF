using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Header("VARIABLES")]
    [SerializeField] private float angleLimit = 30.0f; // El límite de rotación en grados.
    [SerializeField] private float speed = 10.0f; // La velocidad de rotación.

    [SerializeField] private float currentAngle = 0.0f; // El ángulo actual de rotación.
    [SerializeField] private int direction = 1; // La dirección de la rotación: 1 para derecha, -1 para izquierda.
    [SerializeField] private Vector3 initialRotation; // Rotación inicial de la cámara.

    void Start()
    {
        // Guarda la rotación inicial de la cámara.
        initialRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        // Calcula la nueva rotación.
        currentAngle += direction * speed * Time.deltaTime;

        // Revisa si la cámara ha alcanzado o superado el límite.
        if (currentAngle > angleLimit)
        {
            currentAngle = angleLimit;
            direction *= -1;
        }
        else if (currentAngle < -angleLimit)
        {
            currentAngle = -angleLimit;
            direction *= -1;
        }

        // Aplica la rotación a la cámara.
        transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y + currentAngle, initialRotation.z);
    }
}
