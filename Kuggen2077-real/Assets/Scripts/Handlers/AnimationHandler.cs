using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler
{
    Animator anim;

    public AnimationHandler(Animator anim)
    {
        this.anim = anim;
    }

    public void Move()
    {
        anim.SetBool("isMoving", true);
    }

    public void Idle()
    {
        anim.SetBool("isMoving", false);
    }

    public void Die()
    {
        anim.SetTrigger("isDead");
    }
    
}
