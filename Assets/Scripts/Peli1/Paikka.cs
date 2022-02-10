using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Paikka : MonoBehaviour
{
    public bool Operaattori = false;
    public bool Varattu = false;
    public GameObject VarattuPala;
    private GameObject ViimeinenVarattuPala;
    private Pala VarattuPalaScript;
    private float Deltax, Deltay;
    public Collider2D Alue;
    private Vector2 mousePosition;

    void Start(){
        Alue = GetComponent<Collider2D>();
    }

    private void OnMouseDrag(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ViimeinenVarattuPala.transform.position = new Vector2(mousePosition.x - Deltax, mousePosition.y - Deltay);
    }

    void OnTriggerEnter2D(Collider2D Pala){
        if(Pala.GetComponent<Pala>().Operaattori == Operaattori && !Varattu && VarattuPala == null){
            VarattuPala = Pala.gameObject;
            ViimeinenVarattuPala = VarattuPala;
            VarattuPalaScript = VarattuPala.GetComponent<Pala>();
            VarattuPalaScript.VarattuPaikka = gameObject;
            Varattu = true;
            Debug.Log("Kaiffari on ines");
        }else{
            Pala.GetComponent<Pala>().ResetTransform();
            Debug.Log("Kaiffari on täyn");
        }
    }
    void OnTriggerExit2D(Collider2D Pala){
        if(Pala.gameObject == VarattuPala){
            VarattuPala = null;
            Varattu = false;
            VarattuPalaScript.LukitusPois();
            VarattuPalaScript.VarattuPaikka = null;
            VarattuPalaScript = null;
            Debug.Log("Kaiffari Katos");
        }
        /*if(VarattuPalaScript.Operaattori != Operaattori || Varattu){
            VarattuPalaScript.ResetTransform();
        }*/
    }
    void OnTriggerStay2D(Collider2D Pala){
        if(Varattu && VarattuPala.GetComponent<RectTransform>().anchoredPosition3D != gameObject.GetComponent<RectTransform>().anchoredPosition3D + new Vector3(0,0,2)){
            if(!VarattuPalaScript.MouseOver){
                VarattuPala.GetComponent<RectTransform>().anchoredPosition3D = gameObject.GetComponent<RectTransform>().anchoredPosition3D + new Vector3(0,0,2);
            }else{
                VarattuPalaScript.LukitusPois();
            }
        }
        if(Pala.gameObject != VarattuPala){
            Pala.GetComponent<Pala>().ResetTransform();
        }
    }

}
