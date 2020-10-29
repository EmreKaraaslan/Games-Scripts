using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro.Examples;

public class hareket : MonoBehaviour
{
    public GameObject kuyruk;
    List<GameObject> kuyruklar;
    Vector3 eski_posizyon;
    GameObject eski_kuyruk;
    public float hiz = 5.0f;
    public KeyCode turnLeft;
    public KeyCode turnRight;
    bool turn;
    public TMPro.TextMeshProUGUI lose_txt;
    public GameObject Button;
    GameObject yeni_kuyruk;


    void Start()
    {
        turn = true;
        kuyruklar = new List<GameObject>();

        for (int i = 0; i < 2; i++)
        {
            yeni_kuyruk = Instantiate(kuyruk, new Vector3(0, 0.39f, i * 10.0f), Quaternion.identity);
            kuyruklar.Add(yeni_kuyruk);
        }

        
        lose_txt.text = "";
        Button.SetActive(false);
    }


    void Update()
    {
        turn = true;
        hareket_et();

        if (turn == true && Input.GetKeyDown(turnRight))
        {
            transform.Rotate(0, 90f, 0);

        }


        if (turn == true && Input.GetKeyDown(turnLeft))
        {
            transform.Rotate(0, -90f, 0);

        }
    }


    void hareket_et()
    {
        eski_posizyon = transform.position;
        transform.Translate(0, 0, hiz * Time.deltaTime);

        if (kuyruklar.Count >= 1)
        {
            kuyruklar.Last().transform.position = eski_posizyon;
            kuyruklar.Insert(0, kuyruklar.Last());
            kuyruklar.RemoveAt(kuyruklar.Count - 1);

        }

    }
    void kuyruk_takip()
    {
        kuyruklar.Last().transform.position = eski_posizyon;
        eski_kuyruk = kuyruklar[0];
     


    }
    public void kuyruk_arttır()
    {

        GameObject yeni_kuyruk = Instantiate(kuyruk, new Vector3(0, 0.39f, 1), Quaternion.identity);
        kuyruklar.Add(yeni_kuyruk);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Duvar")
        {
            hiz = 0;
            Time.timeScale = 0.0f;
            lose_txt.text = "You Lost!";
            Button.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }


}



