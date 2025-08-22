using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charCon;

    private float movX;
    private float movZ;

    [Range(0f, 100f)]
    public float movSpeed;

    [Range(0f, 100f)]
    public float jumpForce;

    private Vector3 velY;
    public float gravity = -9.8f;

    [Header("Deteccion Suelo")]
    public Transform grndCheck;
    public bool isGrounded;
    public float radio;
    public LayerMask whatIsGround;
    private void Awake()
    {
        charCon = GetComponent<CharacterController>();
        grndCheck = transform.GetChild(0);
    }

    
    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        movX = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        movZ = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;

        Vector3 movimiento = transform.right * movX + transform.forward * movZ;
        charCon.Move(movimiento);
    }

    private void Jump()
    {
        isGrounded = Physics.CheckSphere(grndCheck.position, radio, whatIsGround);

        velY.y += gravity * Time.deltaTime;
        charCon.Move(velY * Time.deltaTime);

        if (isGrounded && velY.y <= 0)
        {
            velY.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velY.y = Mathf.Sqrt(jumpForce * gravity * -2);
        }

    }
}
