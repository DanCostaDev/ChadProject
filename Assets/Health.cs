using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmountBase;

    private float healthAmount;
    private int direction;
    private isAlive scriptAlive;
    private Animator anim;
    private Transform player;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
        healthAmount = healthAmountBase;
        player = GameObject.Find("JotaroCollider").transform;
        scriptAlive = GetComponentInParent<isAlive>();
    }
    private void Update()
    {
        
        if (scriptAlive.GetAlive())
        {
            Debug.Log(scriptAlive.GetAlive());
            if (healthAmount <= 0)
            {
                scriptAlive.SetAlive(false);
                if (transform.parent.CompareTag("Enemy"))
                {
                    GetComponentInParent<DmgReceive>().enabled = false;
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
                    GetComponentInParent<Rigidbody>().AddForce(Vector3.right * direction * 1500f);                                      
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
