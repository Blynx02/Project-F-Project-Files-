using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Weapons : MonoBehaviour
{
    [SerializeField]
    private GameObject Lava_Ball;
    [SerializeField]
    private GameObject Enraged_Lava_Ball;
    [SerializeField]
    private GameObject Rock_Spike;
    [SerializeField]
    private GameObject firepoint1;
    [SerializeField]
    private GameObject firepoint2;
    [SerializeField]
    private GameObject Firepoint_Group1;
    [SerializeField]
    private GameObject Firepoint_Group2;
    private GameObject clone1;
    private GameObject clone2;
    private GameObject clone3;
    private GameObject clone4;
    public bool Enraged = false;
    private GameObject player;
    private Animator anim;
    [SerializeField]
    private AudioSource spike_spawn;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Enraged= gameObject.GetComponent<Enemy>().Enraged;
    }

    public void Throw_Rock_Spike()
    {
        if(clone1!= null) 
        {
            StopAllCoroutines();
            Destroy(clone1);
            Destroy(clone2);
            Destroy(clone3);
            Destroy(clone4);
        }
        if (Mathf.Abs(Firepoint_Group1.transform.position.x - player.transform.position.x)< Mathf.Abs(Firepoint_Group2.transform.position.x - player.transform.position.x))
        {
            clone1 = Instantiate(Rock_Spike, Firepoint_Group1.transform.GetChild(0).transform.position, Firepoint_Group1.transform.GetChild(0).transform.rotation);
            clone2 = Instantiate(Rock_Spike, Firepoint_Group1.transform.GetChild(1).transform.position, Firepoint_Group1.transform.GetChild(1).transform.rotation);
            clone3 = Instantiate(Rock_Spike, Firepoint_Group1.transform.GetChild(2).transform.position, Firepoint_Group1.transform.GetChild(2).transform.rotation);
            clone4 = Instantiate(Rock_Spike, Firepoint_Group1.transform.GetChild(3).transform.position, Firepoint_Group1.transform.GetChild(3).transform.rotation);
            StartCoroutine(TimedealyRock());
        }
        else
        {
            clone1 = Instantiate(Rock_Spike, Firepoint_Group2.transform.GetChild(0).transform.position, Firepoint_Group2.transform.GetChild(0).transform.rotation);
            clone2 = Instantiate(Rock_Spike, Firepoint_Group2.transform.GetChild(1).transform.position, Firepoint_Group2.transform.GetChild(1).transform.rotation);
            clone3 = Instantiate(Rock_Spike, Firepoint_Group2.transform.GetChild(2).transform.position, Firepoint_Group2.transform.GetChild(2).transform.rotation);
            clone4 = Instantiate(Rock_Spike, Firepoint_Group2.transform.GetChild(3).transform.position, Firepoint_Group2.transform.GetChild(3).transform.rotation);
            StartCoroutine(TimedealyRock());

        }

    }


    public void Throw_Lava_Ball()
    {
        anim.ResetTrigger("Idle");
        if(Mathf.Abs(firepoint1.transform.position.y - player.transform.position.y)< Mathf.Abs(firepoint2.transform.position.y - player.transform.position.y))
        {
            StartCoroutine(TimedelayLava1());
        }
        else
        {
            StartCoroutine(TimedelayLava2()); 
        }
        
    }

    IEnumerator TimedelayLava1()
    {
        if (!Enraged)
        {
            Instantiate(Lava_Ball, firepoint1.transform.position, firepoint1.transform.rotation);
            yield return new WaitForSeconds(0.7f);
            Instantiate(Lava_Ball, firepoint2.transform.position, firepoint2.transform.rotation);
            yield return new WaitForSeconds(0.7f);
            Instantiate(Lava_Ball, firepoint1.transform.position, firepoint1.transform.rotation);
        }
        else
        {
            int random_int = Random.Range(4,7);
            int i = 1;
            while(i<random_int)
            {
                if (i % 2 == 0)
                {
                    Instantiate(Enraged_Lava_Ball, firepoint2.transform.position, firepoint2.transform.rotation);
                    yield return new WaitForSeconds(0.6f);
                }
                else
                {
                    Instantiate(Enraged_Lava_Ball, firepoint1.transform.position, firepoint1.transform.rotation);
                    yield return new WaitForSeconds(0.6f);
                }
                i++;
            }
            if (i % 2 == 0)
            {
                Instantiate(Enraged_Lava_Ball, firepoint2.transform.position, firepoint2.transform.rotation);
            }
            else
            {
                Instantiate(Enraged_Lava_Ball, firepoint1.transform.position, firepoint1.transform.rotation);
            }
        }
        anim.SetTrigger("Idle");
    } 
    IEnumerator TimedelayLava2()
    {
        if (!Enraged)
        {
            Instantiate(Lava_Ball, firepoint2.transform.position, firepoint2.transform.rotation);
            yield return new WaitForSeconds(0.7f);
            Instantiate(Lava_Ball, firepoint1.transform.position, firepoint1.transform.rotation);
            yield return new WaitForSeconds(0.7f);
            Instantiate(Lava_Ball, firepoint2.transform.position, firepoint2.transform.rotation);
        }
        else
        {
            int random_int = Random.Range(4, 8);
            int i = 1;
            while (i < random_int)
            {
                if (i % 2 == 0)
                {
                    Instantiate(Enraged_Lava_Ball, firepoint1.transform.position, firepoint1.transform.rotation);
                    yield return new WaitForSeconds(0.6f);
                }
                else
                {
                    Instantiate(Enraged_Lava_Ball, firepoint2.transform.position, firepoint2.transform.rotation);
                    yield return new WaitForSeconds(0.6f);
                }
                i++;
            }
            if (i % 2 == 0)
            {
                Instantiate(Enraged_Lava_Ball, firepoint1.transform.position, firepoint1.transform.rotation);
            }
            else
            {
                Instantiate(Enraged_Lava_Ball, firepoint2.transform.position, firepoint2.transform.rotation);
            }
        }
        anim.SetTrigger("Idle");
    }

    IEnumerator TimedealyRock()
    {
        yield return new WaitForSeconds(5);
        Destroy(clone1);
        Destroy(clone2);
        Destroy(clone3);
        Destroy(clone4);
    }

    private void PlaySound()
    {
        spike_spawn.Play();
    }

    private void OnDestroy()
    {
        Destroy(clone1);
        Destroy(clone2);
        Destroy(clone3);
        Destroy(clone4);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player_Health player = collision.gameObject.GetComponent<Player_Health>();
            player.TakeDamage(50);
        }
    }
}
