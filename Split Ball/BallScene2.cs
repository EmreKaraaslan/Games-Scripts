using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScene2 : MonoBehaviour
{
    public float speed = 20f;
    private float speedside = 20f;
    private Rigidbody rbBall;
    private Rigidbody rbSphere1;
    private Rigidbody rbSphere2;
    Vector3 originalPosBall;
    Vector3 originalPosSphere1;
    Vector3 originalPosSphere2;
    private Vector3 newPositionSphere1;
    private Vector3 newPositionSphere2;
    private string SplitButton;
    public GameObject Button;
    public GameObject RestartButton;
    public GameObject Ball;
    public GameObject Sphere1;
    public GameObject Sphere2;
    public TMPro.TextMeshProUGUI WinText;


    public KeyCode moveLeft;
    public KeyCode moveRight;
    public MeshRenderer PLS;
    public TMPro.TextMeshProUGUI loseText;

    void Start()
    {
        rbBall = Ball.GetComponent<Rigidbody>();
        rbSphere1 = Sphere1.GetComponent<Rigidbody>();
        rbSphere2 = Sphere2.GetComponent<Rigidbody>();


        originalPosBall = new Vector3(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);

        originalPosSphere1 = new Vector3(Sphere1.transform.position.x, Sphere1.transform.position.y, Sphere1.transform.position.z);

        originalPosSphere2 = new Vector3(Sphere2.transform.position.x, Sphere2.transform.position.y, Sphere2.transform.position.z);

        newPositionSphere1 = Sphere1.transform.position;
        newPositionSphere2 = Sphere2.transform.position;

        Button.SetActive(false);
        RestartButton.SetActive(false);
        Sphere1.SetActive(false);
        Sphere2.SetActive(false);
        WinText.text = "";
        loseText.text = "";
        Ball.GetComponent<Rigidbody>().useGravity = true;
    }


    void FixedUpdate()
    {
      
        transform.Translate(Vector3.forward * Time.deltaTime * speed); //düz sabit hızla gitmesini sağlıyor
        Sphere1.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Sphere2.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Ball.transform.position.z >= 950 || Sphere1.transform.position.z >= 950 || Sphere2.transform.position.z >= 950)

        {
            ExitText();
            Button.SetActive(true);
            speed = 0;
            speedside = 0;

        }

    }
   


    void Update()
    {
        Debug.Log(Ball.transform.position);

        if (Input.GetKey(moveRight))
        {

            PLS.enabled = false;
            Sphere1.SetActive(true);
            Sphere2.SetActive(true);

            


            Sphere1.transform.Translate(Vector3.right * Time.deltaTime * speedside);
            Sphere2.transform.Translate(Vector3.left * Time.deltaTime * speedside);

            if (Sphere1.transform.position.x > 45)
            {
                Sphere1.transform.position = new Vector3(45, Sphere1.transform.position.y, Sphere1.transform.position.z);

            }

            if (Sphere2.transform.position.x < -34)
            {
                Sphere2.transform.position = new Vector3(-34, Sphere2.transform.position.y, Sphere2.transform.position.z);

            }

          
        }



        if (Input.GetKey(moveLeft))
        {

           

            Sphere2.transform.Translate(Vector3.right * Time.deltaTime * speedside);
            Sphere1.transform.Translate(Vector3.left * Time.deltaTime * speedside);

            if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) < 1)

            {
                
                PLS.enabled = true;
                Sphere1.SetActive(false);
                Sphere2.SetActive(false);
                Sphere1.transform.position = Ball.transform.position;
                Sphere2.transform.position = Ball.transform.position;
            }

        }


        if (Sphere1.transform.position.y < -2 || Sphere2.transform.position.y < -2 || Ball.transform.position.y<-2)
        {
            LoseText();
            Restart();

        }

        if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) > 1)
        { Ball.GetComponent<Rigidbody>().useGravity = false; 
        }

        if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) <= 1)
        {
            Ball.GetComponent<Rigidbody>().useGravity = true;
        }

    }

    void ExitText()
    {
        WinText.text = "You Win!";
    }

    void LoseText()
    {
        loseText.text = "You Lost!";
    }

    void Restart()
    {
        RestartButton.SetActive(true);
    }
}
