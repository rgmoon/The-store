using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class 追擊 : MonoBehaviour ,IDatapersistence
{
    public IAMDEAD over;
    public Animator ani;
    public LayerMask whatIsGround, whatIsPlayer,whatisLight,whatisDark,whatisWarning;
    public float 巡邏間隔;
    public bool 正在巡邏=false;
    public bool playerinlight;

    //Patroling
     [SerializeField]Vector3 walkPoint,chesspoint,getDarkpoint,distancetodark;
    public bool walkPointSet,toDarkset,chessing;
    public float walkPointRange,walkDarkRange,standsight,walksight,runsight;
    public GameObject deadcamera,deletecam;
    CharacterController PlayerRig;
   
    //bool alreadyAttacked;
    public bool s=false,chaseison=false;
    //States
    public float sightRange, attackRange,guardRange;
    public bool playerInDeadRange, playerinsight,InDark,InLight,isecu,inwarning;
    float anispeed;
        float smoothdamp=0f;
    float smoothtime=0.3f;
    // Start is called before the first frame update
    NavMeshAgent nav;
    public GameObject palyer;
    void Start()
    {
         PlayerRig=palyer.GetComponent<CharacterController>();
       nav=this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
   void Update()
    {
        if(inwarning)
        {
            walkPointRange=50;
            whatisDark=whatisWarning;
        }else
        {
            walkPointRange=10;
            whatisDark=LayerMask.NameToLayer("Dark");
        }
            if(PlayerRig.velocity.magnitude==0)
        {
            guardRange=standsight;
            //Debug.Log("stand");
        }
        else if(PlayerRig.velocity.magnitude>0&&!Input.GetKey(KeyCode.LeftShift))
        {
            guardRange=walksight;
            //Debug.Log("walk");

        } if(Input.GetKey(KeyCode.LeftShift)&&PlayerRig.velocity.magnitude>0)
            {
                guardRange=runsight;
               // Debug.Log("run");
            }
        
        if(Vector3.Distance(transform.position,palyer.transform.position)>=20)
         {
            Lost();
           
         }

        playerinsight=Physics.CheckSphere(transform.position,guardRange,whatIsPlayer);
        playerinlight=Physics.CheckSphere(palyer.transform.position, sightRange, whatisLight);
        playerInDeadRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        InDark = Physics.CheckSphere(transform.position, sightRange, whatisDark);
        InLight = Physics.CheckSphere(transform.position, sightRange, whatisLight);
        
        if(!playerInDeadRange&&s==false&&InLight==false)
        {
            toDarkset=false;
           
            ani.SetBool("scare",false);
            Patroling();
            //Debug.Log("Patroling");
        } 
             if(InLight)
            { 
                gotodark();
               Debug.Log("Escaping");
            }
        if (s==true&&toDarkset==false&&!playerinlight||(chessing==true&&!playerinlight))
        {
            chessing=true;
            if(InDark)
            {
                //StartCoroutine("chessanicount");
                Chess();
                Debug.Log("Chessing");
            }
        }else if(playerinsight&&toDarkset==false&&!playerinlight||(chessing==true&&!playerinlight))
        {
             if(InDark)
            {
                chessing=true;
                //StartCoroutine("chessanicount");
                Chess();
                Debug.Log("Chessing");
            }
        }
        else
        {
            //Debug.Log("Lost");
            Lost();
        }
        if(playerInDeadRange)
        {
          deletecam.SetActive(false);
            CharacterController playercon=palyer.GetComponent<CharacterController>();
            playercon.enabled=false;
            deadcamera.SetActive(true);
            over.getover(6f);
            Destroy(this.gameObject);
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
            nav.speed=(1f);
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
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatisDark)&&!Physics.Raycast(walkPoint, -transform.up, 2f, whatisLight))
        {
            walkPointSet = true;
            //Debug.Log("suc");
            Vector3 dir=(walkPoint-transform.position).normalized;
            float targetangle=Mathf.Atan2(dir.x,dir.z)*Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetangle,ref smoothdamp,smoothtime);
            transform.rotation=Quaternion.Euler(0f,angle,0f);
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
        if(distancetodark.magnitude<1f)
        {
         //Debug.Log("DDD");  
         //SearchWalkPoint();
         toDarkset=false;
         ani.SetFloat("Speed",0);
         ani.SetBool("scare",false);

        }
        
    }
    private void SearchDark(){
        float rZ = Random.Range(-walkDarkRange, walkDarkRange);
        float rX = Random.Range(-walkDarkRange, walkDarkRange);
        getDarkpoint=new Vector3(transform.position.x + rX, transform.position.y, transform.position.z + rZ);
        if(Physics.Raycast(getDarkpoint, -transform.up, 5f, whatisLight))
        {
            toDarkset = false;
        }
        else if(Physics.Raycast(getDarkpoint, -transform.up, 5f, whatisLight)&&Physics.Raycast(getDarkpoint, -transform.up, 5f, whatisDark))
        {
            toDarkset = false;
        }
        else if (Physics.Raycast(getDarkpoint, -transform.up, 5f, whatisDark))
        {
            SearchWalkPoint();
            toDarkset = true;
            //transform.LookAt(getDarkpoint);
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
        
       
        
    }
    private void Lost()
    {
        chessing=false;
            s=false;
            isecu=false;
            ani.SetBool("Lost",true);
            ani.SetBool("dected",false);
    }
    IEnumerator chessanicount()
    {
        /*發現警告動畫*/
        if(isecu==false)
        {   
            isecu=true;
            ani.SetBool("Lost",false);
            ani.SetBool("dected",true);
            nav.isStopped = true;
            transform.LookAt(chesspoint);
            yield return new WaitForSeconds(5f);
            nav.isStopped = false;
            ani.SetBool("dected",false);
        }
        if(chessing==false)
        {
            yield break;
        }
        
      
        chesspoint=new Vector3(palyer.transform.position.x, transform.position.y, palyer.transform.position.z );
        if(Physics.Raycast(chesspoint, -transform.up, 2f, whatisDark))
        {
            
             nav.SetDestination(palyer.transform.position);
             nav.speed=(3.5f);
         }else if(Physics.Raycast(chesspoint, -transform.up, 2f, whatisLight))
         {

            Debug.Log("Lost");
             ani.SetBool("Lost",true);
            ani.SetBool("dected",false);
            nav.speed=(1f);
             isecu=false;
            s=false;

         }
    }

    public void loaddata(Gamedata data)
    {
        this.transform.position = data.P2postition;
        this.transform.rotation = data.P2rotation;
    }

    public void savedata(ref Gamedata data)
    {
        data.P2postition = this.transform.position;
        data.P2rotation = this.transform.rotation;
    }
}
