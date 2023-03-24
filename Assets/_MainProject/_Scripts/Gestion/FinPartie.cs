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
            Debug.Log("ok");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            _finPartie = true;

            int noScene = SceneManager.GetActiveScene().buildIndex;
            if (noScene == 2)
            {
                int accrochages = _gestionJeu.GetPointage();
                Debug.Log("Fin de partie");
                Debug.Log("Au total, vous avez touch� " + _pointage.GetPointage() + " obstacles");
                
            }

            else
            {
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
