using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 光怪視野觸發 : MonoBehaviour
{
    public 光怪追擊 光怪追擊;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            
            光怪追擊.s=true;
            ///Debug.Log("sus");
        }
    }
    private void OnTriggerExit(Collider other) {
         if(other.tag=="Player")
        {
             
            光怪追擊.s=false;
        }
    }
}