using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Death_count_screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMP_Text>().text = "TEST SUBJECT #" + (PlayerPrefs.GetInt("Deaths", 0) + 1);
    }

}
