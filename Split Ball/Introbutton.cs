using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introbutton : MonoBehaviour
{
    public int SceneNumber;
    public string SceneToLoad;
    public string Scene0;
    public string Scene1;
    public string Scene2;
    public string Scene3;
    public string Scene4;
    public string Scene5;
    int RandomScene;

    string[] Scenes = new string[] { "Scene1", "Scene2", "Scene3", "Scene4", "Scene5" };

    void Start()
    {

        SceneManager.LoadScene(Scene0);
    }

        public void tiklama()
        {

        RandomScene = Random.Range(0, Scenes.Length+1);
        SceneManager.LoadScene(RandomScene);
        Debug.Log(RandomScene);
        }

        void Update()
        {

        }
}
