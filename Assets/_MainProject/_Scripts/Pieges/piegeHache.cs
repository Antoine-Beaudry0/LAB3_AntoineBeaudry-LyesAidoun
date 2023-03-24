using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piegeHache : MonoBehaviour
{
    public float amplitude = 30.0f; // Amplitude du mouvement
    public float speed = 1.0f; // Vitesse du mouvement
    public Vector3 axis = Vector3.up; // Axe de pivot
    public bool invertDirection = false; // Inverser la direction de rotation
    public float rotationOffset = 0.0f; // Offset de rotation initial en degrés

    private Quaternion startRotation; // Rotation de départ de l'objet

    void Start()
    {
        startRotation = transform.rotation; // Sauvegarde de la rotation de départ

        // Applique l'offset de rotation initial
        Quaternion offset = Quaternion.AngleAxis(rotationOffset, axis.normalized);
        transform.rotation = offset * startRotation;
    }

    void Update()
    {
        float angle = amplitude * Mathf.Sin(speed * Time.time); // Calcul de l'angle de rotation

        if (invertDirection) // Inversion de la direction de rotation si demandé
            angle = -angle;

        Quaternion rotation = Quaternion.AngleAxis(angle, axis.normalized); // Calcul de la rotation
        transform.rotation = startRotation * rotation; // Mise à jour de la rotation de l'objet
    }
}
