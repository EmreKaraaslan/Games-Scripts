using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public TMPro.TextMeshProUGUI exitText;
    public TMPro.TextMeshProUGUI countText;
    public LayerMask groundLayers;
    public float jumpForce = 7;
    public SphereCollider col;
    public ParticleSystem effect;

    private Rigidbody rb;
    private int count;
    Vector3 originalPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 12;
        SetCountText();
        exitText.text = " ";
        col = GetComponent<SphereCollider>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
            effect.Play();

            Color color = new Color(Random.value, Random.value, Random.value);
            GetComponent<Renderer>().material.color = color;

        }
    }


    void Update()
    {

        if (gameObject.transform.position.x > 7 || gameObject.transform.position.x < -12 || gameObject.transform.position.z > 12 || gameObject.transform.position.z < -7)
        {
            gameObject.transform.position = originalPos;

        }
    }

    void ExitText()
    {

        exitText.text = "You Win! \n Your Game is Over! ";

    }

    void QuitCode()
    {

        Application.Quit();

    }
    void SetCountText()
    {
        countText.text = "Left Item: " + count.ToString();
        if (count <= 0)
        {
            ExitText();
        }

        Invoke("QuitCode", 3f);
    }
}