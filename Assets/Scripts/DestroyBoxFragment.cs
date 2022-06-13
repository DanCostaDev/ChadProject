using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxFragment : MonoBehaviour
{
    private float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timePassed > 10f)
        {
            Destroy(gameObject);
        }
    }
}
