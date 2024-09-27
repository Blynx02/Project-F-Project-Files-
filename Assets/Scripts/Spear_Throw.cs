using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Throw : StateMachineBehaviour
{
    private Vector2 target;
    private float timer;
    private GameObject player;
    private Vector2 start_pos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        start_pos= animator.transform.position;
        target = new Vector2(player.transform.position.x, animator.transform.position.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer < 1.65f)
        {
            animator.transform.position = Vector2.Lerp(animator.transform.position, target, 2 * Time.deltaTime); 
            timer += Time.deltaTime;
        }
        else
        {
            animator.transform.position = Vector2.Lerp(animator.transform.position, start_pos, 2 * Time.deltaTime);
            if(Mathf.Abs(animator.transform.parent.transform.position.x - animator.transform.position.x) < 0.7f)
            {
                animator.transform.position = start_pos;
                animator.SetBool("Throw", false);
                animator.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Idle");
            }
           

        }
    }
}
