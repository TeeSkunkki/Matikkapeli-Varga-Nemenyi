using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kohde : MonoBehaviour
{
    private float kohde = 0f;       //Value jonka peli arpoo
    private float Tavoite = 0f;     //Value johon Sliderin liikkuminen päättyy
    public float Yhteensa = 0f;    //Value joka Slider on nyt
    private float Vali = 0f;        //Value jolla Slider liikkuu lineaarisesti (0-1)
    private float ValiYhteensa = 0f;//Value josta Slider aloittaa liikkumisen
    public Slider YhteensaSlider;


    // Start is called before the first frame update
    void Start(){
        
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

        YhteensaSlider.value = Yhteensa;
    }

    void OnTriggerStay2D(Collider2D Pala){
        if(!Input.GetMouseButton(0)){
            Tavoite += Pala.GetComponent<Palat>().Arvo;
            Pala.GetComponent<Palat>().MoveTransform();
            StartCoroutine("LisaaTavoite");
        }
    }

    IEnumerator LisaaTavoite(){
        while (Vali < 1f){
                yield return new WaitForSeconds(0.001f);
                Vali += Time.deltaTime * 1f;
                Yhteensa = Mathf.Lerp(ValiYhteensa, Tavoite, Vali);
            }
        Debug.Log("Yhteensa = " + Yhteensa);
        Debug.Log("ValiYhteensa = " + ValiYhteensa);
        Debug.Log("Tavoite = " + Tavoite);
        ValiYhteensa = Yhteensa;
        Vali = 0f;
        Debug.Log("Uusi ValiYhteensa = " + ValiYhteensa);
        
    }

}
