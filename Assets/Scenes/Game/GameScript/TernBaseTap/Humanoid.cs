using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Humanoid : GameSystem
{
    public float Health = 100f;
    public float MaxHealth = 100f;
    

    void Start(){
    }

    public void TakeDmage(float Dmg){
        Health -= Dmg;
        var HitPop = Instantiate(HitPopUp_S, PosEnemy_S.transform.position, Quaternion.identity);
        HitPop.GetComponent<GetRefference>().refference.GetComponent<TextMeshProUGUI>().text = AttackPowerIdle.ToString();
        Destroy(HitPop,.5f);
    }

}
