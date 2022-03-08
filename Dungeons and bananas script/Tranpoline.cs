using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranpoline : MonoBehaviour
{
    public float jumpfc;
    private Animator anime;

    void Start()
    {
        anime = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anime.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpfc),ForceMode2D.Impulse);
        }

    }
}
