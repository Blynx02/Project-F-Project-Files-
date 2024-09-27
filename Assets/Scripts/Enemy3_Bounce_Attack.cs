using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy3_Bounce_Attack : MonoBehaviour
{
    [SerializeField]
    private int angle;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    private Vector2 direction;
    [SerializeField]
    private bool Facingright;
    private bool Up = true;
    private bool first_hit = true;
    private bool first_col = true;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    public void Clone_S()
    {
        if (Facingright)
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
     
    private void OnCollisionEnter2D(Collision2D collision) //BOUNCE GO
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
        {
            if (first_hit)
            {
                if (!Facingright)
                {
                    Facingright= !Facingright;
                    direction = new Vector2(-1 * ((float)Math.Cos((Math.PI / 2) + (Mathf.Deg2Rad * angle))), (float)Math.Sin((Math.PI / 2) + (Mathf.Deg2Rad * angle))).normalized;
                }
                else
                {
                    Facingright = !Facingright;
                    direction = new Vector2((float)Math.Cos((Math.PI / 2) + (Mathf.Deg2Rad * angle)),(float)Math.Sin((Math.PI / 2) + (Mathf.Deg2Rad * angle))).normalized;
                }
                first_hit= false;
            }
            else
            {
                if (!Facingright & Up) //up and left
                {
                    if (collision.gameObject.name == "Wall1") //go up and right
                    {
                        direction.x = -direction.x;
                        Facingright = !Facingright;
                    }
                    else if (collision.gameObject.name == "Wall2") //go down and left
                    {
                        direction.y = -direction.y;
                        Up = !Up;
                    }
                }
                else if (Facingright & !Up)// down and right
                {
                    if (collision.gameObject.name == "Wall3") //go down and left
                    {
                        direction.x = -direction.x;
                        Facingright = !Facingright;
                    }
                    else if (collision.gameObject.name == "Platform") //go up and right
                    {
                        direction.y = -direction.y;
                        Up = !Up;
                    }
                }
                else if (Facingright & Up) //up and right
                {
                    if (collision.gameObject.name == "Wall2") //go down and right
                    {
                        direction.y = -direction.y;
                        Up = !Up;
                    }
                    else if (collision.gameObject.name == "Wall3") //go up and left
                    {
                        direction.x = -direction.x;
                        Facingright = !Facingright;
                    }
                }
                else //down and left
                {
                    if (collision.gameObject.name == "Platform") //go up and left
                    {
                        direction.y = -direction.y;
                        Up = !Up;
                    }
                    else if (collision.gameObject.name == "Wall1") //go down and right
                    {
                        direction.x = -direction.x;
                        Facingright = !Facingright;
                    }
                }
            }
        }
    }
}
