using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 第一次提報測試程式 : MonoBehaviour
{
    public GameObject A區,B區,Amask,Bmask;
    public bool Aison=false,Bison=true;
    // Start is called before the first frame update
    void Start()
    {
      // A區.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetMouseButtonDown(0))
        {
            Aison=!Aison;
            if(Aison)
            {
                A區.SetActive(true);
                Amask.layer=LayerMask.NameToLayer("Light");
                
            }
            if(Aison==false)
            {
                A區.SetActive(false);
                Amask.layer=LayerMask.NameToLayer("Dark");
             
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Bison=!Bison;
            if(Bison)
            {
                B區.SetActive(true);
                Bmask.layer=LayerMask.NameToLayer("Light");
                
            }
            if(Bison==false)
            {
                B區.SetActive(false);
                Bmask.layer=LayerMask.NameToLayer("Dark");
             
            }
        }*/
    }
}
