using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    // ***** Attributs *****

    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages
    private int _accrochageNiveau1 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 1
    private int _accrochageNiveau2 = 0;
    private float _tempsNiveau1 = 0.0f;  // Attribut qui conserve le temps pour le niveau 1
    private float _tempsNiveau2 = 0.0f;
    private bool _timerStarted;
    private float _startTime;
    private bool _aDebute;
    private object _gestionJeu;
    private bool _enMouvement;

    // ***** Méthodes privées *****
    private void Awake()
    {
        // Vérifie si un gameObject GestionJeu est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour le 
        // scène suivante.
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        InstructionsDepart();  // Affiche les instructions de départ
    }

    /*
     * Méthode qui affiche les instructions au départ
     */
    private static void InstructionsDepart()
    {
        Debug.Log("*** Course à obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque contact avec un obstable entraînera une pénalité");
    }

    // ***** Méthodes publiques ******

    /*
     * Méthode publique qui permet d'augmenter le pointage de 1
     */
    public void AugmenterPointage()
    {
        _pointage++;
    }

    // Accesseur qui retourne la valeur de l'attribut pointage
    public int GetPointage()
    {
        return _pointage;
    }

    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiv1()
    {
        return _tempsNiveau1;
    }

    public float GetTempsNiv2()
    {
        return _tempsNiveau2;
    }
    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
    public int GetAccrochagesNiv1()
    {
        return _accrochageNiveau1;
    }

    public int GetAccrochagesNiv2()
    {
        return _accrochageNiveau2;
    }

    // Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau1(int accrochages, float tempsNiv1)
    {
        _accrochageNiveau1 = accrochages;
        _tempsNiveau1 = tempsNiv1;
    }
    public void SetNiveau2(int accrochages, float tempsNiv2)
    {
        _accrochageNiveau2 = accrochages - _accrochageNiveau1;
        _tempsNiveau2 = tempsNiv2 - _tempsNiveau1;
    }
    public void StartTimer()
    {
        _timerStarted = true;
        _startTime = Time.time;
    }
    public void Debuter()
    {
        if (!_aDebute)
        {
            _aDebute = true;
            StartTimer();
        }
        _enMouvement = true;
    }
}