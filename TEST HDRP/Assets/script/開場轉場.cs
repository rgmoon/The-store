using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 開場轉場 : MonoBehaviour
{
    public GameObject 主角cam,刪除cam;
    // Start is called before the first frame update
    void Start()
    {
        主角cam.SetActive(false);
        StartCoroutine("ddd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ddd()
    {
        yield return new WaitForSeconds(5.616667f);
        主角cam.SetActive(true);
        刪除cam.SetActive(false);
    }
}
