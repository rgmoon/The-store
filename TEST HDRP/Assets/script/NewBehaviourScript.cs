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
    public GameObject player, dpob,dptime;
    public float dis;
    public Timer1 timer;
    public bool cardtick = false;
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

