using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OnlineKuvat : MonoBehaviour
{
    public string url;
    public string[] sarjat;
    public string[] kuvat;
    public Texture2D kuvaTexture;
    public bool RequestDone = false;

    //Kun etsitään kuva sarjat
    //url = localhost:49011/Kuvat/
    //["KuvaSet1","KuvaSet2"]
    //lisää / aina sarjan jälkeen
    //sarja = KuvaSet1/
    //Kun etsitään kuva
    //url = localhost:49011/KaikkiKuvat/KuvaSet1/KuvanNimi.png
    void Start(){
        //Kuvat("KuvaSet1");
    }

    void Update(){
        
    }

    //etsii kuvien nimet eri kuvasarjoista
    /*public string[] Kuvat(string sarja){
        StartCoroutine(GetKuvat(url+"/"+sarja+"/"));
        return kuvat;
    }
    //etsii kuvasarjat palvelimelta
    public string[] Sarjat()
    {
        // A correct website page.
        StartCoroutine(GetSarjat(url));
        Debug.Log(sarjat.Length + " Sarjat() in OnlineKuvat");
        return sarjat;
    }*/

    public IEnumerator GetSarjat(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if(webRequest.downloadHandler.text == null){
                Debug.Log("Palvelimelta ei löytynyt kuvasarjoja");
            }
            string temp = webRequest.downloadHandler.text;
            temp = temp.Replace('"', '§');
            temp = temp.Replace("§", "");
            temp = temp.Remove(0, 1);
            temp = temp.Remove(temp.Length - 1, 1);

            sarjat = new string[temp.Split(',').Length];
            sarjat = temp.Split(',');
            RequestDone = true;
            Debug.Log(sarjat.Length + " GetSarjat IEnumerator in OnlineKuvat");
            yield return sarjat;
        }
    }

    public IEnumerator GetKuvat(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url+"/"+uri+"/"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if(webRequest.downloadHandler.text == null){
                Debug.Log("Kuvasarjasta ei löytynyt kuvia");
            }
            string temp = webRequest.downloadHandler.text;
            temp = temp.Replace('"', '§');
            temp = temp.Replace("§", "");
            temp = temp.Remove(0, 1);
            temp = temp.Remove(temp.Length - 1, 1);
            Debug.Log(temp);
            kuvat = temp.Split(',');
            yield return kuvat;
        }
    }

    public IEnumerator LataaKuva(string kuvannimi){
        using (UnityWebRequest webRequest = UnityWebRequest.Get("localhost:49011/KaikkiKuvat/KuvaSet1/" + kuvannimi))
        {
            //jotta webRequest lataa kuvan
            DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
            webRequest.downloadHandler = texDl;
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if(webRequest.result == UnityWebRequest.Result.Success){
            Debug.Log(texDl.texture);
            kuvaTexture = texDl.texture;
            RequestDone = true;
            yield return texDl.texture;
            }else{
                Debug.Log("Virhe kuvien latauksen aikana " + webRequest.error);
                Debug.Log(webRequest.result);
                yield return RequestDone;
            }
        }
    }
}
