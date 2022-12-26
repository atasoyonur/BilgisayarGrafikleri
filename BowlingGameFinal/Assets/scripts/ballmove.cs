using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballmove : MonoBehaviour
{
    
    public Rigidbody r1;
    /*
     Rigidbody, Unity fizik motorunu kullanarak ger�ek d�nyada oldu�u gibi fiziksel hareketlerin taklit edilmesini sa�lar. S�rt�nme kuvveti yer�ekimi...
    topun rigidbody'sinin referans�na ihtiyac�m�z oldu�u i�in tan�mland�.
     */
    [SerializeField]//public demeye g�re daha g�venli bir �ekilde edit�re dahil ediyor.
    float power;
    // sahne y�klendi�inde �al��an fonksiyon
    void Start()
    {
        r1 = GetComponent<Rigidbody>();//edit�rde bulunan topun rigidbody �zelle�ini r1 isimli de�i�kene atam�� olduk.
    }
    
    // her framede kullan�lan fonksiyon.
    void Update()
    {
        //klavyedeki enter tu�una bas�l�rsa true d�ner.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            r1.AddForce(Vector3.forward *power);
            AudioSource source = GetComponent<AudioSource>();
            //edit�rde bulunan sesi yakalad�k.
            //k�saca enter a bas�l�nca ses tetiklenir, top hareket eder.
            source.Play();
        }




    }

}
