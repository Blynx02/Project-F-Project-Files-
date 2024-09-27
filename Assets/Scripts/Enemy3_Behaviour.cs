using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy3_Behaviour : StateMachineBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private int speed=5;
    private float timer;
    int random_int;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        rb = animator.GetComponent<Rigidbody2D>();
        timer = 0;
        random_int = Random.Range(0, 10);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = Vector2.down *speed;
        timer += Time.deltaTime;
        if (timer >1) 
        {  
            if(random_int <=3)
            {
                animator.SetTrigger("Roll");
                animator.SetTrigger("Bounce");
            }
            else if(random_int <=7) 
            {
                animator.SetTrigger("Roll");
                animator.SetTrigger("Horizontal");
            }
            else
            {
                animator.SetTrigger("Shoot");
            }
            
        }
       
       
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Roll");
        animator.ResetTrigger("Shoot");
        animator.ResetTrigger("Unfold");
    }
}
