using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class strike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //collider oyun objeleri aras�ndaki etkile�imler hakk�nda bilgi sa�lar burada collider labutlar�n topla temes etti�ini tespit etmeyi ama�l�yor. ontriggerenter �zel fonksiyonu topun labutlar�n alan�na girip girmedi�ine bak�yor.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="BowlingBall")
        {//collider ad� bowling topu objesine verilen adla e�le�iyorsa �arp��ma sesini oynat�r.
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
    }
}
