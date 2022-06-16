using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPillar : MonoBehaviour
{
    public GameObject fractured;
    public float breakForce;

    private Collider childrenFrac;
    private float randomNumber;
    private GameObject medKit;
    private Animator anim;

    // Update is called once per frame
    void Start()
    {
        fractured = (GameObject)Resources.Load("Prefabs/BreakablePillarFragments");
    }
    private void OnCollisionEnter(Collision other)
    {
        anim = other.gameObject.GetComponentInChildren<Animator>();
        if ((other.relativeVelocity.x >= 15 | other.relativeVelocity.x <= -15) & anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            Vector3 force = ((other.transform.position - transform.position)).normalized * 300;
            other.gameObject.GetComponent<Rigidbody>().AddForce(force);
            BreakThis();
        }
    }

    public void BreakThis()
    {
        GameObject frac = Instantiate(fractured, transform.position, Quaternion.Euler(0, 90, 0));
        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 explosion = new Vector3(rb.transform.position.x - transform.position.x, 0f, rb.transform.position.z - transform.position.z);
            Vector3 force = (explosion).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);
    }
}
