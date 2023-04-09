using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class time : MonoBehaviour,IDatapersistence
{
    [SerializeField]
    private Sprite[] digits;
    [SerializeField]
    private Image[] chr;
    public int hour ,sec, min;
    public void Start()
    {
        InvokeRepeating("stdtimer", 1, 1f);
        hour = 1;

    }
    public void Update()
    {
        int stdlastmin = min % 10;
        int stdlastmin2 = min / 10;
        int stdlasthour = hour % 10;
        int stdlasthour2 = hour / 10;
        chr[3].sprite = digits[stdlastmin];
        chr[2].sprite = digits[stdlastmin2];
        chr[1].sprite = digits[stdlasthour];
        chr[0].sprite = digits[stdlasthour2];
    }
    public void stdtimer()
    {
        sec = sec + 6;
        if (sec > 59 && min < 60)
        {
        min++;
        sec = 0;
        }
        if (min > 59)
        {
         min = 0;
         hour++;

        }
        if (hour > 23)
        {
            hour = 0;
        }
    }
    public void loaddata(Gamedata data)
    {
        this.min = data.Gamemin;
        this.hour = data.Gamehour;
    }
    public void savedata(ref Gamedata data)
    {
        data.Gamemin = this.min;
        data.Gamehour = this.hour;
    }
}
