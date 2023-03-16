using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public STDtimer STDtime;
    public backtogame backgame;
    public computer com;
    public Camera cam1;
    public Camera cam2;
    public FirstPersonController playerController;
    public GameObject player, dpob,dptime;
    public float dis;
    public Transform playersoc;
    public Timer1 timer;
    public bool cardtick = false;
    bool proceed = false;
    bool afk = true;
    bool gamestarted = false;
    void Start()
    {
        dptime.SetActive(false);
        STDtime.updatestdtime();
        afk = false;
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
        if (afk == false && cam1 != null)
        {
            cam1.transform.position = Vector3.Lerp(cam1.transform.position, cam2.transform.position, 0.02f);
            cam1.transform.rotation = Quaternion.Lerp(cam1.transform.rotation, cam2.transform.rotation, 0.02f);
            StartCoroutine(startgame());
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
    IEnumerator startgame()
    {
        yield return new WaitForSeconds(1.5f);
        if (cam1 != null)
        {
            Destroy(cam1.gameObject);
        }
        playerController.GetComponent<FirstPersonController>().enabled = true;

    }

}

