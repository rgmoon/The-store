using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightoff : MonoBehaviour
{
    
    public GameObject Light,Dark;
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
      public bool backtime=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLightOn)
        {
            Dark.SetActive(false);
            Light.SetActive(true);
        }
        if(!isLightOn)
        {
            Dark.SetActive(true);
            Light.SetActive(false);
        }
        if(backtime==true&&ishit==true&&over==true)
        {
            isLightOn=!isLightOn;
            backtime=false;
            ishit=false;
            over=false;
        }else{backtime=false;}
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="感光"&&toxic==true&&ishit==false)
        {
            isLightOn=!isLightOn;
            over=true;
            ishit=true;
        }
        /* if(other.tag=="感光"&&toxic==true&&entry==true)
        {

            over=true;

        }*/
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="感光"&&toxic==true)
        {
            //isLightOn=!isLightOn;
           // over=false;
            
        }

    }
    private void OnTriggerStay(Collider other) {
        if(other.tag=="感光"&&entry==false&&toxic==true&&ishit==false)
        {
            isLightOn=!isLightOn;
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