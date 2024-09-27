using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemy2_Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject Sonic_Wave;
    [SerializeField]
    private GameObject Enraged_Sonic_Wave;
    [SerializeField]
    private GameObject Spider_Web;
    private Animator anim;
    private bool isEnraged;
    private bool done_transition = false;
    
    private GameObject Player;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!done_transition)
        {
            isEnraged = gameObject.GetComponent<Enemy>().Enraged;
        }
        if (isEnraged && !done_transition)
        {
            anim.SetBool("Enraged", isEnraged);
            done_transition = true;
        }
    }

    void Shoot_Sonic_Wave()
    {
        if (isEnraged)
        {
            Instantiate(Enraged_Sonic_Wave, firePoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Sonic_Wave, firePoint.position, Quaternion.identity);
        }
    }

    void Shoot_Spider_Web()
    {
        Instantiate(Spider_Web, firePoint.position, Quaternion.identity);
    }


}
