using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtAccorchagesTotal = default;
    [SerializeField] private TMP_Text _txtPointageTotal = default;
    private GestionJeu _gestionJeu;

    void Start()
    {
          Time.timeScale =0;
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtTempsTotal.text = "Temps Total : " + _gestionJeu.GetTempsFinal().ToString("f2") + " sec.";
        _txtAccorchagesTotal.text = "Nombres d'accrochages : " + _gestionJeu.GetPointage().ToString();
        float pointageTotal = _gestionJeu.GetTempsFinal() + _gestionJeu.GetPointage();
        _txtPointageTotal.text = "Pointage Final : " + pointageTotal.ToString("f2") + " sec.";
    }
}
