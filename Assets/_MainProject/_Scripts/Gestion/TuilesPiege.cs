using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuilesPiege : MonoBehaviour
{// ***** Atributs *****

    private bool _estActive = false;  // booléen qui permet de valider si la zone piège a été activée
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();  // Liste de gameObjects qui contient tous les gameObjects à déclencher
    private List<Rigidbody> _listeRb = new List<Rigidbody>(); // Liste de rigidbody qui va contenir tous les rigidbody des gameObjects de la liste précédente
 
    private GestionJeu _gestionJeu;
    private bool _touche;

    // ***** Méthode privées ****

    private void Awake()
    {
        // Pour chacun des gameObjects définis je récupère son rigidbory
        // et l'ajoute à la liste contenant ceux-ci
        foreach (var piege in _listePieges)
        {
            _listeRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    /*
     * Méthode qui est appelée quand un object entre dans la zone
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
