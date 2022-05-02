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
    private GameObject[] Lapset;

    /*void Start(){
        foreach (GameObject child in Lapset){
            child.SetActive(false);
        }
        
    }*/

    void Awake(){
        Debug.Log("Pelaajan Valinta start");
        int LapsetPituus = 0;
        foreach (var child in transform){
            LapsetPituus++;
        }
        Lapset = new GameObject[LapsetPituus];
        LapsetPituus = 0;
        foreach (Transform child in transform){
            Lapset[LapsetPituus] = child.gameObject;
            child.gameObject.SetActive(false);
            LapsetPituus++;
        }
        Debug.Log(Lapset.Length);
    }

    public void ValitseekoPelaaja(){
        
        foreach (GameObject child in Lapset){
            child.SetActive(true);
        }


        BG = GameObject.Find("BG");
        Rect = this.gameObject.GetComponent<RectTransform>();
        NumeroPaikka = 0;
        PalojenNumerot = new int [Tarkista.PalatJoillaNumero];
        Debug.Log("kaiffarin pituus " + PalojenNumerot.Length);
        Rect.sizeDelta = new Vector2(0,0);
        BG.SetActive(false);
        Debug.Log("BG inactive");
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
        foreach (GameObject child in Lapset){
            child.SetActive(false);
        }
    }
}
