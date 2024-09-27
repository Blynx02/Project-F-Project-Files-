using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic_Wave : MonoBehaviour
{
    [SerializeField]
    private GameObject egg;
    public float speed = 20f;
    public Rigidbody2D rb;
    private int dmg;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * speed;
       
        float rot = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg ;
        transform.rotation = Quaternion.Euler(0,0,rot + 90 );

        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            dmg = 10;
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            dmg = 16;
        }
        else
        {
            dmg = 25;
        }
    }

    void OnBecameInvisible() //invisible is considered when it leaves camera view
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Player_Health player = hitInfo.GetComponent<Player_Health>();
        if (player != null)
        {
            player.TakeDamage(dmg);
            Destroy(gameObject);
        }
        else if (hitInfo.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(egg,new Vector2(transform.position.x, -5.16f), Quaternion.identity);
            Destroy(gameObject);
        }


    }
}
