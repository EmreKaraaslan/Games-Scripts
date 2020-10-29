using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereScene5 : MonoBehaviour
{
    
    public TMPro.TextMeshProUGUI CountText;
    public ScoreManager manager;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sidecube"))
        {
            other.gameObject.SetActive(false);
            manager.AddPoints(1);
           
        }
    }
       
}
