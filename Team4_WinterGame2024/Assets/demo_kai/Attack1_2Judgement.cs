using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_2Judgement : MonoBehaviour
{
    private int hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (CompareTag("player"))
        {
            Debug.Log("stay"); 
        }
        else
        {
        }
    }
    public void Judge()
    {
    }
}
