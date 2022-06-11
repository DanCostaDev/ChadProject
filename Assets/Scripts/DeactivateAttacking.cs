using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAttacking : MonoBehaviour
{
    private void DeactivateAtk()
    {
        gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
    }
}
