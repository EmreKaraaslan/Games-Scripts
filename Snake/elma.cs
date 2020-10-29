using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elma : MonoBehaviour
{
    public TMPro.TextMeshProUGUI skor_txt;
    int skor;
    hareket manager;
    void Start()
    {
        skor = 0;
        skor_txt.text = "SCOR: " + skor;
        manager = GameObject.Find("bas").GetComponent<hareket>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="bas")
        {
           
            skor += 10;
            manager.hiz += 0.5f;
            skor_txt.text = "SCOR: " + skor;
            manager.kuyruk_arttır();
        }

        if (other.gameObject.tag == "kuyruk")
        {
            koordinat_degistir();
        }
    }

    void koordinat_degistir()
    {
        float deger_x = Random.Range(-11, 11);
        float deger_z = Random.Range(-12, 12);
        transform.position = new Vector3(deger_x, 0.39f, deger_z);

    }
}
