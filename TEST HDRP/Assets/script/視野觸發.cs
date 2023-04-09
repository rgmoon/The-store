using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 視野觸發 : MonoBehaviour
{
    public 追擊 追擊;
    [Range(0,360)]
    public float angle;
    
    public float radius;
    public GameObject player;
    public LayerMask target,obstruction;
    
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(fovroutine());
    }

    private IEnumerator fovroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            fovcheak();
        }
    }
    private void fovcheak()
    {
        Collider[] rcheak=Physics.OverlapSphere(transform.position,radius,target);
        
        if(rcheak.Length!=0)
        {
            Transform target=rcheak[0].transform;
            Vector3 directiontotarget=target.position-transform.position;
            if(Vector3.Angle(transform.forward,directiontotarget)<angle/2)
            {
                float distancetotarget=Vector3.Distance(transform.position,target.position);
                if(!Physics.Raycast(transform.position,directiontotarget,distancetotarget,obstruction))
                {
                    追擊.s=true;
                    
                }

            }
              
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }






    /*private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            
            追擊.s=true;
            Debug.Log("sus");
        }
    }
    private void OnTriggerExit(Collider other) {
         if(other.tag=="Player")
        {
             
            追擊.s=false;
        }
    }*/
}
