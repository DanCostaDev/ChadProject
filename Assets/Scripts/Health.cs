using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmountBase;
    public Image staminaBar;
    public float staminaAmountBase;
    public Image emptyStaminaBar;


    private Color baseColor;
    private Character character;
    private int direction;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        character = gameObject.GetComponentInParent<Character>();
        baseColor = emptyStaminaBar.color;

    }
    private void Update()
    {
        if (transform.parent.CompareTag("PlayerCollider"))
        {
            character.stamina += 0.2f;
            character.stamina = Mathf.Clamp(character.stamina, 0, character.staminaBase);
            staminaBar.fillAmount = character.stamina / character.staminaBase;
        }
    }

    public void LoseStamina(float Amount)
    {        
        if (transform.parent.CompareTag("PlayerCollider"))
        {
            character.stamina -= Amount;
            staminaBar.fillAmount = character.stamina / character.staminaBase;
        }
    }

    public void TakeDamage(float Damage)
    {
        character.health -= Damage;
        if (transform.parent.CompareTag("PlayerCollider"))
        {
            healthBar.fillAmount = character.health / character.healthBase;
        }       
    }
    public void Heal(float heal)
    {
        character.health += heal;
        character.health = Mathf.Clamp(character.health, 0, character.healthBase);
        healthBar.fillAmount = character.health / character.healthBase;
    }
    public void LowStamina()
    {
        StaminaWhite();
        Invoke("StaminaGray", 0.3f);
        Invoke("StaminaWhite", 0.6f);
        Invoke("StaminaGray", 0.9f);
        Invoke("StaminaWhite", 1.2f);
        Invoke("StaminaGray", 1.5f);

    }
    void StaminaWhite()
    {
        emptyStaminaBar.color = new Color(0.6f, 0.6f, 0.6f);
    }
    void StaminaGray()
    {
        emptyStaminaBar.color = baseColor;
    }
}
