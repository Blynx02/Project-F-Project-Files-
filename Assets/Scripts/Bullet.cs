using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {
        dmg = PlayerPrefs.GetInt("Attack");
        rb.velocity = transform.right* speed;
    }
    void OnBecameInvisible() //invisible is considered when it leaves camera view
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) 
        {
            enemy.TakeDamage(dmg);
            Destroy(gameObject);
        }
        
        
            
       
        
        
    }
}
