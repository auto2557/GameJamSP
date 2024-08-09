using UnityEngine;
using TMPro;
using System;

public class Humanoid : GameSystem
{
    public float Health = 100f;
    

    void Start(){
    }

    public void TakeDmage(float Dmg){
        Health -= Dmg;
        var HitPop = Instantiate(HitPopUp_S, PosEnemy_S.transform.position, Quaternion.identity);
        
        Destroy(HitPop,.3f);
    }

}
