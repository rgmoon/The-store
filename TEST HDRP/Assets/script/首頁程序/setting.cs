using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class setting : MonoBehaviour
{
    public ­º­¶Ä²µo menutrigger;
    public Animator setmenu,setmenu2;
    public AudioMixer mainaudio;
    public void Setting() {
     menutrigger.settingmenu.SetActive(true);
     StartCoroutine(animate());
    }
    IEnumerator animate() {
     yield return new WaitForSeconds(0.001f);
     setmenu.Play("setting");
        setmenu2.Play("setting");
    }
    public void Setvolume(float volume) {
        mainaudio.SetFloat("Volume",Mathf.Log10(volume) *20);
    }
}
