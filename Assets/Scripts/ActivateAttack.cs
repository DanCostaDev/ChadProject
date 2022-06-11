using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAttack : MonoBehaviour
{
    public GameObject Object;
    void SetOn()
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
    void SetOn2()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            Object.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            Object.transform.GetChild(3).gameObject.SetActive(true);
        }

    }
    void SetOn3()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            Object.transform.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            Object.transform.GetChild(5).gameObject.SetActive(true);
        }

    }
}
