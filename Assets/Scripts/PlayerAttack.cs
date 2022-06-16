using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    public float attackInterval;
    public Image emptyStaminaBar;

    private Health stamina;
    private float timeNow = 0.5f;
    private Color baseColor;
    private float nextAttack;
    private Character character;
    private GameObject attacks;
    private AttackProperties atk1R;
    private AttackProperties atk1L;
    private AttackProperties atk2R;
    private AttackProperties atk2L;
    private AttackProperties atk3R;
    private AttackProperties atk3L;
    // Start is called before the first frame update
    void Start()
    {
        stamina = GetComponent<Health>();
        baseColor = emptyStaminaBar.color;
        anim = gameObject.GetComponent<Animator>();
        character = GetComponentInParent<Character>(); 
        atk1R = gameObject.transform.parent.GetChild(2).GetChild(0).GetComponent<AttackProperties>();
        atk1L = gameObject.transform.parent.GetChild(2).GetChild(1).GetComponent<AttackProperties>();
        atk2R = gameObject.transform.parent.GetChild(2).GetChild(2).GetComponent<AttackProperties>();
        atk2L = gameObject.transform.parent.GetChild(2).GetChild(3).GetComponent<AttackProperties>();
        atk3R = gameObject.transform.parent.GetChild(2).GetChild(4).GetComponent<AttackProperties>();
        atk3L = gameObject.transform.parent.GetChild(2).GetChild(5).GetComponent<AttackProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") && !anim.GetBool("isAttacking") && /*Time.time > nextAttack*/!anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
        {
            if (character.stamina > atk1R.stamina & character.stamina > atk1L.stamina)
            {
                Attack();
            }
            else
            {
                stamina.LowStamina();
            }
        } else
        if (Input.GetKeyDown(KeyCode.Mouse0) && anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
        {
            if (character.stamina > atk2R.stamina & character.stamina > atk2L.stamina)
            {
                Attack2();
            }
            else
            {
                stamina.LowStamina();
            }
        } else
        if (Input.GetKeyDown(KeyCode.Mouse0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") && anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk3") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
        {
            if (character.stamina > atk3R.stamina & character.stamina > atk3L.stamina)
            {
                Attack3();
            }
            else
            {
                stamina.LowStamina();
            }
        }
    }
    void Attack()
    {       
        anim.SetTrigger("hit");
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        nextAttack = Time.time + attackInterval;
    }
    void Attack2()
    {
        anim.SetTrigger("hit2");
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        nextAttack = Time.time + attackInterval;
    }
    void Attack3()
    {
        
        anim.SetTrigger("hit3");
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        nextAttack = Time.time + attackInterval;
    }
    /*void LowStamina()
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
    }*/
}
