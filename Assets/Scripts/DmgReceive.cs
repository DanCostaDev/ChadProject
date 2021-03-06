using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgReceive : MonoBehaviour
{
    public Transform Object;
    private int direction = 1;
    private isAlive scriptAlive;

    public void Start()
    {
        scriptAlive = GetComponent<isAlive>();
        scriptAlive.SetAlive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (scriptAlive.GetAlive()) {
            if (other.CompareTag("Attack"))
            {
                Debug.Log("Ataque recebido");
                Animator anim = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
                if (!other.transform.parent.transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }
                anim.SetTrigger("Dmg");
                GetComponent<Rigidbody>().AddForce(Vector3.right * direction * 1000f);
                Health myScript = gameObject.GetComponentInChildren<Health>();
                myScript.TakeDamage(4);


            }
        }
    }
}
