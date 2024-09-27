using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Player_Data : MonoBehaviour
{
    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteAll();
    }
}
