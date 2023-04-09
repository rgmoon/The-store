using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class IAMDEAD : MonoBehaviour
{
    //public bool dead;
    // Start is called before the first frame update
   
    public GameObject deadscean;
    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getover(float dead)
    {
        StartCoroutine("overcount",dead);
    }
    public IEnumerator overcount(float dead)
    {
        
        yield return new WaitForSeconds(dead);
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        //deadcrag.SetActive(true);
       
        
        SceneManager.LoadScene(0);
    }
    
}
