using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palat : MonoBehaviour
{
    public float Arvo;
    private Rigidbody2D RB;
    private SpriteRenderer SR;
    private Vector2 InitialPosition;
    private Vector2 mousePosition;
    private float Deltax, Deltay;

    // Start is called before the first frame update
    void Start(){
        InitialPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        RB = gameObject.GetComponent<Rigidbody2D>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x / 2, gameObject.GetComponent<RectTransform>().localScale.y / 2 * Arvo, gameObject.GetComponent<RectTransform>().localScale.z / 2);
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnMouseOver(){
        //SR.color = Color.red;
    }

    void OnMouseExit(){
        //SR.color = Color.black;
    }

    private void OnMouseDown(){
        Deltax = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        Deltay = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - Deltax, mousePosition.y - Deltay);
    }

    public void MoveTransform(){
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 0);
    }

    public void ResetTransform(){
        gameObject.GetComponent<RectTransform>().anchoredPosition = InitialPosition;
    }
}
