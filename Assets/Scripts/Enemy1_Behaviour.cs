using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Behaviour : StateMachineBehaviour
{
    float time = 10f;
    GameObject player;
    float helper= 0f;
    bool spike_planted  = false;
    float spike_timer = 0f;
    private bool Enraged;
    private float decision_timer_peak;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        Enraged = animator.GetComponent<Enemy>().Enraged;
        if (Enraged) 
        {
            decision_timer_peak= 1.7f;
        }
        else
        {
            decision_timer_peak= 3;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
        
        if(spike_timer==5)
        {
            spike_planted=false;
           
        }
        if (Mathf.Round(time) >= decision_timer_peak)
        {   if (spike_planted)
            {
                animator.SetTrigger("Lava Ball");
            }
            else
            {

                if (player.GetComponent<Movement>().IsGrounded())
                {
                    if (Random.Range(1, 11) <= 9)
                    {
                        animator.SetTrigger("Rock Spike");
                        spike_planted=true;
                        spike_timer = 0;
                    }
                    else
                    {
                        animator.SetTrigger("Lava Ball");
                    }

                }
                else
                {
                    if (Random.Range(1, 11) <= 5)
                    {
                        animator.SetTrigger("Rock Spike");
                        spike_planted= true;
                        spike_timer = 0;
                    }
                    else
                    {
                        animator.SetTrigger("Lava Ball");
                    }
                }
            }
            time = 0;
        }

        helper += Time.deltaTime;
        if(helper > 1f ) 
        {
            spike_timer += Mathf.Round(helper);
            time += Mathf.Round(helper);
            helper= 0f;

        }
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Lava Ball");
        animator.ResetTrigger("Rock Spike");
        animator.ResetTrigger("Idle");
    }

}
