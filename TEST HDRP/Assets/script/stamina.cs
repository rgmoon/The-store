using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stamina : MonoBehaviour
{
    public float staminavalue;
    float maxstaminavalue;
    public Slider staminabar;
    public float dvalue;
    // Start is called before the first frame update
    void Start()
    {
        maxstaminavalue = staminavalue;
        staminabar.maxValue = maxstaminavalue;
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKey(KeyCode.LeftShift))
            DecreaseStamina();
     else if(staminavalue!=maxstaminavalue)
            IncreaseStamina();
        staminabar.value = staminavalue;

    }
    private void DecreaseStamina()
    {
        if (staminavalue != 0) {
            staminavalue -= dvalue * Time.deltaTime;
        if(staminavalue<=-1)
            staminavalue = 0;
        }
    }
    private void IncreaseStamina()
    {
    staminavalue += dvalue * Time.deltaTime;
        if (staminavalue >= maxstaminavalue)
            staminavalue = maxstaminavalue;
    }
}
