using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector3 clone;
    private Animator ani;
    private bool CanShoot;
    private float time_to_shoot;

    private void Start()
    {
        time_to_shoot = PlayerPrefs.GetFloat("Shoot_Speed");
        CanShoot= true;
       clone = firePoint.localPosition;
       ani= GetComponent<Animator>();
    }


    // Update is called once per frame

    void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot)
        {
            CanShoot= false;
            if (Input.GetKey(KeyCode.W))
            {
                ani.SetBool("Look_Up", true);
                firePoint.localPosition = new Vector3(-0.19f,1.31f,0);
                firePoint.rotation = Quaternion.Euler(0, 0, 90);
                Shoot();
                
            }
            else
            {
                ani.SetBool("Look_Up", false);
                firePoint.localPosition = clone;
                firePoint.rotation = firePoint.parent.rotation;
                Shoot();
            }
            
            
        }
    }

    void Shoot()
    {
        //shooting logic 
        Instantiate(bulletPrefab, firePoint.position ,firePoint.rotation);
        StartCoroutine("WaitToShoot");
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(time_to_shoot);
        CanShoot= true;
    }
}
