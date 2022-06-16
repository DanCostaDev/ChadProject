using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProperties : MonoBehaviour
{
    public float damage;
    public float stamina;

    public float GetStamina()
    {
        return stamina;
    }
    public float GetDamage()
    {
        return damage;
    }
}
