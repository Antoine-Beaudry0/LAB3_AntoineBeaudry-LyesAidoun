using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{

    private GestionJeu _gestionJeu;
    private Collider _collider;
    private bool _touche = false;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_touche == false)
        {
            _gestionJeu.AugmenterPointageUi();
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

            StartCoroutine(ReactiverCollision());

            Debug.Log("Vous avez heurt� un obstacle!");

            StartCoroutine(EffacerMessageConsole());
        }
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
