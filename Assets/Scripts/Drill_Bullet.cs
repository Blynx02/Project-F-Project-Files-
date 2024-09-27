using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int dmg = 25;
    // Start is called before the first frame update
    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime; 
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
