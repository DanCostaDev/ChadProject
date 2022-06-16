using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitInitialize : MonoBehaviour
{
    private GameObject frag;
    public GameObject particle;
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
            GameObject part = Instantiate(particle, other.transform.GetChild(0).transform.position, other.transform.rotation);
            other.gameObject.GetComponentInChildren<Health>().Heal(4);

            Destroy(gameObject);
        }
    }
}
