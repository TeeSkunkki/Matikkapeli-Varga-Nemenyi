using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Resources;
using TMPro;

public class SpriteManager : MonoBehaviour
{
    private GameObject[] Grid;
    public string[] SpriteStringx = new string[4];
    public string[] SpriteStringy = new string[4];
    private string[] SpriteListx;
    private string[] SpriteListy;
    private int SpriteLength;
    public TextMeshProUGUI UILog;
    public TextAsset[] imageAsset;
    private Texture2D tex;

    // Start is called before the first frame update
    void Start(){
        Grid = new GameObject[GameObject.Find("BGRect").transform.childCount - 1];
        Debug.Log(Grid.Length / 4);
        SpriteStringx = new string[Grid.Length / 4];
        SpriteStringy = new string[Grid.Length / 4];

        for(int i = 0; i < Grid.Length; i++){
            Grid[i] = GameObject.FindGameObjectsWithTag("Pala")[i];    
        }

        SpriteLength = Directory.GetFiles("Resources", "*.png").Length;
        Debug.Log(Directory.GetFiles("Resources", "*.png").Length + " Kaiffaroinnin pituus");
        imageAsset = new TextAsset[SpriteLength];
        //SpriteLength = Resources.FindObjectsOfTypeAll(typeof(Sprite)).Length;
        
        SpriteListx = new string[SpriteLength];
        SpriteListy = new string[SpriteLength];

        bool check1 = true;
        bool check2 = true;
        int Paikka1 = 0;
        int Paikka2 = 0;
        Debug.Log("Aloitetaan kuvien etsintä");
        foreach (string kuva in Directory.GetFiles("Resources", "*.png")){
            Debug.Log(kuva);
            string[] temp = new string[2];
            //if(kuva.EndsWith(".png")){
                temp = kuva.ToString().Split('_');
                Debug.Log(temp[0] + " " + temp[1]);
                for (int i = 0; i < SpriteListx.Length; i++){
                    if(SpriteListx[i] == temp[0]){
                        check1 = false;
                    }
                    if(SpriteListy[i] == temp[1]){
                        check2 = false;
                    }
                }
                if(check1){
                    SpriteListx[Paikka1] = temp[0];
                    Paikka1++;
                }
                if(check2){
                    SpriteListy[Paikka2] = temp[1];
                    Paikka2++;
                }
                check1 = true;
                check2 = true;
            //}
        }
        Debug.Log("Kuvien etsintä valmis, Sprite listan alustaminen");
        Paikka1 = 0;
        foreach (string item in SpriteListx){
            if(item != null){
                Paikka1++;
            }
        }
        Debug.Log(Paikka1);
        string[] TempList1 = new string[Paikka1];
        string[] TempList2 = new string[Paikka1];
        
        for (int b = 0; b < TempList1.Length; b++){
            TempList1[b] = SpriteListx[b];
            TempList2[b] = SpriteListy[b];
        }

        SpriteListx = TempList1;
        SpriteListy = TempList2;

        int[] K = new int[4];
        for(int F = 0; F < K.Length; F++){
            K[F] -= 1;
        }

        Paikka1 = 0;
        check1 = true;
        Debug.Log("Listat alustettu, kuvien valinta");
        for(int a = 0; a < SpriteStringx.Length; a++){
            Paikka1 = Random.Range(0,SpriteListx.Length);
            foreach (int P in K){
                if(Paikka1 == P){
                    check1 = false;
                }
            }
            if(check1){
                K[a] = Paikka1;
                SpriteStringx[a] = SpriteListx[Paikka1];
            }else{
                a--;
            }
            check1 = true;
        }
        K = new int[4];
        for(int F = 0; F < K.Length; F++){
            K[F] -= 1;
        }
        Paikka1 = 0;
        check1 = true;
        for(int a = 0; a < SpriteStringy.Length; a++){
            Paikka1 = Random.Range(0,SpriteListy.Length);
            foreach (int P in K){
                if(Paikka1 == P){
                    check1 = false;
                }
            }
            if(check1){
                K[a] = Paikka1;
                SpriteStringy[a] = SpriteListy[Paikka1];
            }else{
                a--;
            }
            check1 = true;
        }
        Debug.Log("Kuvat valittu, kuvien asettaminen kortteihin");
        string StringPath;
        foreach (GameObject kortti in Grid){
            StringPath = SpriteStringx[kortti.name[0] - 49] + "_" + SpriteStringy[kortti.name[1] - 49];
            Debug.Log(StringPath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(File.ReadAllBytes(StringPath));
            kortti.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), kortti.transform.GetChild(0).GetComponent<RectTransform>().pivot);/*kortti.transform.GetChild(0).GetComponent<RectTransform>().rect*/
            kortti.GetComponent<Kortti>().KortinNimi = SpriteStringx[kortti.name[0] - 49] + "_" + SpriteStringy[kortti.name[1] - 49];
            //UILog.text += StringPath + " ";
        }
        /*string tempT1;
        foreach (string k1 in SpriteListx){
            tempT1 += " " + k1;
        }
        foreach (string k1 in SpriteListy){
            tempT1 += " " + k1;
        }
        UILog.text = tempT1;*/
        Debug.Log("SpriteManager Start Done.");
    }
}
