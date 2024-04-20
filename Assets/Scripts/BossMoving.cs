using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossMoving : StateMachineBehaviour
{
    
    public float speed = 2.5f;
    public float attackRange = 1f;
    Transform player;
    Rigidbody2D rb;
    Vector2 newPos;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{

    player = GameObject.FindGameObjectWithTag("Player").transform;
    rb = animator.GetComponent<Rigidbody2D>();
  
    rb.MovePosition(newPos);

}
override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
   

    Vector3 target = new Vector3(player.position.x,player.position.y,rb.position.y);
    Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
    rb.MovePosition(newPos);

    if (Vector2.Distance(player.position, rb.position) <= attackRange)
    {
        animator.SetTrigger("Attack");
    }
}
override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    animator.ResetTrigger("Attack");
}

}
    


