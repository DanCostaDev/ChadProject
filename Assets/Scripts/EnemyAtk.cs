using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    public Transform player;
    public float nearDistance;
    Animator anim;
    private float nextAttack;
    private float attackInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DioDmg"))
        {
            nextAttack = Time.time + attackInterval;
        }
            if ((Vector3.Distance(transform.parent.position, player.position) < nearDistance) & Time.time > nextAttack)
        {
            Attack();
        }
        
    }
    void Attack()
    {
        Debug.Log("Atacou");
        anim.SetTrigger("Hit1");
        nextAttack = Time.time + attackInterval;
    }
}
