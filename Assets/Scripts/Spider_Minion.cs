using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Minion : MonoBehaviour
{
    private bool Facingright;
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed ;
    private bool hit;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        hit= false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x > transform.position.x)
        {
            Facingright= true;
            transform.Rotate(0,180f,0);
        }
        else
        {
            Facingright= false;
        }
            rb =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,new Vector2(player.transform.position.x,transform.position.y),speed * Time.deltaTime);

        Flip();

        if (hit)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Rigidbody2D>().GetComponent<Collider2D>(), true);
            timer += Time.deltaTime;
        }
        if (timer > 2)
        {
            timer = 0;
            hit = false;
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Rigidbody2D>().GetComponent<Collider2D>(), false);
        }
    }

    private void Flip()
    {

        if (player.transform.position.x > transform.position.x)
        {
            if (!Facingright)
            {
                transform.Rotate(0, 180f, 0);
                Facingright = !Facingright;
            }
        }
        else
        {
            if (Facingright)
            {
                Facingright = !Facingright;
                transform.Rotate(0, 180f, 0);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player_Health player_hp = collision.gameObject.GetComponent<Player_Health>();
        if(player_hp != null)
        {
            hit = true;
            player_hp.TakeDamage(10);
        }
    }
}
