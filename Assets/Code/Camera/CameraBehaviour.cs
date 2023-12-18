using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Header("VARIABLES")]
    [SerializeField] private float angleLimit = 30.0f; // El l�mite de rotaci�n en grados.
    [SerializeField] private float speed = 10.0f; // La velocidad de rotaci�n.

    [SerializeField] private float currentAngle = 0.0f; // El �ngulo actual de rotaci�n.
    [SerializeField] private int direction = 1; // La direcci�n de la rotaci�n: 1 para derecha, -1 para izquierda.
    [SerializeField] private Vector3 initialRotation; // Rotaci�n inicial de la c�mara.

    void Start()
    {
        // Guarda la rotaci�n inicial de la c�mara.
        initialRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        // Calcula la nueva rotaci�n.
        currentAngle += direction * speed * Time.deltaTime;

        // Revisa si la c�mara ha alcanzado o superado el l�mite.
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

        // Aplica la rotaci�n a la c�mara.
        transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y + currentAngle, initialRotation.z);
    }
}
