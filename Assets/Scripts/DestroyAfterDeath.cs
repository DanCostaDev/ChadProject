using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void DestroyDead()
    {
        Destroy(transform.parent.gameObject);
    }
}
