using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMaskTransform(string state)
    {
        switch(state)
        {
            case "Money":
                transform.position = new Vector2(-1.85f, 0.75f);
                transform.localScale = new Vector2(1.35f,0.5f);
                break;
        }
    }
}
