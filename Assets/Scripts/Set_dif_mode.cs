using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_dif_mode : MonoBehaviour
{
    public int mode;
    public void Set_Mode()
    {
        PlayerPrefs.SetFloat("Shoot_Speed",0.15f);
        PlayerPrefs.SetInt("Defence", 0);
        PlayerPrefs.SetInt("Health", 100);
        PlayerPrefs.SetInt("Attack", 25);
        PlayerPrefs.SetInt("Jump", 18);
        PlayerPrefs.SetInt("Speed", 8);
        PlayerPrefs.SetInt("Mode",mode);
        PlayerPrefs.SetInt("Level",1);
        PlayerPrefs.SetInt("Deaths", 0); 
        PlayerPrefs.SetInt("Dialogue", 0);
        for (int i = 1; i < 5; i++)
        {
            string count = "Upgrade" + i;
            PlayerPrefs.SetInt(count, 0);
        }
        for(int i=1; i < 5; i++)
        {
            string count = "Boss" + i;
            PlayerPrefs.SetInt(count, 0);
        }
    }
}
