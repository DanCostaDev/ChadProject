using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPillarFragments : MonoBehaviour
{
    private float randomNumber;
    private float timePassed;
    private GameObject medKit;
    private string colTag;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = UnityEngine.Random.Range(2f, 5f);
        timePassed = Time.time;
        Physics.IgnoreCollision(GetComponent<MeshCollider>(), GameObject.FindGameObjectWithTag("PlayerCollider").GetComponent<Collider>(), true);
        Physics.IgnoreCollision(GetComponent<MeshCollider>(), GameObject.FindGameObjectWithTag("Pillar").GetComponent<Collider>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timePassed > randomNumber)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        colTag = other.gameObject.tag;
        if (colTag == "Prop" | colTag == "Enemy" | colTag == "Box")
        {           
            Physics.IgnoreCollision(GetComponent<MeshCollider>(), other.gameObject.GetComponent<Collider>(), true);
        }
    }

}
