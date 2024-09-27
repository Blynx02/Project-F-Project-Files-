using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence_Upgrade : MonoBehaviour
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
                PlayerPrefs.SetInt("Defence", PlayerPrefs.GetInt("Defence") + 3);
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 20);
                string upgrade_number = "Upgrade" + PlayerPrefs.GetInt("Level").ToString();
                PlayerPrefs.SetInt(upgrade_number, 3);
            }
        }
    }
}
