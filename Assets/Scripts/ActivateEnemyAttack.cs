using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemyAttack : MonoBehaviour
{
    public GameObject Object;
    void SetOn1()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            Object.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Object.transform.GetChild(1).gameObject.SetActive(true);
        }
        
    }
}
