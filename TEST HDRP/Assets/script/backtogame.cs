using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backtogame : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    bool camgo;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            camgo = true;
        }
        if (camgo == true)
        {
            cam1.transform.position = Vector3.Lerp(cam1.transform.position, cam2.transform.position, 0.02f);
            cam1.transform.rotation = Quaternion.Lerp(cam1.transform.rotation, cam2.transform.rotation, 0.02f);
            StartCoroutine(startgame());
        }
    }
    IEnumerator startgame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("computer");
        camgo = false;

    }
}
