using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_Ball : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private int dmg ;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            dmg = 8;
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            dmg = 16;
        }
        else
        {
            dmg = 28;
        }
        rb.velocity = Vector3.left * speed;
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
        

    }
}
