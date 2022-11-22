using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AHesapla : MonoBehaviour
{
    int ilkDeger, ikinciDeger, geciciDeger,sonDeger,sec1,sec2,sec3,skor;
    public Animator BackgroundAnimator;
    public Text ilkSayi, ikinciSayi, isaret, Secenek1, Secenek2, Secenek3,CevapMetni,PuanMetni;
    public Texture ToplamaTexture,CikarmaTexture,CarpmaTexture,BolmeTexture,bg1,bg2,bgbos;
    private string TempoOp, isaretVar;
    public Sprite SpriteDogru, SpriteYanlis, SpriteBos;
    public GameObject Canvas,DogruYanlis1, DogruYanlis2, DogruYanlis3;

    public AudioSource AudioComponent;
    public AudioClip CorrectAudio, WrongAudio;

    void Start()
    {
        Canvas.SetActive(false);  
        GameObject.Find("Main Camera").transform.position = new Vector3(0f, 0f, -10f);
        skor = 0;
    }


    void Update()
    {
    }
    public void ToplamaFonksiyonu(){
        Debug.Log(" toplama calisiyor!! ");
        TempoOp = "toplama";
        BlocksLeave();
    }
    public void CikarmaFonksiyonu()
    {
        Debug.Log(" cikarma calisiyor!! ");
        TempoOp = "cikarma";
        BlocksLeave();
    }
    public void CarpmaFonksiyonu()
    {
        Debug.Log(" carpma calisiyor!! ");
        TempoOp = "carpma";
        BlocksLeave();
    }
    public void BolmeFonksiyonu()
    {
        Debug.Log(" bolme calisiyor!! ");
        TempoOp = "bolme";
        BlocksLeave();
    }

    private void BlocksLeave()
    {
        BackgroundAnimator = GameObject.Find("Background").GetComponent<Animator>();
        BackgroundAnimator.Play("Leave");
    }

    public void AmoveCamera()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(20.17f,-0.04f,-10f);
        
        if (TempoOp=="toplama") {
            AHesaplaFn("toplama");
            GameObject.Find("BackgroundOperations").GetComponent<Renderer>().material.mainTexture = ToplamaTexture;}
        if (TempoOp == "cikarma") {
            AHesaplaFn("cikarma");
            GameObject.Find("BackgroundOperations").GetComponent<Renderer>().material.mainTexture = CikarmaTexture; }
        if (TempoOp == "carpma") {
            AHesaplaFn("carpma");
            GameObject.Find("BackgroundOperations").GetComponent<Renderer>().material.mainTexture = CarpmaTexture; }
        if (TempoOp == "bolme") {
            AHesaplaFn("bolme");
            GameObject.Find("BackgroundOperations").GetComponent<Renderer>().material.mainTexture = BolmeTexture; }



Canvas.SetActive(true);
    }

    public void MenuyeDon()
    {
        Canvas.SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(0f, 0f, -10f);
        BackgroundAnimator = GameObject.Find("Background").GetComponent<Animator>();
        BackgroundAnimator.Play("Start");
        skor = 0;
    }

   
    public void AHesaplaFn(string operasyon) {

        DegerleriSifirla();

        ilkDeger = Random.Range(1,10);
        ikinciDeger = Random.Range(1, 10);

        if (ilkDeger-ikinciDeger <0)
        {
            geciciDeger = ikinciDeger;
            ikinciDeger = ilkDeger;
            ilkDeger = geciciDeger;
        }

        if(operasyon=="toplama") {
            sonDeger = ilkDeger + ikinciDeger;
            isaretVar = "toplama";
        }
        if (operasyon == "cikarma")
        {
            sonDeger = ilkDeger - ikinciDeger;
            isaretVar = "cikarma";
        }
        if (operasyon == "carpma")
        {
            sonDeger = ilkDeger * ikinciDeger;
            isaretVar = "carpma";
        }
        if (operasyon == "bolme")
        {
            sonDeger = ilkDeger/ikinciDeger;
            isaretVar = "bolme";

            if (ilkDeger % ikinciDeger != 0 && operasyon== "bolme")
            {

                AHesaplaFn(isaretVar);
            }
        
        }

        Debug.Log("1.deger: " + ilkDeger + " 2.deger: " + ikinciDeger+ " sonuc: " +sonDeger);


        ilkSayi.text = ilkDeger.ToString();
        ikinciSayi.text = ikinciDeger.ToString();

        if (isaretVar =="toplama")
        {
            isaret.text = "+";
        }
        if (isaretVar == "cikarma")
        {
            isaret.text = "-";
        }
        if (isaretVar == "carpma")
        {
            isaret.text = "x";
        }
        if (isaretVar == "bolme")
        {
            isaret.text = "÷";
        }



        geciciDeger = Random.Range(2, 20);
        while(geciciDeger==sonDeger)
        {
            geciciDeger = Random.Range(2, 20);
        }
        sec1 = geciciDeger;

        geciciDeger = Random.Range(2, 20);
        while((geciciDeger==sonDeger)||(geciciDeger==sec1))
        {
            geciciDeger = Random.Range(2, 20);
        }
        sec2 = geciciDeger;

        Debug.Log("Secenekler: " + sec1 + " - " + sec2 + " - " + sonDeger);

        geciciDeger = Random.Range(1, 7);
        if(geciciDeger==1)
        {
            Secenek1.text = sonDeger.ToString(); Secenek2.text = sec1.ToString(); Secenek3.text = sec2.ToString();
        }
        if (geciciDeger == 2)
        {
            Secenek1.text = sonDeger.ToString(); Secenek2.text = sec2.ToString(); Secenek3.text = sec1.ToString();
        }
        if (geciciDeger == 3)
        {
            Secenek1.text = sec1.ToString(); Secenek2.text = sonDeger.ToString(); Secenek3.text = sec2.ToString();
        }
        if (geciciDeger == 4)
        {
            Secenek1.text = sec1.ToString(); Secenek2.text = sec2.ToString(); Secenek3.text = sonDeger.ToString();
        }
        if (geciciDeger == 5)
        {
            Secenek1.text = sec2.ToString(); Secenek2.text = sonDeger.ToString(); Secenek3.text = sec1.ToString();
        }
        if (geciciDeger == 6)
        {
            Secenek1.text = sec2.ToString(); Secenek2.text = sec1.ToString(); Secenek3.text = sonDeger.ToString();
        }

    }

    public void Secenek1_secim()
    {
        if(Secenek1.text==sonDeger.ToString())
        {
            DogruYanlis1.GetComponent<Image>().sprite = SpriteDogru;
            DogruCevap();
        }
        else
        {
            DogruYanlis1.GetComponent<Image>().sprite = SpriteYanlis;
            YanlisCevap();
        }
    }
    public void Secenek2_secim()
    {
        if (Secenek2.text == sonDeger.ToString())
        {
            DogruYanlis2.GetComponent<Image>().sprite = SpriteDogru;
            DogruCevap();
        }
        else
        {
            DogruYanlis2.GetComponent<Image>().sprite = SpriteYanlis;
            YanlisCevap();
        }
    }
    public void Secenek3_secim()
    {
        if (Secenek3.text == sonDeger.ToString())
        {
            DogruYanlis3.GetComponent<Image>().sprite = SpriteDogru;
            DogruCevap();
        }
        else
        {
            DogruYanlis3.GetComponent<Image>().sprite = SpriteYanlis;
            YanlisCevap();
        }
    }


    public void DegerleriSifirla()
    {
        DogruYanlis1.GetComponent<Image>().sprite = SpriteBos;
        DogruYanlis2.GetComponent<Image>().sprite = SpriteBos;
        DogruYanlis3.GetComponent<Image>().sprite = SpriteBos;

        CevapMetni.text = "?";
       
    }

    public void YanlisCevap()
    {
        AudioComponent.clip = WrongAudio;
        AudioComponent.Play();

    }
    public void DogruCevap()
    {
        CevapMetni.text = sonDeger.ToString();
        skor = skor + 1;
        PuanMetni.text = "Skor: " + skor.ToString();
        AudioComponent.clip = CorrectAudio;
        AudioComponent.Play();


        StartCoroutine(SiradakiSoru());
    }




    IEnumerator SiradakiSoru()
    {
        yield return new WaitForSeconds(2);
        AHesaplaFn(isaretVar);
    }





}


