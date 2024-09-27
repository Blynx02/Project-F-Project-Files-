using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Web : MonoBehaviour
{
    private GameObject boss;
    private Animator anim;
    private GameObject player;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        anim = boss.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Health player_hp = collision.GetComponent<Player_Health>();
        if(player_hp != null)
        {
            
            anim.SetTrigger("Sonic_Shoot");
            player_hp.GetComponent<Movement>().Immobilaize();
            Destroy(gameObject);
        }
        else if(collision.gameObject.layer== 6 || collision.gameObject.layer==3)
        {
            anim.SetTrigger("Idle");
            Destroy(gameObject);
        }
        
    }
}
