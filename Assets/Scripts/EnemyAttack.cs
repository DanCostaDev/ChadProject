using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        anim = transform.parent.gameObject.transform.GetChild(0).GetComponent<Animator>();
        if (other.CompareTag("PlayerCollider")){
            Debug.Log("Colidiu");
            anim.SetTrigger("Hit1");
            anim.SetBool("isWalking", false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
