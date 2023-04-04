using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie2 : MonoBehaviour
{
    private bool _finPartie = false;
    private GestionJeu _gestionJeu;
    private Player _player;
    private GestionJeu _pointage;

    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
        _pointage = FindObjectOfType<GestionJeu>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)
        {
            if (ComptageCoffres.totalChestCount == 7)
            {
                Debug.Log("ok");
                gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                _finPartie = true;

                _player.Arret();

                int noScene = SceneManager.GetActiveScene().buildIndex;
                if (noScene == 3)
                {
                    int accrochages = _gestionJeu.GetPointage();
                    Debug.Log("Fin de partie");
                    Debug.Log("Au total, vous avez touché " + _pointage.GetPointage() + " obstacles");

                }

                else
                {
                    SceneManager.LoadScene(noScene + 1);
                }
            }
            else
            {
                int coffresManquants = 7 - ComptageCoffres.totalChestCount;
                Debug.Log("Il manque " + coffresManquants + " coffres pour terminer le jeu");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
