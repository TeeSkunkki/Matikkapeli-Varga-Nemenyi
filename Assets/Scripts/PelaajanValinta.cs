using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PelaajanValinta : MonoBehaviour
{
    public Tarkista Tarkista;
    private RectTransform Rect;
    private int[] PalojenNumerot;
    private int NumeroPaikka;
    public GameObject UILause;
    private GameObject BG;

    void Start(){
        foreach (Transform child in transform){
            child.gameObject.SetActive(false);
        }
    }

    public void ValitseekoPelaaja(){
        BG = GameObject.Find("BG");
        Rect = this.gameObject.GetComponent<RectTransform>();
        NumeroPaikka = 0;
        PalojenNumerot = new int [Tarkista.PalatJoillaNumero];
        Rect.sizeDelta = new Vector2(0,0);
        BG.SetActive(false);
        foreach (Transform child in transform){
            child.gameObject.SetActive(true);
        }
    }

    public void ValitseNumero(int ValittuNumero){

        foreach (int Numero in PalojenNumerot){
            if(Numero != ValittuNumero){
                if(Numero == 0){
                    PalojenNumerot[NumeroPaikka] = ValittuNumero;
                    UILause.GetComponent<TextMeshProUGUI>().text += ValittuNumero.ToString();
                    if(PalojenNumerot.Length - 2 > NumeroPaikka){
                        NumeroPaikka++;
                    }else{
                        PelaajaOnValinnut();
                    }
                    return; 
                }
            }else{
                return;
            }
        }
        
    }


    void PelaajaOnValinnut(){
        Tarkista.AnnaPaloilleNumerot(Tarkista.Palat, PalojenNumerot);
        BG.SetActive(true);
        foreach (Transform child in transform){
            child.gameObject.SetActive(false);
        }
    }
}
