using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAttack : MonoBehaviour
{
    public GameObject Object;
    void SetOff()
    {

        Object.transform.GetChild(0).gameObject.SetActive(false);
        Object.transform.GetChild(1).gameObject.SetActive(false);
        Object.transform.GetChild(2).gameObject.SetActive(false);
        Object.transform.GetChild(3).gameObject.SetActive(false);
        Object.transform.GetChild(4).gameObject.SetActive(false);
        Object.transform.GetChild(5).gameObject.SetActive(false);

    }
}
