using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4_Weapon : MonoBehaviour
{
    GameObject player;
    GameObject spear;
    private Vector2 target;
    private bool FacingRight = false;
    private bool isEnraged;
    public AudioSource dash;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spear = transform.GetChild(0).gameObject;
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), gameObject.GetComponent<Rigidbody2D>().GetComponent<Collider2D>(), true); 
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Spear").GetComponent<Collider2D>(), gameObject.GetComponent<Rigidbody2D>().GetComponent<Collider2D>(), true);
        Flip();
        
    }

    private void Flip()
    {
        if ((FacingRight && player.transform.position.x < transform.position.x) || (!FacingRight && player.transform.position.x > transform.position.x))
        {
            FacingRight = !FacingRight;
            transform.Rotate(0, 180f, 0);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        isEnraged = GetComponent<Enemy>().Enraged;
        if(isEnraged)
        {
            GetComponent<Animator>().SetBool("Enraged", isEnraged);
        }
        if (!spear.GetComponent<Animator>().GetBool("Throw"))
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform")
        {
            GetComponent<Rigidbody2D>().velocity= Vector3.zero;
        }
    }

    void Spear_Attack()
    {
        Animator spear_anim = spear.GetComponent<Animator>();
        spear_anim.SetTrigger("Attack");
    }

    public void PlaySound()
    {
        dash.Play();
    }
}
