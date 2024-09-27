using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    [SerializeField]
    private TMP_Text no_saved_game_message;
    public void Continue_Game()
    {
        if (PlayerPrefs.GetInt("Mode", 0) != 0)
        {
            if(PlayerPrefs.GetInt("Boss"+ PlayerPrefs.GetInt("Level").ToString()) == 0)
            {
                SceneManager.LoadScene(5);

            }
            else
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
            }
        }
        else
        {
            no_saved_game_message.enabled= true;
        }
    }
}
