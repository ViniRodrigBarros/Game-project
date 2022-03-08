using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rig;
    public float jumpforce;
    public bool isjunping;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }
    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f , 0f);
        transform.position += movement * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }


    }
    void jump()
    {
        if (Input.GetButtonDown("Jump") && !isjunping)
        {
            rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isjunping = false;
        }
        if (collision.gameObject.tag =="Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "saw")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        { 
            isjunping = true;
        }
    }
}
