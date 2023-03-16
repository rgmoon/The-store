using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class computer : MonoBehaviour
{
    bool start;
    public void test()
    {
        SceneManager.LoadScene("playground");

    }
    public void savegame() {
        DataPersistence.instance.save();
    }
    public void loadgame()
    {
    DataPersistence.instance.load();
    }
    public void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
