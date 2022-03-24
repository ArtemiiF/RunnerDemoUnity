using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;
    private PlayerAttributes playerAttributes;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRunAnim()
    {
        animator.SetBool("Run", true);
    }

    public void StartIdleAnim()
    {
        animator.SetBool("Dead", false);
        animator.SetBool("Run", false);
    }

    public void StartDead()
    {
        animator.SetBool("Dead", true);
        animator.SetBool("Run", false);

    }
    public void StartAttack()
    {
        animator.SetBool("Attack", true);
        
    }
    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }
}
