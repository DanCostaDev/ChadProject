using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitInitialize : MonoBehaviour
{
    private GameObject frag;
    // Start is called before the first frame update
    void Start()
    {
        if (frag = GameObject.FindGameObjectWithTag("BoxFragment"))
        {
            Debug.Log("ExisteFragmento");
            Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("BoxFragment").GetComponent<MeshCollider>(), true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerCollider")){
            other.gameObject.GetComponentInChildren<Health>().Heal(4);
            Destroy(gameObject);
        }
    }
}
