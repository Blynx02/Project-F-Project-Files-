using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public int health;
    public Health_Bar healthbar;
    public int damage_reduction;
    public bool isInvulnerable;
    private float timer;
    private SpriteRenderer sprite;
    private bool Fade_in = false;
    private bool Fade_out = true;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        timer = 0;
        isInvulnerable = false;
        damage_reduction = PlayerPrefs.GetInt("Defence");
        health = PlayerPrefs.GetInt("Health"); // set player's health to maxhealth
        if (healthbar != null)
        {
            healthbar.SetMaxHealth(health); //sync healthbar with player's health
        }
    }
    public void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            if (damage > damage_reduction)
            {
                health -= (damage - damage_reduction);
                healthbar.SetHealth(health);
                //StartCoroutine(FadeDamage());
            }
            if (health <= 0)
            {
                Die();
            }
            isInvulnerable = true;
        }
    }

    void Update()
    {
        if (isInvulnerable)
        {
            timer += Time.deltaTime;
            if(sprite.color.a>0.3f && Fade_out)
            {
                sprite.color = Color.Lerp(sprite.color, new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f), Time.deltaTime * 450);
            }
            else if(sprite.color.a == 0.3f)
            {
                Fade_out= false;
                Fade_in = true;
            }
            if(sprite.color.a < 1 && Fade_in)
            {
                sprite.color = Color.Lerp(sprite.color, new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1), Time.deltaTime * 450);
            }
            else if(sprite.color.a == 1)
            {
                Fade_in= false;
                Fade_out= true;
            }

        }

        if (timer > 2)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            isInvulnerable = false;
            timer= 0;
        }
    }

    private void Die()
    {
        if (PlayerPrefs.GetInt("Mode") == 3)
        {
            PlayerPrefs.SetInt("Defence", 0);
            PlayerPrefs.SetInt("Health", 100);
            PlayerPrefs.SetInt("Attack", 25);
            PlayerPrefs.SetInt("Jump", 16);
            PlayerPrefs.SetInt("Speed", 8);
            PlayerPrefs.SetInt("Dialogue", 0);
            PlayerPrefs.SetInt("Level", 1);
            for (int i = 1; i < 5; i++)
            {
                string count = "Upgrade" + i;
                PlayerPrefs.SetInt(count, 0);
            }
            for (int i = 0; i < 4; i++)
            {
                string count = "Boss" + i;
                PlayerPrefs.SetInt(count, 0);
            }
        }
        PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") + 1);
        SceneManager.LoadScene(5);
    }
}