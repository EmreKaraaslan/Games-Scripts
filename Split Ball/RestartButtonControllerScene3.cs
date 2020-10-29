using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonControllerScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Restart()
    {
    SceneManager.LoadScene("Scene3");
    
    }
  
}
