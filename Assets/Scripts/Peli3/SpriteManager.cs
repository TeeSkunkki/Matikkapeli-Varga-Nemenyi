using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpriteManager : MonoBehaviour
{
    private GameObject[] Grid;
    private string[] SpriteStringx = new string[4];
    private string[] SpriteStringy = new string[4];
    private string[] SpriteListx;
    private string[] SpriteListy;
    private int SpriteLength;

    // Start is called before the first frame update
    void Start(){
        Grid = new GameObject[GameObject.Find("BGRect").transform.childCount - 1];
        SpriteString1 = new string[Grid.Length / 4];
        SpriteString2 = new string[Grid.Length / 4];
        Debug.Log(SpriteString1.Length + " " + SpriteString2.Length);
        for(int i = 0; i < Grid.Length; i++){
            Grid[i] = GameObject.FindGameObjectsWithTag("Pala")[i];    
        }
        SpriteLength = Directory.GetFiles("Assets/Scripts/Peli3/Sprite").Length / 2;
        SpriteListx = new string[SpriteLength];
        SpriteListy = new string[SpriteLength];
        
        foreach (string kuva in Directory.GetFiles("Assets/Scripts/Peli3/Sprite")){
            if(!kuva.EndsWith(".meta")){
                
            }
        }
        /*foreach (GameObject kortti in Grid){

            //kortti.GetChild(0).GetComponent<SpriteRenderer>().sprite = Sprite.Load<Sprite>();
        }*/
    }

    // Update is called once per frame
    void Update(){
        
    }
}
