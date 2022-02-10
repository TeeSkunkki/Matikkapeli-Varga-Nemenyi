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

    void LateUpdate(){
        if(Tarkista.Vastaukset.Length == 0){
            this.gameObject.SetActive(false);
        }
    }

    void VaihdaTaso(){
        Seuraava.onClick.RemoveListener(VaihdaTaso);
        Tarkista.SeuraavatNumerot();
        Seuraava.onClick.AddListener(VaihdaTaso);
    }
}
