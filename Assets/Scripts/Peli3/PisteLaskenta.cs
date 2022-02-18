using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PisteLaskenta : MonoBehaviour
{
    public SpriteManager SpriteManager;
    public RectTransform UILause;
    public RectTransform UIPisteet; 
    private string[] Lista;

    // Start is called before the first frame update
    void Start(){
        Lista = new string[SpriteManager.SpriteStringx.Length + SpriteManager.SpriteStringy.Length];
        int i = 0;
        for (int x = 0; x < SpriteManager.SpriteStringx.Length; x++){
            for(int y = 0; y < SpriteManager.SpriteStringy.Length; y++){
                Lista[i] = SpriteManager.SpriteStringx[x] + "_" + SpriteManager.SpriteStringy[y];
                i++;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
