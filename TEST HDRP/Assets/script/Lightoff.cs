using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightoff : MonoBehaviour
{
    
    //public GameObject Light,Dark;
    /*燈開關*/
    public bool isLightOn=true;
    /*是否中毒*/
      public bool toxic=false;
    /*初始碰撞判斷*/
      public bool entry=false;
    /*結束恢復判斷*/
      public bool over=false;
      /*防彈跳*/
      public bool ishit=false;
       Light ligh;
      public bool backtime=false;
    // Start is called before the first frame update
    void Start()
    {
         ligh =this.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightOn)
        {
           
            ligh.enabled=true;
            this.gameObject.layer=LayerMask.NameToLayer("Light");
        }
        if(!isLightOn)
        {
            
            ligh.enabled=false;
            this.gameObject.layer=LayerMask.NameToLayer("Dark");
        }
        if(backtime==true&&ishit==true&&over==true)
        {
            
            isLightOn=!isLightOn;
            backtime=false;
            ishit=false;
            over=false;
        }
        //else{backtime=false;}
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"&&toxic==true&&ishit==false&&isLightOn==true)
        {
            isLightOn=false;
            over=true;
            ishit=true;
        }
        /* if(other.tag=="感光"&&toxic==true&&entry==true)
        {
s
            over=true;

        }*/
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player"&&toxic==true)
        {
            //isLightOn=!isLightOn;
           // over=false;
            
        }

    }
    private void OnTriggerStay(Collider other) {
        if(other.tag=="Player"&&entry==false&&toxic==true&&ishit==false&&isLightOn==true)
        {
            isLightOn=false;
            entry=true;
            over=true;
            ishit=true;
        }
            /* if(other.tag=="感光"&&entry==false&&toxic==true)
        {
    
            entry=true;
            over=true;
   
        }*/
        /*if(other.tag=="感光"&&over==true&&toxic==false)
        {
                isLightOn=!isLightOn;
                over=false;
        }*/
        
    }
    
}