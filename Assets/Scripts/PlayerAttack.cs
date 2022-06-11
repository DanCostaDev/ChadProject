using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    public float attackInterval;
    private float nextAttack;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") && !anim.GetBool("isAttacking") && /*Time.time > nextAttack*/!anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
        { 
            Attack();
        } else
        if (Input.GetButtonDown("Fire1") && anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
        {
            Attack2();
        } else
        if (Input.GetButtonDown("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") && anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk3") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
        {
            Attack3();
        }
    }
    void Attack()
    {       
        anim.SetTrigger("hit");
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        nextAttack = Time.time + attackInterval;
    }
    void Attack2()
    {
        anim.SetTrigger("hit2");
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        nextAttack = Time.time + attackInterval;
    }
    void Attack3()
    {
        
        anim.SetTrigger("hit3");
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        nextAttack = Time.time + attackInterval;
    }
}
