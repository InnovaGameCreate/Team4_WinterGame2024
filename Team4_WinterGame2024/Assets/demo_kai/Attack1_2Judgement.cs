using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_2Judgement : MonoBehaviour
{
    private bool judge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (CompareTag("Player"))
        {
            judge = true;
        }
        else
        {
            judge = false;
        }
    }
    public bool Judge()
    {
        return judge;
    }
}
