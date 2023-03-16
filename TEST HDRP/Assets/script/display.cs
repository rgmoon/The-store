using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class display : MonoBehaviour
{
    public Timer1 timer1;
    [SerializeField]
    private Sprite[] digits;
    [SerializeField]
    private Image[] chr;
    // Update is called once per frame
   public void Update()
    {
        int last = timer1.sec % 10;
        int last2 = timer1.sec / 10;
        int lastmin = timer1.min % 10;
        int lastmin2 = timer1.min / 10;
        if (timer1.tsec >= 0)
        {
            chr[3].sprite = digits[last];
            chr[2].sprite = digits[last2];
            chr[1].sprite = digits[lastmin];
            chr[0].sprite = digits[lastmin2];
        }
    }

}
