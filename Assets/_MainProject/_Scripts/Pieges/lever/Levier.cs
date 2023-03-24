using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToImpact = new List<GameObject>(); // Liste des objets � d�sactiver
    [SerializeField] private bool isActive = false; // �tat actuel du levier

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Inverse l'�tat du levier
            isActive = !isActive;

            // Active/d�sactive les objets impact�s
            foreach (GameObject obj in objectsToImpact)
            {
                obj.SetActive(!isActive);
            }
            GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("Bravo t'as ouvert les portes! ");
        }
    }
}
