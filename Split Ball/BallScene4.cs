using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScene4 : MonoBehaviour
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
    public TMPro.TextMeshProUGUI loseText;
    public SphereCollider BallCollider;
    


    public KeyCode moveLeft;
    public KeyCode moveRight;
    public MeshRenderer PLS;

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

    }


    void FixedUpdate()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed); //düz sabit hızla gitmesini sağlıyor
        Sphere1.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Sphere2.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Ball.transform.position.z >= 4170 || Sphere1.transform.position.z >= 4170 || Sphere2.transform.position.z >= 4170)

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
            if(Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) > 84)
            {
                BallCollider.enabled = false;
            }
            else
            {
                BallCollider.enabled = true;
            }   
            
            
            PLS.enabled = false;
            Sphere1.SetActive(true);
            Sphere2.SetActive(true);




            Sphere1.transform.Translate(Vector3.right * Time.deltaTime * speedside);
            Sphere2.transform.Translate(Vector3.left * Time.deltaTime * speedside);

            if (Sphere1.transform.position.x > 59)
            {
                Sphere1.transform.position = new Vector3(59, Sphere1.transform.position.y, Sphere1.transform.position.z);

            }

            if (Sphere2.transform.position.x < -48)
            {
                Sphere2.transform.position = new Vector3(-48, Sphere2.transform.position.y, Sphere2.transform.position.z);

            }


        }



        if (Input.GetKey(moveLeft))
        {



            Sphere2.transform.Translate(Vector3.right * Time.deltaTime * speedside);
            Sphere1.transform.Translate(Vector3.left * Time.deltaTime * speedside);

            if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) < 1)

            {
                PLS.enabled = true;
                BallCollider.enabled = true;
                Sphere1.SetActive(false);
                Sphere2.SetActive(false);
                Sphere1.transform.position = Ball.transform.position;
                Sphere2.transform.position = Ball.transform.position;

            }

        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sidecube"))
        {
            speed = 0;
            speedside = 0;
            LoseText();
            Restart();
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
