using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuilesPiege : MonoBehaviour
{// ***** Atributs *****

    private bool _estActive = false;  // bool�en qui permet de valider si la zone pi�ge a �t� activ�e
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();  // Liste de gameObjects qui contient tous les gameObjects � d�clencher
    private List<Rigidbody> _listeRb = new List<Rigidbody>(); // Liste de rigidbody qui va contenir tous les rigidbody des gameObjects de la liste pr�c�dente
 
    private GestionJeu _gestionJeu;
    private bool _touche;

    // ***** M�thode priv�es ****

    private void Awake()
    {
        // Pour chacun des gameObjects d�finis je r�cup�re son rigidbory
        // et l'ajoute � la liste contenant ceux-ci
        foreach (var piege in _listePieges)
        {
            _listeRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    /*
     * M�thode qui est appel�e quand un object entre dans la zone
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_estActive)  
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            _gestionJeu.AugmenterPointage();
            _touche = true;
        }
    }
}
