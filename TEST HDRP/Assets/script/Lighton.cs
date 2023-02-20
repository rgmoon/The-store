using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighton : MonoBehaviour
{
    public GameObject[] Light,Dark;
    public int max ;
    public bool isLightOn=false;
    public bool toxic=false;
    // Start is called before the first frame update
    void Start()
    {
           for(int i=0;i<max;i++)
           {
            Dark[i].SetActive(true);
            Light[i].SetActive(false);
           }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightOn)
        {
            for(int i=0;i<max;i++)
            {
            Dark[i].SetActive(false);
            Light[i].SetActive(true);
            }
        }
        if(!isLightOn)
        {
             for(int i=0;i<max;i++)
             {
            Dark[i].SetActive(true);
            Light[i].SetActive(false);
             }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="感光"&&toxic==true)
        {
            isLightOn=!isLightOn;
        }
    }
}
