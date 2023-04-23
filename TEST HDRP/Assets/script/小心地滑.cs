 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 小心地滑 : MonoBehaviour
{
    public GameObject 小心地滑實物;
    public LayerMask whatisPlayer,ground,vision;
    public GameObject player;
    public float max,min;
    public float ToxicTime;
    public bool playerLimitemin,playerLimitemax,playervision;
    public bool isPlace=false;
    bool istox=false;
    public Lightoff[] Lightoff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(isPlace==false)
        {
            float randomZ = Random.Range(-10, 10);
            float randomX = Random.Range(-10, 10);
            Vector3 ddd=new Vector3(player.transform.position.x+randomX,player.transform.position.y,transform.position.z+randomZ);
            playerLimitemax = Physics.CheckSphere(ddd, max, whatisPlayer);
            playerLimitemin = Physics.CheckSphere(ddd, min, whatisPlayer);
            playervision = Physics.CheckSphere(ddd, 1, vision);
            if(Physics.Raycast(ddd, -transform.up, 2f, ground)&&!playerLimitemin&&playerLimitemax&&!playervision)
            {
            
            小心地滑實物.transform.position=new Vector3(player.transform.position.x+randomX,player.transform.position.y,transform.position.z+randomZ);
           isPlace=true;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag==("Player"))
        {
           // Debug.Log("place");
            StartCoroutine(ddd());
            istox=true;
            isPlace=false;

           
            
        }
    }
    IEnumerator ddd()
    {
        for(int i=0;i<Lightoff.LongLength;i++)
            {
             Lightoff[i].toxic=true;
             //Debug.Log(i);
            }
            
        yield return new WaitForSeconds(ToxicTime); 
        Debug.Log("Changed");
        
        for(int i=0;i<Lightoff.LongLength;i++)
        {
        Lightoff[i].toxic=false;
        Lightoff[i].entry=false;
        /*Lightoff[i].over=true;*/

        Lightoff[i].backtime=true;
        //Lightoff[i].over=false;
        
        }
    }
}
