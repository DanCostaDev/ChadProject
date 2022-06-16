using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgReceive : MonoBehaviour
{
    private Animator anim;
    private Health myScript;
    private Character character;
    private int attackDirection;

    public void Start()
    {
        character = GetComponent<Character>();
        myScript = gameObject.GetComponentInChildren<Health>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (character.isAlive)
        {
            if (character.health <= 0)
            {
                character.isAlive = false;
                anim.SetBool("isWalking", false);
                if (tag == "Enemy")
                {
                    GetComponent<DmgReceive>().enabled = false;
                    GetComponentInChildren<EnemyMovement>().enabled = false;
                    GetComponentInChildren<EnemyAtk>().enabled = false;
                    Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("PlayerCollider").GetComponent<Collider>(), true);
                }
                if(tag == "PlayerCollider")
                {

                    GetComponent<DmgReceive>().enabled = false;
                    GetComponentInChildren<JotaroMovement>().enabled = false;
                    GetComponentInChildren<PlayerAttack>().enabled = false;
                }
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<DmgReceive>().enabled = false;
                GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<EnemyMovement>().enabled = false;
                GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<EnemyAtk>().enabled = false;

                GetComponent<Rigidbody>().AddForce(Vector3.right * attackDirection * 1500f);
                anim.SetTrigger("Dead");

                Debug.Log("Morreu");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (character.isAlive) {
            if (other.CompareTag("Attack"))
            {
                Debug.Log("Ataque recebido");
                if (!other.transform.parent.transform.parent.GetComponentInChildren<SpriteRenderer>().flipX)
                {
                    attackDirection = 1;
                }
                else
                {
                    attackDirection = -1;
                }
                anim.SetTrigger("Dmg");
                GetComponent<Rigidbody>().AddForce(Vector3.right * attackDirection * 1000f);
                myScript.TakeDamage(4);
                Debug.Log("Dano recebido");

            }
        }
    }
}
