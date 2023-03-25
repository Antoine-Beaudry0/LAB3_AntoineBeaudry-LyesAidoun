using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
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
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            _finPartie = true;

            _player.Arret();

            int noScene = SceneManager.GetActiveScene().buildIndex;
            if (noScene == 2)
            {
                int     accrochages         = _gestionJeu.GetPointage();
                int     _accrochagesNiv1    = _gestionJeu.GetAccrochagesNiv1();
                float   _tempsNiv1          = _gestionJeu.GetTempsNiv1();
                int     _accrochagesNiv2    = _gestionJeu.GetAccrochagesNiv2();
                float   _tempsNiv2          = _gestionJeu.GetTempsNiv2();
                int     _accrochagesNiv3    = accrochages - (_accrochagesNiv1 + _accrochagesNiv2);
                float   _tempsNiv3          = Time.time - (_tempsNiv1 + _tempsNiv2);


                float _tempsTolNiv1 = _accrochagesNiv1 + _tempsNiv1;
                float _tempsTolNiv2 = _accrochagesNiv2 + _tempsNiv2;
                float _tempsTolNiv3 = _accrochagesNiv3 + _tempsNiv3;

                

                Debug.Log("Fin de partie");

                Debug.Log("Obstacles Niveau 1 = " + _accrochagesNiv1.ToString());
                Debug.Log("Temps Niveau 1 = " + _tempsNiv1);
                Debug.Log("Temps total Niveau 1 = " + _tempsTolNiv1.ToString("f2"));

                Debug.Log("Obstacles Niveau 2 = " + _accrochagesNiv2.ToString());
                Debug.Log("Temps Niveau 2 = " + _tempsNiv2);
                Debug.Log("Temps total Niveau 2 = " + _tempsTolNiv2.ToString("f2"));

                Debug.Log("Obstacles Niveau 3 = " + _accrochagesNiv3.ToString());
                Debug.Log("Temps Niveau 3 = " + _tempsNiv3);
                Debug.Log("Temps total Niveau 3 = " + _tempsTolNiv3.ToString("f2"));

                Debug.Log("Au total, vous avez touché " + _pointage.GetPointage() + " obstacles");

                float _tempTotal = _tempsTolNiv1 + _tempsTolNiv2 + _tempsTolNiv3;
                Debug.Log("Temps total du jeu = " + _tempTotal + " secondes");

            }

            else if (noScene == 0)
            {
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                SceneManager.LoadScene(noScene + 1);
            }
            else if (noScene == 1)
            {

                SceneManager.LoadScene(noScene + 1);
                _gestionJeu.SetNiveau2(_gestionJeu.GetPointage(), Time.time);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!_finPartie && Input.anyKeyDown)
        {
            _gestionJeu.StartTimer();
            Debug.Log("Chronomètre démarré");
        }
    }
}