using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarOutline : MonoBehaviour
{
    private UnityEngine.UI.Outline outline;
    // Start is called before the first frame update
    void Start()
    {

        outline = GetComponent<UnityEngine.UI.Outline>();
        outline.effectColor = new Color(1f, 1f, 1f, 0f);
        outline.effectDistance = new Vector2(1, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
