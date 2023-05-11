using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{
    public class stamina : MonoBehaviour, IDatapersistence
    {
        public StarterAssetsInputs starterAssetsInputs;
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
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
                DecreaseStamina();
            else if (staminavalue != maxstaminavalue)
                IncreaseStamina();
            staminabar.value = staminavalue;
            if (staminavalue <= 0) {
                starterAssetsInputs.sprint = false;
            }
            //Debug.Log(staminavalue);

        }
        private void DecreaseStamina()
        {
            if (staminavalue != 0)
            {
                staminavalue -= dvalue * Time.deltaTime;
                if (staminavalue <= -1)
                    staminavalue = 0;
            }
        }
        private void IncreaseStamina()
        {
            staminavalue += dvalue * Time.deltaTime;
            if (staminavalue >= maxstaminavalue)
                staminavalue = maxstaminavalue;
        }
        public void loaddata(Gamedata data)
        {
            this.staminavalue = data.stamina;
        }
        public void savedata(ref Gamedata data)
        {
            data.stamina = this.staminavalue;
        }
    }
}
