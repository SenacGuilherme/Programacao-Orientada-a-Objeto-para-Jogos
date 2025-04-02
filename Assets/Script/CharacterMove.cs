using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    const float MAX_HEALTH = 100;
    private int health;
    [SerializeField] float speed = 5.0f;
    Vector3 inputVector;
    Rigidbody2D rb2d;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool jumpRequested = false;
    [SerializeField] float jumpForce = 1f;
    public PlayerData playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerData.Health = MAX_HEALTH;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Awake()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        inputVector = new Vector3(horizontalInput, verticalInput, 0);
        MoveByTransformTranslate(horizontalInput, verticalInput);
        //MoveByTransform(horizontalInput, verticalInput);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
            Debug.Log("PULOU!");
        }
    }
    private void FixedUpdate()
    {
        MoveByRigidbody2dForce();
        if (jumpRequested)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            jumpRequested = false;
            Debug.Log("Pulo Acionado!");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Colidiu com o Chão!");
        }
    }
    void MoveByRigidbody2dForce()
    {
        //Vector3 forceVector = inputVector * speed;
        //rb2d.AddForce(forceVector);
    }
    void MoveByTransform(float horizontalInput, float verticalInput)
    {
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
        transform.position = newPosition;
    }
    void MoveByTransformTranslate(float horizontalInput, float verticalInput)
    {
        Vector3 movenent = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
        transform.Translate(movenent);
    }
    void Move()
    {

    }
    void Jump()
    {

    }
    public void TakeDamage(float damage)
    {
        playerData.Health -= damage;
        if (playerData.Health <= 0)
        {
            Debug.Log("Mó-rreu");
        }
    }

    public void OnTriggerEnter2D(Collider2D ObjetoColidido)
    {
        Debug.Log("Entrou em colisão com um Trigger");
        if (ObjetoColidido.gameObject.CompareTag("Hazard"))
        {
            TakeDamage(10);
        }
    }

}
