using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5AI : MonoBehaviour
{
    public LayerMask ground;
    public bool Playeringround;
    public bool warning,show;
    public float warnline,showline,distance;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos=player.transform.position;
        Vector3 P5Pos=transform.position; 
        distance=Vector3.Distance(P5Pos,PlayerPos);
        if(distance<=warnline)
        {
            warning=true;
        }else warning=false;
        if(distance<=showline)
        {
            show=true;
        }else show=false;
    }
}
