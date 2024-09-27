using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spear : MonoBehaviour
{
    private int dmg;
    private float timer;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            dmg = 10;
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            dmg = 15;
        }
        else
        {
            dmg = 20;
        }
    }

    void FixedUpdate()
    {
        if (hit)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            timer += Time.deltaTime;
        }
        if (timer > 2)
        {
            timer = 0;
            hit = false;
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player_Health player = collision.gameObject.GetComponent<Player_Health>();
        if (player != null)
        {
            player.TakeDamage(dmg);
            hit = true;
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
    }
}
