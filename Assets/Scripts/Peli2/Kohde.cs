using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Kohde : MonoBehaviour
{
    public float kohde = 0f;       //Value jonka peli arpoo 1-16
    private float Tavoite = 0f;     //Value johon Sliderin liikkuminen päättyy
    public float Yhteensa = 0f;    //Value joka Slider on nyt
    private float Vali = 0f;        //Value jolla Slider liikkuu lineaarisesti (0-1)
    private float ValiYhteensa = 0f;//Value josta Slider aloittaa liikkumisen
    private int Pos = 11;
    private int LiikkuvaSlider = 0;
    private float kerroin = 0f;
    public Slider[] YhteensaSlider;


    // Start is called before the first frame update
    void Start(){
        //YhteensaSlider = gameObject.transform.GetChild(0).GetComponentsInChildren<Slider>();
        kohde = Mathf.Ceil(Random.Range(1f, 17f));
        kerroin = Mathf.Ceil(Random.Range(0.01f, 11f));
        YhteensaSlider = new Slider[11];
        for (int i = 0; i < gameObject.transform.GetComponentsInChildren<Canvas>().Length; i++){
            YhteensaSlider[i] = gameObject.transform.GetChild(i).GetChild(0).GetComponent<Slider>();
            YhteensaSlider[i].maxValue = kohde;
        }
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x, gameObject.GetComponent<RectTransform>().localScale.y * kohde, gameObject.GetComponent<RectTransform>().localScale.z);
        //YhteensaSlider.highValue = kohde;
    }

    // Update is called once per frame
    void Update(){
        /*if(Yhteensa != Tavoite){
            Yhteensa = Mathf.Lerp(ValiYhteensa, Tavoite, Vali);
        }else{
            ValiYhteensa = Yhteensa;
        }

        if(Vali == 1f){
            Vali = 0f;
        }*/
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
