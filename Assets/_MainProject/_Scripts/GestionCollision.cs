using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{

    private GestionJeu _gestionJeu;
    private bool _touche;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _touche = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        _gestionJeu.AugmenterPointage();
        _touche = true;
    }
}
