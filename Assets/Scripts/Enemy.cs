using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Maxhealth;
    public int health;
    public bool Enraged = false;
    private string boss_number;

    private void Start()
    {
        
        if (tag == "Boss")
        {
            int level = PlayerPrefs.GetInt("Level");
            boss_number = "Boss" + level ;
            if (PlayerPrefs.GetInt(boss_number) == 1)
            {
                Destroy(gameObject);
            }
            int mode = PlayerPrefs.GetInt("Mode");
            if (level == 1)
            {
                Maxhealth = 3000 + 1000 * mode;
            }
            else if(level == 2)
            {
                Maxhealth = 3100 + 1000 * mode;    
            }
            else if(level == 3)
            {
                Maxhealth= 4100 + 1000 * mode;
            }
            else if(level == 4)
            {
                Maxhealth = 4500 + 1000*mode;
            }
        }
        health = Maxhealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health<= 0) 
        {
            Die();
        }
        else if(health <=  Maxhealth/2 && !Enraged && tag=="Boss")
        {
            Enraged= true; 
            GetComponent<Animator>().SetBool("Enraged",Enraged);
        }
    }

    private void Die()
    {
        if (tag == "Boss")
        {
            PlayerPrefs.SetInt(boss_number, 1);
        }
        Destroy(gameObject); 
    }
}
