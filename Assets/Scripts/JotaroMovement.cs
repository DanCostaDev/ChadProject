using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JotaroMovement : MonoBehaviour
{
    float dirX, dirY, moveSpeed;
    public float moveSpeedBase;
    public float sprintSpeed;
    bool Sprint;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        Sprint = Input.GetButton("Fire3");
        moveSpeed = moveSpeedBase;

        bool returnAnim()
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk3") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk1") & !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroTransitionAtk2") & !anim.GetCurrentAnimatorStateInfo(0).IsName("Dmg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (Sprint == true)
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = moveSpeedBase;
        }

        if (returnAnim())
        {
            Vector3 movement = new Vector3(dirX, 0f, dirY);
            transform.parent.position += movement * Time.deltaTime * moveSpeed;
  
        }
        

        if (dirY > 0 && returnAnim())
        {
            anim.SetBool("isWalking", true);
        }
        else if (dirX < 0 && returnAnim())
        {
            anim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
            //transform.localScale = new Vector2(-1, 1);
        }
        else if (dirX > 0 && returnAnim())
        {
            anim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
            //transform.localScale = new Vector2(1, 1);
        }
        else if(dirY < 0 && returnAnim())
        {
            anim.SetBool("isWalking", true);
        }
        else if(dirX == 0 && dirY == 0 && returnAnim())
        {
            anim.SetBool("isWalking", false);
      
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        /*if (Input.GetButton("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("JotaroAtk"))
        {
            anim.SetBool("isWalking", false);
            anim.SetTrigger("hit");

        }*/
    }
}
