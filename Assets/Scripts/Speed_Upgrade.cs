using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Upgrade : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private AudioSource equip_sfx;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 0.6f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                equip_sfx.Play();
                PlayerPrefs.SetFloat("Shoot_Speed", PlayerPrefs.GetFloat("Shoot_Speed") - 0.01f);
                PlayerPrefs.SetInt("Jump", PlayerPrefs.GetInt("Jump") + 1);
                PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 2);
                string upgrade_number = "Upgrade" + PlayerPrefs.GetInt("Level").ToString();
                PlayerPrefs.SetInt(upgrade_number, 2);
            }
        }
    }
}
