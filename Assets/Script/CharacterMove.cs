using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    const int MAX_HEALTH = 100;
    private int health;
    [SerializeField] float speed = 5.0f;
    Vector3 inputVector;
    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MAX_HEALTH;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        inputVector = new Vector3(horizontalInput, verticalInput, 0);
        //MoveByTransformTranslate(horizontalInput, verticalInput);
        //MoveByTransform(horizontalInput, verticalInput);
    }
    private void FixedUpdate()
    {
        MoveByRigidbody2dForce();
    }
    void MoveByRigidbody2dForce()
    {
        Vector3 forceVector = inputVector * speed;
        rb2d.AddForce(forceVector);
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
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

        }
    }
}
