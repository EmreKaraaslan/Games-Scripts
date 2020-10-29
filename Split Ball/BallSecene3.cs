using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSecene3 : MonoBehaviour
{
    public float speed = 20f;
    public float speedside = 20f;
    public float speedspheres = 10f;
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
    public float jumpForce = 7f;



    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode Jump;
    public MeshRenderer BallRenderer;
    public MeshRenderer Sphere1Renderer;
    public MeshRenderer Sphere2Renderer;
    public SphereCollider BallCollider;
    public SphereCollider Sphere1Collider;
    public SphereCollider Sphere2Collider;
    public LayerMask groundLayers;


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

        if (Ball.transform.position.z >= 4100 || Sphere1.transform.position.z >= 4100 || Sphere2.transform.position.z >= 4100)

        {
           
            Button.SetActive(true);
            speed = 0;
            speedside = 0;

        }

    }


    void Update()
    {
        if(Ball.transform.position.y<102f)
        {
            Ball.transform.position = new Vector3(Ball.transform.position.x, 102.1f, Ball.transform.position.z);
        }
       Debug.Log(Ball.transform.position);

    
        if(IsGrounded())
        {
        
            if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) < 1)
            {
                BallCollider.enabled = true;
               
            }
       

            Sphere1Collider.enabled = true;
            Sphere2Collider.enabled = true;
       

            if (Input.GetKey(moveRight))
            {
                speedside = 20f;
                BallCollider.enabled = false;
                
                BallRenderer.enabled = false;
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

                    Sphere1.transform.position = Ball.transform.position;
                    Sphere2.transform.position = Ball.transform.position;
                    BallCollider.enabled = true;
                    
                    BallRenderer.enabled = true;
                    Sphere1.SetActive(false);
                    Sphere2.SetActive(false);
                    speedside = 0;

                }


                if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) > 1)

                {


                    BallCollider.enabled = false;
                    

                }

            }

        }     

        if ((Ball.transform.position.z < 3730 && 3680 < Ball.transform.position.z) || (Sphere2.transform.position.z < 3730 && 3680 < Sphere2.transform.position.z) || (Sphere1.transform.position.z < 3730 && 3680 < Sphere1.transform.position.z))
        { 
            if (Input.GetKey(Jump) && Ball.transform.position.y<=102.5f)
                {
                    rbBall.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                   rbSphere1.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    rbSphere2.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                     

                }
        }

        

     

        if (!IsGrounded())

           
        {
            Sphere1.transform.position = new Vector3 (Sphere1.transform.position.x,Ball.transform.position.y, Sphere1.transform.position.z);
            Sphere2.transform.position = new Vector3(Sphere2.transform.position.x, Ball.transform.position.y, Sphere2.transform.position.z);
            Ball.GetComponent<Rigidbody>().useGravity = true;

            if (Input.GetKey(moveRight))
            {

                Sphere1.SetActive(true);
                Sphere2.SetActive(true);
                BallRenderer.enabled = false;

                Sphere1.transform.Translate(Vector3.right * Time.deltaTime * speedside);
                Sphere2.transform.Translate(Vector3.left * Time.deltaTime * speedside);
            }

            if (Input.GetKey(moveLeft))
            {
                Sphere2.transform.Translate(Vector3.right * Time.deltaTime * speedside);
                Sphere1.transform.Translate(Vector3.left * Time.deltaTime * speedside);

            }

            if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) < 1)

            {
                Ball.GetComponent<Rigidbody>().useGravity = true;
                BallCollider.enabled = true;
                BallRenderer.enabled = true;
                Sphere1.transform.position = Ball.transform.position;
                Sphere2.transform.position = Ball.transform.position;
                

            }

            if (Mathf.Abs(Sphere1.transform.position.x - Sphere2.transform.position.x) > 1)

            {
                BallCollider.enabled = false;
                
                BallRenderer.enabled = false;
                Sphere1.SetActive(true);
                Sphere2.SetActive(true);
               
                
            }


        }



        if (Ball.transform.position.z >= 3900 || Sphere1.transform.position.z >= 3900 || Sphere2.transform.position.z >= 3900)
        {
            ExitText();
            Ball.transform.Translate(Vector3.zero);
            Sphere1.transform.Translate(Vector3.zero);
            Sphere2.transform.Translate(Vector3.zero);
        }

        bool IsGrounded()
        {
            return Physics.CheckCapsule(BallCollider.bounds.center, new Vector3(BallCollider.bounds.center.x, BallCollider.bounds.min.y, BallCollider.bounds.center.z), BallCollider.radius * .5f, groundLayers);
        }
    }


    void OnTriggerEnter(Collider other)

    {
      
        if (other.gameObject.CompareTag("Sidecube"))
        {
            GameEnd();
        }

    }

    public void GameEnd()
    {

        speed = 0;
        speedside = 0;
        LoseText();
        Restart();

    }

    void Restart()
    {
        RestartButton.SetActive(true);
    }

    void LoseText()
    {
        loseText.text = "You Lost!";
    }

    void ExitText()
    {
        WinText.text = "You Win!";
    }
}
