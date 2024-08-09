using System.Collections;
using UnityEngine;

public class Game : GameSystem
{
    bool db_attackSp = false;

    
    void Start(){
        SetupPhase("TernBasePhase",true);
        SetupTernBase();
    }
    void Update(){
        StartCoroutine(AutoAttack());
    }

    IEnumerator AutoAttack(){
        if (db_attackSp == false){
            db_attackSp = true;
            Debug.Log("Attack");
            EnemyTarget.GetComponent<Humanoid>().TakeDmage(2.5f);
            yield return new WaitForSeconds(2.5f);
            db_attackSp = false;
        }
    }
}
