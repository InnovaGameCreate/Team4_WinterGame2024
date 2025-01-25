using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_2Judgement : MonoBehaviour
{
    private bool hit;
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
        if (collider.CompareTag("player"))
        {
            hit = true;
        }
        else
        {
            hit = false;
        }
    }
    public void Judge()
    {
        if (hit==true)
        {
            Debug.Log("damage");
        }
    }
}
