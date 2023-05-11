using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[System.Serializable]
public class Gamedata
{
    public int Cardsummin, Cardsumhour, Gamemin, Gamehour;
    public float stamina;
    public Vector3 playerposition,P2postition;
    public quaternion playerrotation,P2rotation;
    public bool gamestarted; 
    public Gamedata() {
    this.gamestarted = false;//�}�|�Q��
    this.Cardsummin = 0;
    this.Cardsumhour = 0;
    this.Gamemin = 0;
    this.Gamehour = 0;
    this.stamina = 10;
    playerposition = new Vector3(16.51f,0.07f,-1.407f);
    playerrotation = new quaternion(0f, -180f, 0f,0f);
    P2postition = new Vector3(18.2f, 1.2f, -16.05f);
    P2rotation = new quaternion(0f, 85.274f, 0f, 0f);
    
    }
}
