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
     [SerializeField]Vector3 walkPoint,chesspoint,getDarkpoint;
    public bool walkPointSet,toDarkset;
    public float walkPointRange,walkDarkRange;


   
    bool alreadyAttacked;
    public bool s =false;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange,InDark,InLight;

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
        float anispeed=nav.velocity.magnitude;
        ani.SetFloat("Speed",anispeed);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        InDark = Physics.CheckSphere(transform.position, sightRange, whatisDark);
        InLight = Physics.CheckSphere(transform.position, sightRange, whatisLight);
        if(!playerInSightRange&&s==false)
        {
            Patroling();
        } else if(InLight)
        {
            gotodark();
        }
        if (playerInSightRange||s==true)
        {
            if(InDark)
            {
                StartCoroutine("chessanicount");
                Chess();
            }
        }
        
             
        
       
       // Debug.Log(s);
    }
    private void Patroling()
    {
        if (!walkPointSet&&正在巡邏==false) SearchWalkPoint();

        if (walkPointSet)
            nav.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
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
        }
        transform.LookAt(walkPoint);
        StartCoroutine("ddd");
    }
    private void gotodark()
    {
        if(!toDarkset) SearchDark();
        if(toDarkset)  nav.SetDestination(getDarkpoint);
        Vector3 distancetodark=transform.position-getDarkpoint;
        if(distancetodark.magnitude<1f)
        toDarkset=false;
    }
    private void SearchDark(){
        float rZ = Random.Range(-walkDarkRange, walkDarkRange);
        float rX = Random.Range(-walkDarkRange, walkDarkRange);
        getDarkpoint=new Vector3(transform.position.x + rX, transform.position.y, transform.position.z + rZ);
        if (Physics.Raycast(getDarkpoint, -transform.up, 2f, whatisDark))
        {
            toDarkset = true;
        }
    }
     IEnumerator ddd()
    {   
        正在巡邏=true;
        yield return new WaitForSeconds(巡邏間隔); 
        正在巡邏=false;
    } 
    public void Chess()
    {   
        StartCoroutine("chessanicount");
        
       
        transform.LookAt(chesspoint);
    }
    IEnumerator chessanicount()
    {
        ani.SetBool("ISDECTED",true);
        yield return new WaitForSeconds(5);
        
      
        chesspoint=new Vector3(palyer.transform.position.x, transform.position.y, palyer.transform.position.z );
    if(Physics.Raycast(chesspoint, -transform.up, 2f, whatisDark))
       nav.SetDestination(palyer.transform.position);
    }
}
