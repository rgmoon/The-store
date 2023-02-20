using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 偵測轉頭 : MonoBehaviour
{
    public Transform selftra;
    public Quaternion sss;
    public bool start=false,isdead=false,ismem=false;
    // Start is called before the first frame update
     private void Awake() 
    {
        selftra=this.gameObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(start==true)
        {

            if(ismem==false)
                {
                    selftra.eulerAngles=transform.eulerAngles;
                    sss.eulerAngles=selftra.eulerAngles;
                    ismem=true;
                }
            if(sss.eulerAngles!=selftra.eulerAngles)
            {
                isdead=true;
            }
        }
    }
}
