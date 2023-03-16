using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class STDtimer : MonoBehaviour, IDatapersistence
{
    public time time;
    public Timer1 timer1;
    [SerializeField]
    private Sprite[] digits;
    [SerializeField]
    private Image[] chr;
    int summin, sumhour,orgsumhour;
    int stdlastmin, stdlastmin2, stdlasthour, stdlasthour2;
    public void updatestdtime() {
        summin = timer1.min + time.min; //59 + 59 min 
        sumhour = timer1.hour + time.hour;
        orgsumhour = sumhour;
        if (summin >= 60)
        {
            sumhour = summin / 60 + orgsumhour;
            summin = summin % 60;
        }
        if (sumhour >= 24)
        {
            sumhour = sumhour % 24;
        }
        Debug.Log(summin);
    }
    public void Update()
    {
        stdlastmin = summin % 10;
        stdlastmin2 = summin / 10;
        stdlasthour = sumhour % 10;
        stdlasthour2 = sumhour / 10;



        chr[3].sprite = digits[stdlastmin];
        chr[2].sprite = digits[stdlastmin2];
        chr[1].sprite = digits[stdlasthour];
        chr[0].sprite = digits[stdlasthour2];
    }
    public void loaddata(Gamedata data) { 
        this.summin = data.Cardsummin;
        this.sumhour = data.Cardsumhour;
    }
    public void savedata(ref Gamedata data) {
        data.Cardsummin = this.summin;
        data.Cardsumhour = this.sumhour;
    }
}
