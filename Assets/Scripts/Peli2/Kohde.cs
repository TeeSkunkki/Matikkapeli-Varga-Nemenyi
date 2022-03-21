using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UIElements;

public class Kohde : MonoBehaviour
{
    public float kohde = 0f;       //Value jonka peli arpoo 1-16
    private float Tavoite = 0f;     //Value johon Sliderin liikkuminen päättyy
    public float Yhteensa = 0f;    //Value joka Slider on nyt
    private float Vali = 0f;        //Value jolla Slider liikkuu lineaarisesti (0-1)
    private float ValiYhteensa = 0f;//Value josta Slider aloittaa liikkumisen
    private int Pos = 11;
    private float Scale;
    private int LiikkuvaSlider = 0;
    private float kerroin = 0f;
    private string[] kaytetyt;
    private string[] KaytetytLauseet = new string[1];
    private string[] VaraLauseet = new string[1];
    public Slider[] YhteensaSlider;
    public TextMeshProUGUI Vastaus;
    public TextMeshProUGUI Pisteet;
    public GameObject Seuraava;
    //public TMP_InputField PelaajanVastaus;

    // Start is called before the first frame update
    void Start(){
        //YhteensaSlider = gameObject.transform.GetChild(0).GetComponentsInChildren<Slider>();
        Seuraava.SetActive(false);
        kohde = Mathf.Ceil(Random.Range(1f, 17f));
        kerroin = Mathf.Ceil(Random.Range(0.01f, 11f));
        YhteensaSlider = new Slider[11];
        Vastaus.text = (kohde * kerroin).ToString() + " =";
        for (int i = 0; i < gameObject.transform.GetComponentsInChildren<Canvas>().Length; i++){
            YhteensaSlider[i] = gameObject.transform.GetChild(i).GetChild(0).GetComponent<Slider>();
            YhteensaSlider[i].maxValue = kohde;
        }
        Scale = gameObject.GetComponent<RectTransform>().localScale.y;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x, Scale * kohde, gameObject.GetComponent<RectTransform>().localScale.z);
        //YhteensaSlider.highValue = kohde;
    }

    public void Uusi(){
        //YhteensaSlider = gameObject.transform.GetChild(0).GetComponentsInChildren<Slider>();
        KaytetytLauseet = new string[1];
        Seuraava.SetActive(false);
        kohde = Mathf.Ceil(Random.Range(1f, 17f));
        kerroin = Mathf.Ceil(Random.Range(0.01f, 11f));
        YhteensaSlider = new Slider[11];
        Vastaus.text = (kohde * kerroin).ToString() + " =";
        for (int i = 0; i < gameObject.transform.GetComponentsInChildren<Canvas>().Length; i++){
            YhteensaSlider[i] = gameObject.transform.GetChild(i).GetChild(0).GetComponent<Slider>();
            YhteensaSlider[i].maxValue = kohde;
        }
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x, Scale * kohde, gameObject.GetComponent<RectTransform>().localScale.z);
        //YhteensaSlider.highValue = kohde;
    }

    // Update is called once per frame
    void Update(){
        if(KaytetytLauseet.Length > 1 && !Seuraava.activeSelf){
            Seuraava.SetActive(true);
        }
    }

    public void Tarkista(string pelaajanVastaus){
        foreach (string Lause in KaytetytLauseet){
            if(Lause == pelaajanVastaus){
                Debug.Log(Lause + " on jo käyetty");
                return;
            }
        }
        int TempInt = 0;
        int paikka = 0;
        bool check = true;
        string[] TempString;
        TempString = pelaajanVastaus.Split('+');
        if(TempString.Length <= 1){
            return;
        }
        kaytetyt = new string[TempString.Length];
        foreach (string numero in TempString){
            for (int i = 0; i < numero.Length; i++){
                switch (numero[i])
                {
                    case '0':
                        break;
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                    case '7':
                        break;
                    case '8':
                        break;
                    case '9':
                        break;
                    default:
                        Debug.Log("Ei toimi");
                        check = false;
                        return;
                }
            }
            foreach (string kaytetty in kaytetyt){
                if(kaytetty == numero){
                    check = false;
                }
            }
            if(check){
            kaytetyt[paikka] = numero;
            TempInt += int.Parse(numero);
            }else{
                Debug.Log("check oli false");
                return;
            }
        }
        
        if(TempInt == kohde * kerroin){
            VaraLauseet = KaytetytLauseet;
            KaytetytLauseet = new string[VaraLauseet.Length + 1];
            for (int y = 0; y <= VaraLauseet.Length; y++){
                if(VaraLauseet.Length == y){
                    KaytetytLauseet[y] = pelaajanVastaus;
                }else{
                    KaytetytLauseet[y] = VaraLauseet[y];
                }
            }
            TempInt = int.Parse(Pisteet.text);
            TempInt += KaytetytLauseet.Length;
            Pisteet.text = TempInt.ToString();
        }
    }

    void OnTriggerStay2D(Collider2D Pala){
        if(!Input.GetMouseButton(0)){
            if(kohde >= Tavoite + Pala.GetComponent<Palat>().Arvo){
                Tavoite += Pala.GetComponent<Palat>().Arvo;
                LiikkuvaSlider = (int)Pala.GetComponent<Palat>().Arvo;
                Pala.GetComponent<Palat>().MoveTransform();
                StartCoroutine("LisaaTavoite");
            }else{
                Pala.GetComponent<Palat>().ResetTransform();
            }
        }
    }

    public void Alusta(){
        Tavoite = 0f;
        Yhteensa = 0f;
        Vali = 0f;
        ValiYhteensa = 0f;
        Pos = 11;
        foreach (Palat Pala in FindObjectsOfType<Palat>()){
            Pala.ResetTransform();
        }
        foreach (Slider slider in YhteensaSlider){
            slider.value = 0f;
        }
    }

    IEnumerator LisaaTavoite(){
        YhteensaSlider[LiikkuvaSlider - 1].transform.parent.gameObject.GetComponent<Canvas>().sortingOrder = Pos;
        while (Vali < 1f){
                yield return new WaitForSeconds(0.001f);
                Vali += Time.deltaTime * 1f;
                Yhteensa = Mathf.Lerp(ValiYhteensa, Tavoite, Vali);
                YhteensaSlider[LiikkuvaSlider - 1].value = Yhteensa;
        }
        Pos--;
        Debug.Log("Yhteensa = " + Yhteensa);
        Debug.Log("ValiYhteensa = " + ValiYhteensa);
        Debug.Log("Tavoite = " + Tavoite);
        ValiYhteensa = Yhteensa;
        Vali = 0f;
        Debug.Log("Uusi ValiYhteensa = " + ValiYhteensa);
        
    }

}
