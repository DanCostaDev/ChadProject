using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour
{
    public GameObject fractured;
    public float breakForce;

    private Collider childrenFrac;
    private float randomNumber;
    private GameObject medKit;

    // Update is called once per frame
    void Start()
    {
        medKit = (GameObject)Resources.Load("Prefabs/MedKit");
        randomNumber = UnityEngine.Random.Range(0f, 10f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            BreakThis();
        }
    }

    public void BreakThis()
    {
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);
        if(randomNumber >= 5)
        {
            Instantiate(medKit, transform.position, Quaternion.Euler(0, 0, 0));
            Vector3 force = (new Vector3(0, medKit.transform.position.y, 0)).normalized *200;
        }
        foreach(Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {

            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);
    }
}
