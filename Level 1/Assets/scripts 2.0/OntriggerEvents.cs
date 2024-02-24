using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Char")
        {
            //Debug.Log("Finish");
            //animator.SetBool("jump", true);
        }
    }
}
