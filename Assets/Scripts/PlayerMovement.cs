using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public float speed = 5;
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    public float jumpForce = 11f;
    private Rigidbody2D myBody;
    private float movementX;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";
    private Animator anim;
    [SerializeField]
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string MONSTER_TAG = "Monster";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }
    // private body = RigidBody2D;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyboard();
        PlayerJump();
        AnimatePlayer();
        // body = GetComponent<RigidBody2D>;
        // body.transform += GetAxisRaw("Horizontal") * speed * forceSpeed;
    }

    // private void FixedUpdate()
    // {
    // }
    void PlayerMovementKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(MONSTER_TAG))
        {
            Destroy(gameObject);
        }
    }
}
