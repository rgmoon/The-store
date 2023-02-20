using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class 光怪追擊 : MonoBehaviour
{
  public LayerMask whatIsGround, whatIsPlayer,whatisLight,whatisDark;
    public float 巡邏間隔;
    public bool 正在巡邏=false;
    public float health;

    //Patroling
    public Vector3 walkPoint,chesspoint,getLightpoint;
    bool walkPointSet,toLIghtset;
    public float walkPointRange,walkDarkRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public bool s =false;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange,playerInDark,playerInLight;

    // Start is called before the first frame update
    NavMeshAgent nav;
    public GameObject palyer;
    void Start()
    {
        nav=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
   void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInDark = Physics.CheckSphere(transform.position, sightRange, whatisDark);
        playerInLight = Physics.CheckSphere(transform.position, sightRange, whatisLight);
        if(!playerInSightRange&&playerInLight&&!playerInDark)
        {
            Patroling();
            Debug.Log("isPatroling");

        } else if(playerInDark)
            {
                gotoLight();
                Debug.Log("isEscaping");
            }
        if (playerInSightRange||s==true)
        {
            if(playerInLight)
            Chess();
            Debug.Log("isChessing");
        }
            
        //Debug.Log(s);
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
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)&&Physics.Raycast(walkPoint, -transform.up, 2f, whatisLight))
        {
            walkPointSet = true;
        }
        transform.LookAt(walkPoint);
            StartCoroutine("ddd");
    }
    private void gotoLight()
    {
        if(!toLIghtset) SearchLight();
        if(toLIghtset)  nav.SetDestination(getLightpoint);
        Vector3 distancetoLight=transform.position-getLightpoint;
        if(distancetoLight.magnitude<1f)
        toLIghtset=false;
    }
    private void SearchLight(){
        float rZ = Random.Range(-walkDarkRange, walkDarkRange);
        float rX = Random.Range(-walkDarkRange, walkDarkRange);
        getLightpoint=new Vector3(transform.position.x + rX, transform.position.y, transform.position.z + rZ);
        if (Physics.Raycast(getLightpoint, -transform.up, 2f, whatisLight))
        {
            toLIghtset = true;
        }
    }
     IEnumerator ddd()
    {   
        正在巡邏=true;
        yield return new WaitForSeconds(2); 
        正在巡邏=false;
    } 
    public void Chess()
    {   
        nav.SetDestination(palyer.transform.position);
        chesspoint=new Vector3(palyer.transform.position.x, transform.position.y, palyer.transform.position.z );
        if(Physics.Raycast(chesspoint, -transform.up, 2f, whatisLight))
        transform.LookAt(chesspoint);
    }
}