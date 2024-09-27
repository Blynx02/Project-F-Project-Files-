using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Next_Level_Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int level_count = PlayerPrefs.GetInt("Level", 1);
            PlayerPrefs.SetInt("Level", level_count + 1);
            PlayerPrefs.SetInt("Dialogue", PlayerPrefs.GetInt("Dialogue") + 1);
            SceneManager.LoadScene(5);
        }
    }
}
