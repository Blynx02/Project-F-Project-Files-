using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_Horizontal_Attack : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    private Vector2 direction;
    [SerializeField]
    private bool FacingRight;
    private bool first_col = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Clone_B()
    {
        if (FacingRight)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Health player_hp = collision.gameObject.GetComponent<Player_Health>();
        if (player_hp != null)
        {
            player_hp.TakeDamage(5);
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), rb.GetComponent<Collider2D>(), true);
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                if (!(GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().health == 0))
                {
                    Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), rb.GetComponent<Collider2D>(), false);
                }
            }
        }

        if (first_col)
        {
            first_col = false;
        }
        else
        {   if (!FacingRight)
            {
                if (collision.gameObject.name == "Wall1")
                {
                    Flip(1);
                }
                else if (collision.gameObject.name == "Wall2")
                {
                    Flip(3);
                }
                else if (collision.gameObject.name == "Wall3")
                {
                    Flip(2);
                }
                else if (collision.gameObject.name == "Platform")
                {
                    Flip(0);
                }
            }
            else
            {
                if (collision.gameObject.name == "Wall1")
                {
                    Flip(2);
                }
                else if (collision.gameObject.name == "Wall2")
                {
                    Flip(0);
                }
                else if (collision.gameObject.name == "Wall3")
                {
                    Flip(1);
                }
                else if (collision.gameObject.name == "Platform")
                {
                    Flip(3);
                }
            }
        }
    }
    private void Flip(int dir) // left:0 up:1 down:2 right:3
    {
        if (dir == 0)
        {
            direction = Vector2.left;
            speed += 2;
        }
        else if (dir == 1)
        {
            direction = Vector2.up;
            speed += 2;
        }
        else if (dir == 2)
        {
            direction = Vector2.down;
            speed += 2;
        }
        else
        {
            direction = Vector2.right;
            speed += 2;
        }
    }
}
