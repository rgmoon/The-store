using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public STDtimer STDtime;
    public FirstPersonController playerController;
    public GameObject player, dpob,dptime,canlight,moneylight,maindoorlight;
    public float dis;
    public Timer1 timer;
    public bool cardtick = false;
    public bool clbl,mlbl,dlbl;
    bool proceed = false;
    void Start()
    {
        dptime.SetActive(false);
        STDtime.updatestdtime();
    }

    // Update is called once per frame
    private void Update()
    {
        timer.orgtsec = timer.orgsec + timer.orgmin * 60 + timer.orghour * 60 * 60;
        Vector3 target = transform.TransformDirection(Vector3.forward);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        RaycastHit hit;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (cardtick == false)
        {
            timer.timerstart();
            cardtick = true;
        }
        if (Physics.Raycast(transform.position, target, out hit, dis))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "Test")
            {
                timer.cancelinvoke();
                timer.sec = timer.orgsec;
                timer.min = timer.orgmin;
                timer.hour = timer.orghour;
                STDtime.updatestdtime();
                Debug.Log("tru");
            }
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "Test2")
            {

                if (proceed != true)
                {
                    StartCoroutine(displaytimer());
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "com")
            {
                SceneManager.LoadScene("computer");
            }
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "ml")
            {
                mlbl=!mlbl;
                if(mlbl==true)
                {
                    moneylight.SetActive(true);
                }else if(mlbl==false)
                {
                   moneylight.SetActive(false); 
                }
            }
             if (Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "dl")
            {
                dlbl=!dlbl;
                if(dlbl==true)
                {
                    maindoorlight.SetActive(true);
                }else if(dlbl==false)
                {
                   maindoorlight.SetActive(false); 
                }
            }
             if (Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "cl")
            {
                clbl=!clbl;
                if(clbl==true)
                {
                    canlight.SetActive(true);
                }else if(clbl==false)
                {
                   canlight.SetActive(false); 
                }
            }
        }
    }
    IEnumerator displaytimer()
    {
        dptime.gameObject.SetActive(true);
        proceed = true;
        yield return new WaitForSeconds(8);
        dptime.gameObject.SetActive(false);
        proceed = false;

    }

}

