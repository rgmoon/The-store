using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class P1AI : MonoBehaviour
{
    public LayerMask whatIsGround, whatIsPlayer;
    public bool isChessing=false,playerstandby,playerwalk,playerrun,playerinsight,CHESSING;
    bool walkPointSet,正在巡邏,追擊停滯;
    public Vector3 walkPoint,chesspoint;
    public int sightRange,runsight=5,walksight=2,standsight=0,walkPointRange,CHESSRANG=10;
    public CharacterController PlayerRig;
    public GameObject palyer;
     NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
       // Debug.Log(isChessing);
        
        if(PlayerRig.velocity.magnitude==0)
        {
            sightRange=standsight;
            //Debug.Log("stand");
        }
        else if(PlayerRig.velocity.magnitude>0&&!Input.GetKey(KeyCode.LeftShift))
        {
            sightRange=walksight;
            //Debug.Log("walk");

        } if(Input.GetKey(KeyCode.LeftShift)&&PlayerRig.velocity.magnitude>0)
            {
                sightRange=runsight;
               // Debug.Log("run");
            }
        CHESSING=Physics.CheckSphere(transform.position,CHESSRANG,whatIsPlayer);
        playerinsight=Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
        /*else if(PlayerRig.velocity.magnitude>0&&Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("run");
        }*/
        if(playerinsight)
        {
            
            Chess(); 
            
            Debug.Log("isChess");
           
        }
        else if(!正在巡邏&&!playerinsight&&isChessing==false&&!追擊停滯)
        {
             Patroling();
             Debug.Log("isPatroling");
        }
     Vector3 selfpos=chesspoint-transform.position;
        if(selfpos.magnitude<=0.1f)
        {
            isChessing=false;
            StartCoroutine("AAA");
        }
    }
        private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            nav.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
             StartCoroutine("ddd");
        }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
        transform.LookAt(walkPoint);
            
    }
         IEnumerator ddd()
    {   
        正在巡邏=true;
        yield return new WaitForSeconds(1); 
        正在巡邏=false;
    } 
    IEnumerator AAA()
    {
        追擊停滯=true;
        yield return new WaitForSeconds(2);
        追擊停滯=false;
    }
        public void Chess()
    {   
        
            //Debug.Log("isChess");   
            chesspoint=new Vector3(palyer.transform.position.x, transform.position.y, palyer.transform.position.z );
            nav.SetDestination(chesspoint);
        isChessing=true;
        
        

        if(Physics.Raycast(chesspoint, -transform.up, 2f, whatIsGround))
        transform.LookAt(chesspoint);
    }
    
}
