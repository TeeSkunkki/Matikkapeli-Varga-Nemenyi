using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pala : MonoBehaviour
{
    private Rigidbody2D RB;
    private SpriteRenderer SR;
    private Color DefaultColor;
    public GameObject VarattuPaikka;
    public bool Operaattori = false;
    public int Numero;
    public string operaattori;
    public bool MouseOver = false;
    private Vector2 InitialPosition;
    private Vector2 mousePosition;
    private float Deltax, Deltay;
    private RectTransform BGRect;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        RB = gameObject.GetComponent<Rigidbody2D>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        DefaultColor = SR.color;
        Paivita();
        BGRect = GameObject.Find("BGRect").GetComponent<RectTransform>();
    }

    void Update(){
        if(!BGRect.rect.Contains(this.gameObject.transform.position)){
            ResetTransform();
        }
    }

    public void Paivita(){
        if(Operaattori != true){
            gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = Numero.ToString();
        }else{
            gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = operaattori;
        }
    }


    void OnMouseOver(){
        MouseOver = true;
        SR.color = Color.red;
    }

    void OnMouseExit(){
        MouseOver = false;
        SR.color = DefaultColor;
    }

    private void OnMouseDown(){
        Deltax = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        Deltay = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseUp(){
        if(VarattuPaikka != null){
            gameObject.transform.position = VarattuPaikka.transform.position + new Vector3(0,0,-1);
        }
    }

    private void OnMouseDrag(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - Deltax, mousePosition.y - Deltay);
    }

    

    public void Lukitus(){
        RB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void LukitusPois(){
        RB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void ResetTransform(){
        gameObject.GetComponent<RectTransform>().anchoredPosition = InitialPosition;
    }

}
