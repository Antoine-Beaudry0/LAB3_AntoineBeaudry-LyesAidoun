using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{

    private GestionJeu _gestionJeu;
    private Collider _collider;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        _gestionJeu.AugmenterPointage();
        _collider.enabled = false;
        StartCoroutine(ReactiverCollision());

        Debug.Log("Vous avez heurt� un obstacle!");

        StartCoroutine(EffacerMessageConsole());
    }
    IEnumerator EffacerMessageConsole()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("");
    }
    private IEnumerator ReactiverCollision()
    {
        yield return new WaitForSeconds(4f);
        _collider.enabled = true;
    }
}
