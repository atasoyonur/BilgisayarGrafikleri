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
    //collider oyun objeleri arasýndaki etkileþimler hakkýnda bilgi saðlar burada collider labutlarýn topla temes ettiðini tespit etmeyi amaçlýyor. ontriggerenter özel fonksiyonu topun labutlarýn alanýna girip girmediðine bakýyor.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="BowlingBall")
        {//collider adý bowling topu objesine verilen adla eþleþiyorsa çarpýþma sesini oynatýr.
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
    }
}
