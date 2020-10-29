using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    //int RandomScene;
    //public string Scene1;
    //public string Scene2;
    //public string Scene3;
    //public string Scene4;
    //public string Scene5;
    Scene CurrentScene;

    //public string[] Scenes = new string[] { "Scene0","Scene1", "Scene2", "Scene3", "Scene4", "Scene5" };
    List<string> Scenes = new List<string>();

    void Start()
    {
       // Scenes.Add("Scene1");
       // Scenes.Add("Scene2");
       // Scenes.Add("Scene3");
       // Scenes.Add("Scene4");
       // Scenes.Add("Scene5");
       //// CurrentScene = SceneManager.GetActiveScene();
       // Scenes.Remove("SceneManager.GetActiveScene()");
    }

    public void tiklama()
    {

        int index = Random.Range(1, 5);
        SceneManager.LoadScene(index);

        //RandomScene = Random.Range(0, Scenes.Count);
        //SceneManager.LoadScene(RandomScene);
        //Debug.Log(RandomScene);

    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
