using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackImpact : MonoBehaviour
{
    private int Direction;
    private AttackProperties property;
    private Health stamina;

    private void OnEnable()
    {
        property = GetComponent<AttackProperties>();
        GameObject Player = GameObject.Find("Jotaro");
        stamina = Player.GetComponentInChildren<Health>();
        stamina.LoseStamina(property.GetStamina());
        Debug.Log("ATAQUE:ESTAMINA REDUZIDA: " + property.GetStamina());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box")){           
            if (!transform.parent.transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
            {
                Direction = 1;
            }
            else
            {
                Direction = -1;
            }
            other.GetComponent<Rigidbody>().AddForce(Vector3.right * Direction * 400f);
        }

    }
}
