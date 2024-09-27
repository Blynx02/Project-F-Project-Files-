using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Spike : MonoBehaviour
{
    
    
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int dmg;
    [SerializeField]
    private Rigidbody2D rb;
    private int currentColliderIndex = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            dmg = 5;
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            dmg = 10;
        }
        else
        {
            dmg= 20;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player_Health player = collision.gameObject.GetComponent<Player_Health>();
        if (player != null)
        {
            player.TakeDamage(dmg);
            
        }
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
        
    }

}
