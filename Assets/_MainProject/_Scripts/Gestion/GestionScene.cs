using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{

    [SerializeField] private GameObject _menuPause = default;
    private bool _enPause;
    
    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; // R�cup�re l'index de la sc�ne en cours
        SceneManager.LoadScene(noScene + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }
    

    public void Retour()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }


    public void Instructions()
    {
        SceneManager.LoadScene(5);
    }



}
