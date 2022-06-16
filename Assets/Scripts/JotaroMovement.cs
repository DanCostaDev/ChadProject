using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JotaroMovement : MonoBehaviour
{
    float dirX, dirZ, moveSpeed;
    public float moveSpeedBase;
    public float sprintSpeed;
    bool Sprint;
    private int direction;
    private Vector3 vector;
    private Character character;
    private Health stamina;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponentInParent<Character>();
        stamina = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirZ = Input.GetAxisRaw("Vertical");
        Sprint = Input.GetButton("Fire3");
        moveSpeed = moveSpeedBase;

        bool returnAnim()
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroRoll") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk3") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroRoll"))
            {
                if (character.stamina >= 40)
                {
                    if (GetComponent<SpriteRenderer>().flipX == true)
                    {
                        direction = -1;
                    }
                    else
                    {
                        direction = 1;
                    }
                    if (dirX == 0 & dirZ == 0)
                    {
                        vector = new Vector3(direction, 0f, dirZ).normalized * 2000;
                    }
                    else
                    {
                        vector = new Vector3(dirX, 0f, dirZ).normalized * 2000;
                    }
                    anim.SetTrigger("roll");
                    GetComponentInParent<Rigidbody>().AddForce(vector);
                    stamina.LoseStamina(40);
                }
                else
                {
                    stamina.LowStamina();
                }
            }
        }
        else
        {
            if (Sprint == true)
            {
                moveSpeed = sprintSpeed;
                anim.SetFloat("runSpeed", 1.5f);
            }
            else
            {
                moveSpeed = moveSpeedBase;
                anim.SetFloat("runSpeed", 1.0f);
            }

            if (returnAnim())
            {
                Vector3 movement = new Vector3(dirX, 0f, dirZ);
                transform.parent.position += movement * Time.deltaTime * moveSpeed;

            }


            if (dirX < 0 & returnAnim())
            {
                anim.SetBool("isWalking", true);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (dirX > 0 & returnAnim())
            {
                anim.SetBool("isWalking", true);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (dirZ > 0 & returnAnim())
            {
                anim.SetBool("isWalking", true);

            }
            else if (dirZ < 0 & returnAnim())
            {
                anim.SetBool("isWalking", true);
            }
            else if (dirX == 0 & dirZ == 0 && returnAnim())
            {
                anim.SetBool("isWalking", false);

            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }

        
        /*if (Input.GetButton("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk"))
        {
            anim.SetBool("isWalking", false);
            anim.SetTrigger("hit");

        }*/
    }
}
