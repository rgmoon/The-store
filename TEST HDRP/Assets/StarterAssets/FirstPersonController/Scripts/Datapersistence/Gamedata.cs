using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gamedata
{
    public int Cardsummin, Cardsumhour, Gamemin, Gamehour;
    public Vector3 playerposition;
    public bool gamestarted; 
    public Gamedata() {
    this.gamestarted = false;//�}�|�Q��
    this.Cardsummin = 0;
    this.Cardsumhour = 0;
    this.Gamemin = 0;
    this.Gamehour = 0;
    playerposition = Vector3.zero;
    }
}