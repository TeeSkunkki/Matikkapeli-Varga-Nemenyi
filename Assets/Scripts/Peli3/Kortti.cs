using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kortti : MonoBehaviour
{
    private float Vali = 0f;
    private bool Kaiffarimasiina = true;
    private Quaternion Kaannetty;
    private Quaternion InitialRotation;


    // Start is called before the first frame update
    void Start(){
        Kaannetty = GameObject.Find("Kaannetty").GetComponent<RectTransform>().rotation;
        InitialRotation = gameObject.GetComponent<RectTransform>().rotation;
    }

    // Update is called once per frame
    void Update(){
        gameObject.GetComponent<RectTransform>().rotation = Quaternion.Slerp(InitialRotation, Kaannetty, Vali);
    }

    private void OnMouseDown(){
        if(Kaiffarimasiina){
            StartCoroutine("LisaaTavoite");
            Kaiffarimasiina = false;
        }
    }

    IEnumerator LisaaTavoite(){
        while (Vali < 1f){
                yield return new WaitForSeconds(0.001f);
                Vali += Time.deltaTime * 1f;
                if(Vali >= 0.5f){
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
        }

    }
}
