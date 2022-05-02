using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tarkista : MonoBehaviour
{
    public Button TarkistaButton;
    public PelaajanValinta PelaajanValinta;
    public CanvasController CanvasController;
    private SeuraavaTaso SeuraavaTaso;
    public GameObject UILause;
    public GameObject UIPisteet;
    private GameObject[] Paikat;
    public GameObject[] Palat;
    public int Pisteet;
    private int[] PalojenNumerot;
    public int PalatJoillaNumero = 3;
    public string[] Vastaukset = new string [1];
    private string[] VaraVastaukset;
    private string Lause;
    private string OperaattoriPaikka;
    private int[] Numerot;
    private int NLength;
    private int Numero1;
    private int Numero2 = 0;
    private int Numero3;
    private int Ensimmainen = 0;
    private int Viimeinen = 5;
    private int s = 0; 

    void Awake(){
        SeuraavaTaso = GameObject.Find("Seuraava").GetComponent<SeuraavaTaso>();
        Pisteet = SeuraavaTaso.Pisteet;
    }

    void Start(){
        TarkistaButton.onClick.AddListener(Tarkistus);
        Alku();
    }

    void Alku(){
        Paikat = GameObject.FindGameObjectsWithTag("Paikka");
        NLength = Paikat.Length / 2 + 1;
        s = 0;

        /*foreach (GameObject pala in Palat){
            if(!pala.GetComponent<Pala>().Operaattori){
                PalatJoillaNumero++;
            }
        } */
        Debug.Log("Kaiffarit joilla numero " + PalatJoillaNumero);
        PalatJoillaNumero = 3;
        PalojenNumerot = new int [PalatJoillaNumero];

        NollaaPalojenNumerot();        

        for (int i = 0; i < PalojenNumerot.Length; i++){
            if(PalojenNumerot[0] == 0){
                PalojenNumerot[0] = Random.Range(1, 10);
            }else if(i != PalojenNumerot.Length-1){
                switch (Random.Range(1, 5)){
                    case 1:
                    Debug.Log("KaiffariMasiina1");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[i - 1] + PalojenNumerot[i - 2];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] + Random.Range(1, 10);
                        }
                        break;
                    case 2:
                    Debug.Log("KaiffariMasiina2");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[i - 1] - PalojenNumerot[i - 2];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] - Random.Range(1, 10);
                        }
                        break;
                    case 3:
                    Debug.Log("KaiffariMasiina3");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[i - 1] * PalojenNumerot[i - 2];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] * Random.Range(1, 10);
                        }
                        break;
                    case 4:
                    Debug.Log("KaiffariMasiina4");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[i - 1] / PalojenNumerot[i - 2];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] / Random.Range(1, 10);
                        }
                        break;
                }
            }else{
                switch (Random.Range(1, 5)){
                    case 1:
                    Debug.Log("KaiffariMasiina1");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[0] + PalojenNumerot[1];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] + PalojenNumerot[i - 2];
                        }
                        break;
                    case 2:
                    Debug.Log("KaiffariMasiina2");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[0] - PalojenNumerot[1];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] - PalojenNumerot[i - 2];
                        }
                        break;
                    case 3:
                    Debug.Log("KaiffariMasiina3");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[0] * PalojenNumerot[1];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] * PalojenNumerot[i - 2];
                        }
                        break;
                    case 4:
                    Debug.Log("KaiffariMasiina4");
                        if(PalojenNumerot[1] != 0){
                            PalojenNumerot[i] = PalojenNumerot[0] / PalojenNumerot[1];
                        }else{
                            PalojenNumerot[i] = PalojenNumerot[i - 1] / PalojenNumerot[i - 2];
                        }
                        break;
                }
            }
            /*
            if(PalojenNumerot[i] < 1){
                if(Ensimmainen == Viimeinen)
            */
            if(PalojenNumerot[i] < 1){
                if(Ensimmainen == Viimeinen){
                    Debug.Log("Liian kauan");
                    Ensimmainen = 0;
                    PelaajanValinta.ValitseekoPelaaja();
                    return;
                }
                NollaaPalojenNumerot();
                i = 0;
                Ensimmainen++;
            }
        }

        

        AnnaPaloilleNumerot(Palat, PalojenNumerot);
        
    }

    public void AnnaPaloilleNumerot(GameObject[] PalaLista, int[] NumeroLista){
        Debug.Log(NumeroLista.Length + " length");
        for (int i = 0; i < PalaLista.Length; i++){
            if(!PalaLista[i].GetComponent<Pala>().Operaattori){
                if(NumeroLista[s] != 0){
                    PalaLista[i].GetComponent<Pala>().Numero = NumeroLista[s];
                }else{
                    int Temp = Random.Range(1,3);
                    switch (Temp){
                        case 1:
                            NumeroLista[s] = NumeroLista[s-1] + NumeroLista[s-2];
                            Debug.Log("Numerot " + NumeroLista[s-1] + " ja " + NumeroLista[s-2] + " jotka lisätään yhteen " + NumeroLista[s]);
                            break;
                        case 2:
                            NumeroLista[s] = NumeroLista[s-1] * NumeroLista[s-2];
                            Debug.Log("Numerot " + NumeroLista[s-1] + " ja " + NumeroLista[s-2] + " jotka kerrotaan yhteen " + NumeroLista[s]);
                            break;
                    }
                    PalaLista[i].GetComponent<Pala>().Numero = NumeroLista[s];
                }
                Debug.Log(PalaLista[i].GetComponent<Pala>().Numero);
                PalaLista[i].GetComponent<Pala>().Paivita();
                s++;
            }
        }
        PalojenNumerot = NumeroLista;
        OnkoUudetOikein();
    }

    void NollaaPalojenNumerot(){
        for (int i = 0; i < PalojenNumerot.Length; i++){
            PalojenNumerot[i] = 0;
        }
    }


    string LauseKaanto(string L){
        string OLause = "";
        bool Odota = true;
        for (int i = L.Length - 1; i > -1; i--)
        {
            if(!Odota){
                Numero2 = Paikat[i].GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().Numero;
                Odota = true;
            }

            OLause += L[i];
            if(L[i] == '='){
                Numero1 = Paikat[i - 1].GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().Numero;
                Odota = false;
            }
        
        }

        return OLause;
    }

    int EtsiKolmasNumero(string L){
        int N = 0;
        for (int i = L.Length - 1; i > -1; i--){
            switch (L[i]){
                        case '+':
                            if(Numero1 > Numero2){
                                N = Numero1 - Numero2;
                            }else{
                                N = Numero2 - Numero1;
                            }
                            break;
                        case '-':
                            N = Numero1 + Numero2;
                            break;
                        case '*':
                            if(Numero1 > Numero2){
                                N = Numero1 / Numero2;
                            }else{
                                N = Numero2 / Numero1;
                            }
                            break;
                        case '/':
                            N = Numero1 * Numero2;
                            break;
            }
        }

    return N;

    }




    void Tarkistus(){
        TarkistaButton.onClick.RemoveListener(Tarkistus);
        Numerot = new int [NLength];
        OperaattoriPaikka = " ";
        int I = 0;
        for (int i = Paikat.Length - 1; i > -1; i--){
            string P = "";
            I = i + 1;
            P += "Paikka (" + I.ToString() + ")";
            Paikat[i] = GameObject.Find(P);
        }
        int Numeroille = 0;
        foreach (GameObject Paikka in Paikat)
        {
            if(Paikka.GetComponent<Paikka>().VarattuPala == null){
                Debug.Log("Virheellinen määrä numeroita tai operaattoreja");
                //UILause.GetComponent<TextMeshProUGUI>().text = "Täytä kaikki tyhjät neliöt numeroilla tai operaattoreilla.";
                StartCoroutine(Alusta());
                return;
            }else if(Paikka.GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().Operaattori){
                switch (Paikka.GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().operaattori){
                    case "+":
                        Lause += "+";
                        OperaattoriPaikka += "+";
                        break;
                    case "-":
                        Lause += "-";
                        OperaattoriPaikka += "-";
                        break;
                    case "*":
                        Lause += "*";
                        OperaattoriPaikka += "*";
                        break;
                    case "/":
                        Lause += "/";
                        OperaattoriPaikka += "/";
                        break;
                    case "=":
                        Lause += "=";
                        OperaattoriPaikka += "=";
                        break;
                }

            }else{
                Lause += Paikka.GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().Numero.ToString();
                if(Numeroille < Numerot.Length){
                Numerot[Numeroille] = Paikka.GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().Numero;
                Numeroille++;
                }
            }
        }
        //Lause = LauseKaanto(Lause);
        //laske onko yhtälö oikein

        //Numero3 = EtsiKolmasNumero(Lause);
        //Ensimmainen = Paikat[0].GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().Numero;
        //Viimeinen = Paikat[Paikat.Length - 1].GetComponent<Paikka>().VarattuPala.GetComponent<Pala>().Numero;
        OnkoOikein();





        Debug.Log(Numero1 +" "+ Numero2 +" "+ Numero3);
        //Lause += "\n";
        //UILause.GetComponent<TextMeshProUGUI>().text += Lause;
        StartCoroutine(Alusta());
    }

    void OnkoOikein(){
        Debug.Log("NLength " + Numerot.Length);
        Numero1 = 0;
        Numero2 = 0;
        for (int i = 0; i <= Numerot.Length - 1; i++){
            if(Numero2 == 0){
                if(OperaattoriPaikka[i] == '='){
                    Numero2 = Numerot[i];
                }else
                if(OperaattoriPaikka[i] == '+' || OperaattoriPaikka[i] == ' '){
                    Numero1 += Numerot[i];
                }else if(OperaattoriPaikka[i] == '-'){
                    Numero1 -= Numerot[i];
                }else if(OperaattoriPaikka[i] == '*'){
                    Numero1 *= Numerot[i];
                }else if(OperaattoriPaikka[i] == '/'){
                    Numero1 /= Numerot[i];
                }
            }else{
                if(OperaattoriPaikka[i] == '+'){
                    Numero2 += Numerot[i];
                }else if(OperaattoriPaikka[i] == '-'){
                    Numero2 -= Numerot[i];
                }else if(OperaattoriPaikka[i] == '*'){
                    Numero2 *= Numerot[i];
                }else if(OperaattoriPaikka[i] == '/'){
                    Numero2 /= Numerot[i];
                }
            }
        }
        if(Numero1 == Numero2){
            Debug.Log("Yhtälö toimii");
            foreach (string Yhtalo in Vastaukset){
                if(Yhtalo == Lause){
                    Debug.Log("Mutta se on jo käytetty");
                    return;
                }
            }
                VaraVastaukset = Vastaukset;
                Vastaukset = new string [Vastaukset.Length+1];
                for (int i = 0; i <= VaraVastaukset.Length; i++){
                    if(i == VaraVastaukset.Length){
                        Vastaukset[i] = Lause;
                        Debug.Log("Vastaukset array valmis");
                        Pisteet += Vastaukset.Length;
                        UIPisteet.GetComponent<TextMeshProUGUI>().text = Pisteet.ToString();
                        Lause += "\n";
                        UILause.GetComponent<TextMeshProUGUI>().text += Lause;
                        Lause = "";
                        Debug.Log("Lause nollattu");
                        SeuraavaTaso.gameObject.SetActive(true);
                        //CanvasController.UudetKortitNappi(SeuraavaTaso.gameObject);
                    }else{
                    Vastaukset[i] = VaraVastaukset[i];
                    }
                }
        }else{
            Debug.Log("Yhtälö ei toimi");
        }
    }

    string TempOperaattorit(){
        int Temp = Random.Range(1,5);
        string TempString = " ";
        if(true){
            switch (Temp){
                case 1:
                    TempString += "-=-";
                    break;
                case 2:
                    TempString += "/=/";
                    break;
                case 3:
                    TempString += "+=+";
                    break;
                case 4:
                    TempString += "*=*";
                    break;
            }
        return TempString;
        }
        
    }

    bool OnkoUudetOikein(){
        string TempOperaattori = TempOperaattorit();
        for (int u = 0; u <= PalojenNumerot.Length - 1; u++){
            if(Numero2 == 0){
                if(TempOperaattori[u] == '='){
                    Numero2 = PalojenNumerot[u];
                }else
                if(TempOperaattori[u] == '+' || TempOperaattori[u] == ' '){
                    Numero1 += PalojenNumerot[u];
                }else if(TempOperaattori[u] == '-'){
                    Numero1 -= PalojenNumerot[u];
                }else if(TempOperaattori[u] == '*'){
                    Numero1 *= PalojenNumerot[u];
                }else if(TempOperaattori[u] == '/'){
                    Numero1 /= PalojenNumerot[u];
                }
            }else{
                if(TempOperaattori[u] == '+'){
                    Numero2 += PalojenNumerot[u];
                }else if(TempOperaattori[u] == '-'){
                    Numero2 -= PalojenNumerot[u];
                }else if(TempOperaattori[u] == '*'){
                    Numero2 *= PalojenNumerot[u];
                }else if(TempOperaattori[u] == '/'){
                    Numero2 /= PalojenNumerot[u];
                }
            }
        }
        if(Numero1 == Numero2){
            Debug.Log("Yhtälö toimii");
            return true;
        }else{
            Debug.Log("Yhtälö ei toimi");
            return false;
        }
    }


    private IEnumerator Alusta(){
        yield return new WaitForSeconds(2);
        Lause = "";
        //UILause.GetComponent<TextMeshProUGUI>().text = Lause;
        Numero1 = 0;
        Numero2 = 0;
        Numero3 = 0;
        Ensimmainen = 0;
        Viimeinen = 0;
        TarkistaButton.onClick.AddListener(Tarkistus);
    }

    public void SeuraavatNumerot(){
        foreach (Transform Pala in GameObject.Find("BG/BGRect").transform){
            if(Pala.gameObject.GetComponent<Pala>() != null){
                Pala.gameObject.GetComponent<Pala>().ResetTransform();
            }
        }
        VaraVastaukset = new string [0];
        Vastaukset = new string [0];
        Lause = "";
        Numero1 = 0;
        Numero2 = 0;
        Numero3 = 0;
        Ensimmainen = 0;
        Viimeinen = 0;
        s = 0;
        //PalatJoillaNumero = 0;
        PelaajanValinta.UILause.GetComponent<TextMeshProUGUI>().text = "";
        UILause.GetComponent<TextMeshProUGUI>().text = "";
        Alku();
    }


}
