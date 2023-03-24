using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComptageCoffres : MonoBehaviour
{
    [SerializeField] private Color chestColor = Color.green; // La couleur du coffre lorsqu'il est touché
    [SerializeField] private GameObject playerObject; // L'objet représentant le joueur
    public static int totalChestCount = 0; // Le nombre total de coffres touchés
    private int chestCount = 0; // Le nombre de coffres touchés dans cette instance de script
    private List<GameObject> touchedChests = new List<GameObject>(); // La liste des coffres déjà touchés
    private Renderer chestRenderer; // Le composant Renderer du coffre

    private void Start()
    {
        Debug.Log("trouve les 6 coffres ! ");
        chestRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet qui touche le coffre est le joueur
        if (collision.gameObject.CompareTag(playerObject.tag))
        {
            // Vérifie si le coffre a déjà été touché
            if (touchedChests.Contains(gameObject))
            {
                return;
            }

            // Incrémente le compteur, change la couleur du coffre, ajoute le coffre à la liste des coffres touchés, incrémente le nombre total de coffres et affiche le nombre de coffres dans la console
            chestCount++; // ca marche pas
            chestRenderer.material.color = chestColor;
            touchedChests.Add(gameObject);
            totalChestCount++;
            Debug.Log("Nombre de coffres ramassés : " + totalChestCount );
        }
    }
}
