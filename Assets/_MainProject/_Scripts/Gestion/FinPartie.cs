using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    private bool _finPartie = false;
    private GestionJeu _gestionJeu;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            _finPartie = true;

            int noScene = SceneManager.GetActiveScene().buildIndex;
            if (noScene == 1)
            {
                int accrochages = _gestionJeu.GetPointage();
                Debug.Log("Fin de partie");

                
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
