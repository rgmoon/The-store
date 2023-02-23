using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 首頁觸發 : MonoBehaviour
{
    public GameObject inanim,texts,startbtn,settingbtn,settingmenu;
    public Material[] materials;
    public Renderer rend;
    bool isClick=false;
    bool test;
    // Start is called before the first frame update
    void Start()
    {
       rend.enabled=true;
       rend.sharedMaterial=materials[0];
        inanim.SetActive(false);
        texts.SetActive(true);
        startbtn.SetActive(false);
        settingbtn.SetActive(false);
        settingmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown&&isClick==false)
        {
         
            //RAW.SetActive(false);
           inanim.SetActive(true); 
           texts.SetActive(false);
            isClick=true;
            StartCoroutine(DDD());
        }
    }
    IEnumerator DDD()
    {
        yield return new WaitForSeconds(2.7f);
        rend.sharedMaterial=materials[1];
        yield return new WaitForSeconds(0.5f);
        rend.sharedMaterial=materials[2];
        startbtn.SetActive(true);
        settingbtn.SetActive(true);

    }
}
