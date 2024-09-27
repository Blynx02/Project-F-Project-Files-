using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_egg : MonoBehaviour
{
    [SerializeField]
    private GameObject spider_minion;
   
    void Spawn() 
    {
        int random_int = Random.Range(1,11);
        if (random_int <= 7)
        {
            Instantiate(spider_minion, new Vector3(transform.position.x, -4.57f), Quaternion.identity);
        }
        Destroy(gameObject);
    }
    
}
