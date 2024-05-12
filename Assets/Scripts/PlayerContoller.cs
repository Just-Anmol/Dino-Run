using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    public float jumpSpeed = 10.0f;
    private Animator anim;
    private bool OnLand;



    void Start()
    {
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Making a refrence so use multiple times
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y) ; // left right movement


        //Flip character movement
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1) ;

        // Jump movement
        if (Input.GetKey(KeyCode.Space) && OnLand)
            jump();

        //set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("OnLand", OnLand);
        anim.SetTrigger("Jump");

    }

    void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        OnLand = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Land") ;
        OnLand = true;
    }

}