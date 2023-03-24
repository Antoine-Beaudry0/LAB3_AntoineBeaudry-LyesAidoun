using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToImpact = new List<GameObject>(); // Liste des objets à désactiver
    [SerializeField] private bool isActive = false; // État actuel du levier

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Inverse l'état du levier
            isActive = !isActive;

            // Active/désactive les objets impactés
            foreach (GameObject obj in objectsToImpact)
            {
                obj.SetActive(!isActive);
            }
            GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("Bravo t'as ouvert les portes! ");
        }
    }
}
