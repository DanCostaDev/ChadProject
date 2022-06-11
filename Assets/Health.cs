using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmountBase;

    private float healthAmount;
    private bool isDead = false;
    private int direction;
    private Animator anim;
    private Transform player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        healthAmount = healthAmountBase;
        player = GameObject.Find("JotaroCollider").transform;
    }
    private void Update()
    {
        if (!isDead)
        {
            if (healthAmount <= 0)
            {
                if (transform.parent.CompareTag("Enemy"))
                {
                    isDead = true;
                    transform.parent.gameObject.GetComponent<DmgReceive>().enabled = false;
                    gameObject.GetComponent<EnemyMovement>().enabled = false;
                    gameObject.GetComponent<EnemyAtk>().enabled = false;
                    anim.SetBool("isWalking", false);

                    if (player.position.x > transform.parent.position.x)
                    {
                        direction = 1;
                    }
                    else
                    {
                        direction = -1;
                    }
                    transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.right * direction * 1500f);                                      
                    anim.SetTrigger("Dead");
                }
                Debug.Log("Morreu");
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        if (transform.parent.CompareTag("PlayerCollider")){
            healthBar.fillAmount = healthAmount / healthAmountBase;
        }       
    }
}
