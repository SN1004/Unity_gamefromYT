using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveForce = 10f;
    public float JumpForce = 11f;
    
    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    private string Walk_Animations = "Walk";
    private string Jump_Animation = "Jump";
    private SpriteRenderer sr;
    private float movementX;
    private bool onGround = true;
    private string Ground_Tag = "Ground";
    private string Enemy_Tag = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimtePlayer();
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");   
        transform.position += (new Vector3(movementX, 0f)) * Time.deltaTime * MoveForce;    
    }

    void AnimtePlayer()
    {
        if (movementX > 0 )
        {
            anim.SetBool(Walk_Animations, true);
            sr.flipX = false;
        }
        else if ( movementX < 0)
        {
            anim.SetBool(Walk_Animations, true);
            sr.flipX = true;
        }
        else 
        {
            anim.SetBool(Walk_Animations, false);   
        }
    }
    void PlayerJump()
    {
        if (Input.GetButton("Jump") && onGround )
        {
            onGround = false;
            myBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool(Jump_Animation, true);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            onGround = true;
            anim.SetBool(Jump_Animation, false);
        }
        if (collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Enemy_Tag))
            Destroy(gameObject);
    }
}
