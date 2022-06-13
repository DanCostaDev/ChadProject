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
    public GameObject player;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
        healthAmount = healthAmountBase;
        scriptAlive = GetComponentInParent<isAlive>();
    }
    private void Update()
    {
        
        if (scriptAlive.GetAlive())
        {
            if (healthAmount <= 0)
            {
                scriptAlive.SetAlive(false);
                if (transform.parent.CompareTag("Enemy"))
                {
                    GetComponentInParent<DmgReceive>().enabled = false;
                    gameObject.GetComponent<EnemyMovement>().enabled = false;
                    gameObject.GetComponent<EnemyAtk>().enabled = false;
                    anim.SetBool("isWalking", false);

                    if (player.transform.position.x > transform.parent.position.x)
                    {
                        Debug.Log("Direção = 1");
                        direction = 1;
                    }
                    else
                    {
                        Debug.Log("Direção = -1");
                        direction = -1;
                    }
                    transform.parent.GetComponentInParent<Rigidbody>().AddForce(Vector3.left * direction * 1500f);                                      
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
    public void Heal(float heal)
    {
        healthAmount += heal;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountBase);
        healthBar.fillAmount = healthAmount / healthAmountBase;
    }
}
