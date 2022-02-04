using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour
{
    private RectTransform Canvas;
    private RectTransform BGRect;
    private GameObject[] UIObjectit;
    private Camera MainCamera;
    private RectTransform Button;
    private RectTransform UILause;
    private RectTransform UIPisteet;
    private float ViimeinenPButton;
    

    void Start(){
        Canvas = GetComponent<RectTransform>();
        UIObjectit = GameObject.FindGameObjectsWithTag("UI");
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        UILause = GameObject.Find("UILause").GetComponent<RectTransform>();
        UIPisteet = GameObject.Find("UIPisteet").GetComponent<RectTransform>();
        BGRect = GameObject.Find("BGRect").GetComponent<RectTransform>();

        Canvas.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
        BGRect.sizeDelta = Canvas.sizeDelta;
        MainCamera.orthographicSize = Screen.height / 3.99999f;

        foreach (GameObject Object in UIObjectit){
            if(Object.GetComponent<RectTransform>() == null){
                Object.transform.localScale = new Vector2(Canvas.sizeDelta.x, Canvas.sizeDelta.y);
            }

            if(Object.GetComponent<RectTransform>() != null){
                Object.GetComponent<RectTransform>().sizeDelta = new Vector2(Canvas.sizeDelta.x / 6, Canvas.sizeDelta.y / 6);
            }

            if(Object.GetComponent<TextMeshProUGUI>() != null){
                Object.GetComponent<TextMeshProUGUI>().fontSize = MainCamera.orthographicSize / 7;
            }

            if(Object.name.StartsWith("Button")){
                Object.GetComponent<RectTransform>().sizeDelta = new Vector2(Canvas.sizeDelta.x / 10, Canvas.sizeDelta.x / 10);
                Object.GetComponent<RectTransform>().anchoredPosition = new Vector2(Object.GetComponent<RectTransform>().sizeDelta.x * float.Parse(Object.name[7].ToString()), Object.GetComponent<RectTransform>().sizeDelta.x * -1);
                Object.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = MainCamera.orthographicSize / 7;
            }
        }
        UILause.sizeDelta = new Vector2(Canvas.sizeDelta.x, Canvas.sizeDelta.y / 2);
        UIPisteet.sizeDelta = new Vector2(Canvas.sizeDelta.x, Canvas.sizeDelta.y / 6);
    }
}
