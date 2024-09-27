using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy4_Jump_Attack : StateMachineBehaviour
{
    private float jump_timer;
    private float timer;
    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 target;
    private float jumpingPower = 11f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jump_timer = 0;
        timer =25;
        player = GameObject.FindGameObjectWithTag("Player");
        target = new Vector2(player.transform.position.x, animator.transform.position.y);
        rb= animator.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, jumpingPower);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(jump_timer >=1 )
        {
            if (!animator.GetComponent<Enemy4_Weapon>().dash.isPlaying)
            {
                animator.GetComponent<Enemy4_Weapon>().PlaySound();
            }
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, timer * Time.deltaTime);
            if (Mathf.Abs(animator.transform.position.x - target.x)<0.2f){
                animator.transform.position = target; 
                animator.SetTrigger("Idle");
            }
        }
        else
        {
            jump_timer += Time.deltaTime;
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
