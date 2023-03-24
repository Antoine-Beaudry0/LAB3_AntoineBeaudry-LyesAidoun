using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public int totalChests = 6; // nombre total de coffres à ramasser
    private int chestsCollected = 0; // nombre de coffres ramassés

    private ChestCounter[] chestCounters; // tableau contenant tous les objets ChestCounter

    private void Start()
    {
        chestCounters = FindObjectsOfType<ChestCounter>(); // récupère tous les objets ChestCounter dans la scène
    }

    private void Update()
    {
        chestsCollected = 0; // réinitialise le nombre de coffres ramassés à chaque frame

        // pour chaque objet ChestCounter, ajoute le nombre de coffres ramassés à la variable chestsCollected
        foreach (ChestCounter chestCounter in chestCounters)
        {
            chestsCollected += chestCounter.chestsCollected;
        }

        if (chestsCollected >= totalChests)
        {
            // si le nombre total de coffres ramassés est atteint, active le script FinPartie sur l'objet courant
            GetComponent<FinPartie>().enabled = true;
        }
        else
        {
            // sinon, indique le nombre de coffres restants à ramasser dans la console
            Debug.Log("Il reste " + (totalChests - chestsCollected) + " coffres à ramasser.");
        }
    }
}
