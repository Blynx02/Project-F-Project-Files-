using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4_Thrust_Attack : StateMachineBehaviour
{
    private float timer;
    private GameObject player;
    private Vector2 target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 17f;
        player = GameObject.FindGameObjectWithTag("Player");
        target= new Vector2(player.transform.position.x,animator.transform.position.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,target,timer * Time.deltaTime);
        if(timer - 4.5f * Time.deltaTime > 0)
        {
            timer -= 4.5f * Time.deltaTime;
        }

        if (Mathf.Abs(animator.transform.position.x - target.x)<0.5f)
        {
            animator.SetTrigger("Idle");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
