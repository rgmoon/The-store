using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer1 : MonoBehaviour //調整時間僅限min 跟 hour, sec不要調整 不然玩家看不到
{
    public NewBehaviourScript main;
    public int sec,min,hour,tsec,orgtsec,orghour,orgmin,orgsec;
    public void timerstart()
    {
        orghour = hour;
        orgmin = min;
        orgsec = sec;
        orgtsec = tsec;
        if (sec == 60)
        {
            min = 1;
            sec = 0;
        }
        else if (sec > 60)
        {
            min = sec / 60 + orgmin;
            sec -= (min - orgmin) * 60;
        }
        if (min == 60)
        {
            hour = 1;
            min = 0;
        }
        else if (min > 60)
        {
            hour = min / 60 + orghour;
            min -= (hour - orghour) * 60;
        }
        InvokeRepeating("timer", 1, 1);

    }
    public void cancelinvoke() {
        CancelInvoke("timerstart");
        CancelInvoke("timer");
        main.cardtick = false;
    }
   public void timer() {
        tsec = hour * 60 * 60 + min * 60 + sec;
        if (hour != 0 && tsec == orgtsec)
        {
            sec = 60;
            sec--;
        }
        else
        {
            sec--;
        }
        tsec--;
        if (tsec > 0)
        {

            if (min <= 0 && hour > 0)
            {
                hour--;
                min = 59;
            }
            else if (sec < 0 && min > 0)
            {
                min--;
                sec = 59;
            }
            else if (sec < 0 && min == 0 && hour == 0)
            {
             sec = 0;
            }
        }
        else
        {
         CancelInvoke("timer");
         main.warning1 = true;
         if (main.warning1 == true) //do waht u want here
         {
          GameObject.FindGameObjectWithTag("warning1").GetComponent<Animator>().SetBool("warning1", true);
          GameObject.FindGameObjectWithTag("warning1").GetComponent<AudioSource>().Play();
          Debug.Log("start flash");
         }
        }
    }

}
