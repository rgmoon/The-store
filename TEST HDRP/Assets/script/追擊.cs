using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class 追擊 : MonoBehaviour
{
    public Animator ani;
    public LayerMask whatIsGround, whatIsPlayer,whatisLight,whatisDark;
    public float 巡邏間隔;
    public bool 正在巡邏=false;
    

    //Patroling
     [SerializeField]Vector3 walkPoint,chesspoint,getDarkpoint,distancetodark;
    public bool walkPointSet,toDarkset;
    public float walkPointRange,walkDarkRange;
    public GameObject deadcamera;
    
   
    //bool alreadyAttacked;
    public bool s=false,chaseison=false;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange,InDark,InLight,isecu;
    float anispeed;
    // Start is called before the first frame update
    NavMeshAgent nav;
    public GameObject palyer;
    void Start()
    {
       nav=this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
   void Update()
    {
        
        
        if(Vector3.Distance(transform.position,palyer.transform.position)>=20)
         {
            isecu=false;
            
            ani.SetBool("Lost",true);
            nav.speed=(1f);
         }
        
        
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        InDark = Physics.CheckSphere(transform.position, sightRange, whatisDark);
        InLight = Physics.CheckSphere(transform.position, sightRange, whatisLight);
        if(!playerInSightRange&&s==false&&!InLight&&s==false&&toDarkset==false)
        {
            
            nav.speed=(1f);
            Patroling();
        } 
            else if(InLight||toDarkset==true)
            { 
                gotodark();
            }
        if (s==true&&toDarkset==false)
        {
            if(InDark)
            {
                //StartCoroutine("chessanicount");
                Chess();
            }
        }else
        {
            s=false;
            ani.SetBool("dected",false);
        }
        if(playerInSightRange)
        {
            deadcamera.SetActive(true);
            
        }
             
        
       
       // Debug.Log(s);
    }
    private void Patroling()
    {
        if (!walkPointSet&&正在巡邏==false) 
        {
            //getDarkpoint=new Vector3(0,0,0);    
            SearchWalkPoint();
        }
        if (walkPointSet&&正在巡邏==false)
        {
            
            nav.SetDestination(walkPoint);
            ani.SetFloat("Speed",1);
           
        }else ani.SetFloat("Speed",0);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f&&正在巡邏==false)
            {
            //Debug.Log("DDD");
            
            ani.SetFloat("Speed",0);
            StartCoroutine("ddd");
            }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatisDark))
        {
            walkPointSet = true;
            //Debug.Log("suc");
            transform.LookAt(walkPoint);
        }
        
        
    }
    private void gotodark()
    {
        if(!toDarkset) SearchDark();
        
        if(toDarkset) 
        {   
            nav.SetDestination(getDarkpoint);
            ani.SetBool("scare",true);
             nav.speed=(3.5f);
        }
        Vector3 distancetodark=this.gameObject.transform.position-getDarkpoint;
        if(distancetodark.magnitude<1f&&正在巡邏==false)
        {
         Debug.Log("DDD");  
         toDarkset=false;
         ani.SetFloat("Speed",0);
         ani.SetBool("scare",false);
        }
        
    }
    private void SearchDark(){
        float rZ = Random.Range(-walkDarkRange, walkDarkRange);
        float rX = Random.Range(-walkDarkRange, walkDarkRange);
        getDarkpoint=new Vector3(transform.position.x + rX, transform.position.y, transform.position.z + rZ);
        if (Physics.Raycast(getDarkpoint, -transform.up, 2f, whatisDark))
        {
            toDarkset = true;
            transform.LookAt(getDarkpoint);
        }
    }
     IEnumerator ddd()
    {   
        正在巡邏=true;
        yield return new WaitForSeconds(巡邏間隔); 
        walkPointSet = false;
        正在巡邏=false;
    } 
    public void Chess()
    {   
        StartCoroutine("chessanicount");
        
       
        transform.LookAt(chesspoint);
    }
    IEnumerator chessanicount()
    {
        
        if(isecu==false)
        {   
            isecu=true;
            ani.SetBool("Lost",false);
            ani.SetBool("dected",true);
            nav.isStopped = true;
            yield return new WaitForSeconds(5f);
            nav.isStopped = false;
            ani.SetBool("dected",false);
        }

      nav.speed=(3.5f);
        chesspoint=new Vector3(palyer.transform.position.x, transform.position.y, palyer.transform.position.z );
    if(Physics.Raycast(chesspoint, -transform.up, 2f, whatisDark))
       nav.SetDestination(palyer.transform.position);
    }
}
