using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballmove : MonoBehaviour
{
    
    public Rigidbody r1;
    /*
     Rigidbody, Unity fizik motorunu kullanarak gerçek dünyada olduðu gibi fiziksel hareketlerin taklit edilmesini saðlar. Sürtünme kuvveti yerçekimi...
    topun rigidbody'sinin referansýna ihtiyacýmýz olduðu için tanýmlandý.
     */
    [SerializeField]//public demeye göre daha güvenli bir þekilde editöre dahil ediyor.
    float power;
    // sahne yüklendiðinde çalýþan fonksiyon
    void Start()
    {
        r1 = GetComponent<Rigidbody>();//editörde bulunan topun rigidbody özelleðini r1 isimli deðiþkene atamýþ olduk.
    }
    
    // her framede kullanýlan fonksiyon.
    void Update()
    {
        //klavyedeki enter tuþuna basýlýrsa true döner.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            r1.AddForce(Vector3.forward *power);
            AudioSource source = GetComponent<AudioSource>();
            //editörde bulunan sesi yakaladýk.
            //kýsaca enter a basýlýnca ses tetiklenir, top hareket eder.
            source.Play();
        }




    }

}
