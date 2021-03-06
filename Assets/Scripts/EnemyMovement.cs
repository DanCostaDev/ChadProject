using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float nearDistance;

    private bool facingRight = false;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.parent.position, player.position) > nearDistance && !anim.GetCurrentAnimatorStateInfo(0).IsName("DioDmg") && !anim.GetCurrentAnimatorStateInfo(0).IsName("DioAtk1"))
        {
            facingRight = (player.position.x < transform.parent.position.x) ? false : true;
            if (facingRight)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            anim.SetBool("isWalking", true);
            Vector3 movement = new Vector3(player.position.x, 0f, player.position.z);
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, movement, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
