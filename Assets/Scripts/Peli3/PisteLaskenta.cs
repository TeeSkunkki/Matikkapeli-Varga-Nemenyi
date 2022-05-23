//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class PisteLaskenta : MonoBehaviour
{
    public SpriteManager SpriteManager;
    public CanvasController CanvasController;
    public RectTransform UILause;
    public RectTransform UIPisteet;
    private GameObject Seuraava;
    private int Pisteet = 0;
    private List<string> Lista;
    private string[] VaraLista;
    private string Vastaus;
    private int ListaInt;

    // Start is called before the first frame update
    public void KuvatJoitaEtsitaan(){
        Seuraava = GameObject.Find("Seuraava");
        Seuraava.SetActive(false);
        Lista = new List<string>();
        VaraLista = new string[SpriteManager.SpriteStringx.Length * SpriteManager.SpriteStringy.Length];
        int i = 0;
        for (int x = 0; x < SpriteManager.SpriteStringx.Length; x++){
            for(int y = 0; y < SpriteManager.SpriteStringy.Length; y++){
                Lista.Add(SpriteManager.SpriteStringx[x] + "_" + SpriteManager.SpriteStringy[y]);
                i++;
            }
        }
        ListaInt = Random.Range(0,Lista.ToArray().Length);
        Vastaus = Lista[ListaInt];
        VaraLista = new string[Lista.ToArray().Length];
        VaraLista = Lista.ToArray();
        Lista.RemoveAt(ListaInt);
        UILause.GetComponent<TextMeshProUGUI>().text = "Etsi " + Path.GetFileNameWithoutExtension(Vastaus.Replace('_', ' '));
        UIPisteet.GetComponent<TextMeshProUGUI>().text = Pisteet.ToString();
    }

    public void Tarkista(string Tarkistettava){
        if(Tarkistettava == Vastaus){
            if(Lista.ToArray().Length > 0){
                Pisteet++;
                UIPisteet.GetComponent<TextMeshProUGUI>().text = Pisteet.ToString();
                ListaInt = Random.Range(0,Lista.ToArray().Length);
                Vastaus = Lista[ListaInt];
                VaraLista = new string[Lista.ToArray().Length];
                VaraLista = Lista.ToArray();
                Lista.RemoveAt(ListaInt);
                UILause.GetComponent<TextMeshProUGUI>().text = "Etsi " + Path.GetFileNameWithoutExtension(Vastaus.Replace('_', ' '));
            }else{
                Pisteet++;
                UIPisteet.GetComponent<TextMeshProUGUI>().text = Pisteet.ToString();
                UILause.GetComponent<TextMeshProUGUI>().text = "Peli päättyi";
                Seuraava.SetActive(true);
                CanvasController.UudetKortitNappi(Seuraava);
            }
        }else{
            Lista.Remove(Tarkistettava);
        }
    }
}
