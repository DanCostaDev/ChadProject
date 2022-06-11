using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateEnemyAttack : MonoBehaviour
{
    public GameObject Object;
    void SetOff()
    {
        Object.transform.GetChild(0).gameObject.SetActive(false);
        Object.transform.GetChild(1).gameObject.SetActive(false);
    }
}
