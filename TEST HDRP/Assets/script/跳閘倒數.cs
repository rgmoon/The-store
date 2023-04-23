using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 跳閘倒數 : MonoBehaviour
{
    public bool iscount,ison ;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(iscount==true)
        {
            timer+=Time.deltaTime;

        }
        else if(ison==true)
        {
            timer+=Time.deltaTime/2;
        }
    }
}
