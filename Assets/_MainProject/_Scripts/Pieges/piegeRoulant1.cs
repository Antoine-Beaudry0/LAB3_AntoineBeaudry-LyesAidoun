using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piegeRoulant1 : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude du mouvement
    public float speed = 1.0f; // Vitesse du mouvement
    public Vector3 axis = Vector3.up; // Axe de vibration
    public bool invertDirection = false; // Inverser la direction de vibration

    private Vector3 startPosition; // Position de départ de l'objet

    void Start()
    {
        startPosition = transform.position; // Sauvegarde de la position de départ
    }

    void Update()
    {
        float pos = amplitude * Mathf.Sin(speed * Time.time); // Calcul de la position sur l'axe de vibration

        if (invertDirection) // Inversion de la direction de vibration si demandé
            pos = -pos;

        Vector3 delta = axis.normalized * pos; // Calcul du déplacement sur l'axe de vibration
        transform.position = startPosition + delta; // Mise à jour de la position de l'objet
    }
}
