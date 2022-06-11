using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackImpact : MonoBehaviour
{
    private int Direction;
    private void OnTriggerEnter(Collider other)
    {
        GameObject Player = GameObject.Find("Jotaro");
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
            Debug.Log("teste: " + Direction);
        }
        

    }
}
