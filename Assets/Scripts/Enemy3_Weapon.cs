using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy3_Weapon : MonoBehaviour
{
    [SerializeField]
    private Collider2D Ground_line;
    [SerializeField]
    private Collider2D Body;
    [SerializeField]
    private int angle;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]
    private float speed;
    private Vector2 direction;
    private bool Model_facing_right;
    private bool Facingright;
    private bool Up;
    private bool first_hit ;
    private bool first_col;
    private int move;
    private int hit_count;
    private int dmg;
    public Transform firePoint;
    private GameObject player ;
    public GameObject bulletPrefab;
    private string prev_col = "Platform";
    private bool func_called = false;
    private bool isEnraged;
    private float timer;
    private bool hit;
    // Start is called before the first frame update
    private void Start()
    {
        timer = 0;
        hit = false;
        player = GameObject.FindGameObjectWithTag("Player");
        Model_facing_right = false;
        first_col = true;
        first_hit = true;
        Up = true;
        hit_count= 0;
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            dmg = 15;
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            dmg = 20;
        }
        else
        {
            dmg = 28;
        }
    }
    public void Horizontal_Attack(bool facing)
    {
        func_called = true;
        Ground_line.enabled = false;
        Body.enabled = true;
        speed = 10;
        first_hit = true;
        Up = true;
        
        hit_count = 0;
        Facingright = facing;
        move= 0;
        if (Facingright)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
    }

    public void Bounce_Attack(bool facing) 
    {
        func_called = true;
        Ground_line.enabled = false;
        Body.enabled= true;
        Facingright = facing;
        hit_count = 0;
        Up = true;
        first_hit = true;
        if(isEnraged)
        {
            speed= 17;
        }
        else
        {
            speed = 12;
        }
        move = 1;
        if (Facingright)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
    }

    void Update()
    {
        isEnraged = GetComponent<Enemy>().Enraged;
        if (isEnraged)
        {
            anim.SetBool("Enraged", isEnraged);
        }
        if (!func_called)
        {
            Flip_Model();
        }
        rb.velocity = direction * speed;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Health player_hp = collision.gameObject.GetComponent<Player_Health>();
        if (player_hp != null)
        {
            hit = true;
            player_hp.TakeDamage(dmg);
        }
        
        if (first_col)
        {
            
            first_col = false;
        }
        else
        { 
            if (move == 0)
            {   
                hit_count++;
                if (!Facingright)
                {
                    
                    if (collision.gameObject.name == "Wall1")
                    {
                        Flip(1);
                        
                    }
                    else if (collision.gameObject.name == "Wall2")
                    {
                        Flip(3);
                        
                    }
                    else if (collision.gameObject.name == "Wall3" || collision.gameObject.name =="Door")
                    {
                        Flip(2);
                        
                    }
                    else if (collision.gameObject.name == "Platform" & prev_col!=collision.gameObject.name)
                    {
                        Flip(0);
                        
                    }
                    prev_col = collision.gameObject.name;
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
                    else if (collision.gameObject.name == "Wall3" || collision.gameObject.name == "Door")
                    {
                        Flip(1);
                    }
                    else if (collision.gameObject.name == "Platform" & prev_col != collision.gameObject.name)
                    {
                        Flip(3);
                    }
                    prev_col = collision.gameObject.name;
                }
            }
            else
            {
                if (first_hit)
                {
                    if (!Facingright)
                    {
                        Facingright = !Facingright;
                        direction = new Vector2(-1 * ((float)Math.Cos((Math.PI / 2) + (Mathf.Deg2Rad * angle))), (float)Math.Sin((Math.PI / 2) + (Mathf.Deg2Rad * angle))).normalized;
                    }
                    else
                    {
                        Facingright = !Facingright;
                        direction = new Vector2((float)Math.Cos((Math.PI / 2) + (Mathf.Deg2Rad * angle)), (float)Math.Sin((Math.PI / 2) + (Mathf.Deg2Rad * angle))).normalized;
                    }
                    first_hit = false;
                    if (isEnraged)
                    {
                        speed = 30;
                    }
                    else
                    {
                        speed = 25;
                    }
                }
                else
                {
                    if (!Facingright & Up) //up and left
                    {
                        if (collision.gameObject.name == "Wall1") //go up and right
                        {
                           
                            hit_count++;
                            direction.x = -direction.x;
                            Facingright = !Facingright;
                        }
                        else if (collision.gameObject.name == "Wall2") //go down and left
                        {
                           
                            hit_count++;
                            direction.y = -direction.y;
                            Up = !Up;
                        }
                    }
                    else if (Facingright & !Up)// down and right
                    {
                        if (collision.gameObject.name == "Wall3") //go down and left
                        {
                            hit_count++;
                            direction.x = -direction.x;
                            Facingright = !Facingright;
                        }
                        else if (collision.gameObject.name == "Platform") //go up and right
                        {
                            hit_count++;
                            direction.y = -direction.y;
                            Up = !Up;
                        }
                    }
                    else if (Facingright & Up) //up and right
                    {
                        if (collision.gameObject.name == "Wall2") //go down and right
                        {
                            hit_count++;
                            direction.y = -direction.y;
                            Up = !Up;
                        }
                        else if (collision.gameObject.name == "Wall3") //go up and left
                        {
                            hit_count++;
                            direction.x = -direction.x;
                            Facingright = !Facingright;
                        }
                    }
                    else //down and left
                    {
                        if (collision.gameObject.name == "Platform") //go up and left
                        {
                            hit_count++;
                            direction.y = -direction.y;
                            Up = !Up;
                        }
                        else if (collision.gameObject.name == "Wall1") //go down and right
                        {
                            hit_count++;
                            direction.x = -direction.x;
                            Facingright = !Facingright;
                        }
                    }
                }
            
            }  
        }
        if (hit_count == 30 && move == 1)
        {
            speed= 0;
            func_called = false;
            first_col = true;
            hit_count = 0;
            anim.SetTrigger("Unfold");
            Body.enabled = false;
            Ground_line.enabled = true;
        }
        else if (hit_count == 37 && move == 0)
        {
            speed = 0;
            func_called = false;
            first_col = true;
            hit_count = 0;
            anim.SetTrigger("Unfold");
            Body.enabled = false;
            Ground_line.enabled = true;
        }



    }

    public void Flip_Model()
    {
        if(transform.position.x>player.transform.position.x && Model_facing_right)
        {
            Model_facing_right = !Model_facing_right;
            transform.Rotate(0, 180f, 0);
            firePoint.Rotate(0, 180f, 0);

        }
        else if(transform.position.x < player.transform.position.x && !Model_facing_right)
        {
            Model_facing_right = !Model_facing_right;
            transform.Rotate(0, 180f, 0);
            firePoint.Rotate(0,180f,0);
        }
    }
    private void Flip(int dir) // left:0 up:1 down:2 right:3
    {
        if (dir == 0)
        {
            direction = Vector2.left;
            speed += 2f;
        }
        else if (dir == 1)
        {
            direction = Vector2.up;
            speed += 2f;
        }
        else if (dir == 2)
        {
            direction = Vector2.down;
            speed += 2f;
        }
        else
        {
            direction = Vector2.right;
            speed += 2f;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}
