using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float healthBase;
    public float staminaBase;
    public float health { get; set; }
    public float stamina { get; set; }
    public int id { get; set; }
    public bool isAlive { get; set; }
    void Start()
    {
        isAlive = true;
        health = healthBase;
        stamina = staminaBase;
    }

}