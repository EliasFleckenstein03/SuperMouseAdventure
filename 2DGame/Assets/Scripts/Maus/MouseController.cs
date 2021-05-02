//Mit diesem Script kann man die Maus steuern.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumptime;
    private bool isJumping;
    private float moveInput;

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    PowerUps powerUps;

    public bool isFacingLeft;
    
    private Animation anim;
    private bool isShooting;

    private Object bulletRef;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletSpawnPos;
    [SerializeField]
    private float shootDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        
        //Hier wird der Rigidbody initialisiert
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animation>();

        powerUps = GetComponent<PowerUps>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumptime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping == true && extraJumps > 0)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            extraJumps--;
        }
        else if (Input.GetButton("Jump") && extraJumps == 0)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingLeft = true;
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = false;
        }

        if(powerUps.mouseIsGardener == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (isShooting) return;

                isShooting = true;

                GameObject b = Instantiate(bullet);
                b.GetComponent<Scissors>().StartShoot(isFacingLeft);
                b.transform.position = bulletSpawnPos.transform.position;

                Invoke("ResetShoot", shootDelay);
            }
        }
    }

    void FixedUpdate() 
    {
        //Hier wird ein Kreis unter der Maus erzeugt, der pr�ft, ob die Maus den Boden ber�hrt
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);

        //Wenn a und d oder Pfeiltaste links und rechts gedr�ckt werden, ist der Wert von moveInput -1 oder 1;
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void ResetShoot()
    {
        isShooting = false;
    }
}