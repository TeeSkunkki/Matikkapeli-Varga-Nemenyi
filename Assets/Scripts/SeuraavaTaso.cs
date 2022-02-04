using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeuraavaTaso : MonoBehaviour
{
    public Button Seuraava;
    private Tarkista Tarkista;
    public int Pisteet = 0;


    void Start(){
        Tarkista = GameObject.Find("TarkistaNappi").GetComponent<Tarkista>();
        Seuraava.onClick.AddListener(VaihdaTaso);
    }

    void VaihdaTaso(){
        
    }
}
