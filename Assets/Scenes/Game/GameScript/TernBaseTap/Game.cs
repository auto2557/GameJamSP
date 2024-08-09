using System.Collections;
using UnityEngine;

public class Game : GameSystem
{
    bool db_attackAutoSp = false;
    bool db_attackSp = false;
    bool StopAttack = false;

    // Idle zone ///
    void Start(){
        SetupPhase("TernBasePhase",true);
        SetupTernBase();
    }
    void Update(){
        StartCoroutine(AutoAttack());

        CheckMonster();
        TapHit();
        
    }

    //FUntion//
    void CheckMonster(){
        if (EnemyTarget.GetComponent<Humanoid>().Health <= 0f){
            Destroy(EnemyTarget);
            EnemyTarget = null;

            ExpPoint += (Random.Range(50,100))*Level;

            StopAttack = true;
            StartCoroutine(Respawn());
            Debug.Log(ExpPoint);
        }
    }
    void TapHit (){
        if (Input.GetMouseButtonDown(0) && StopAttack == false){
            EnemyTarget.GetComponent<Humanoid>().TakeDmage(AttackPowerIdle);
        }
    }


    IEnumerator Respawn(){
        yield return new WaitForSeconds(3f);
        RespawnMon();
        StopAttack = false;
    }
    IEnumerator AutoAttack(){
        if (db_attackAutoSp == false && StopAttack == false){
            db_attackAutoSp = true;
            Debug.Log("Attack");
            EnemyTarget.GetComponent<Humanoid>().TakeDmage(AttackPowerIdle);
            yield return new WaitForSeconds(2.5f);
            db_attackAutoSp = false;
        }
    }
     IEnumerator Attack(){
        if (db_attackSp == false && StopAttack == false){
            db_attackSp = true;
            Debug.Log("Attack");
            EnemyTarget.GetComponent<Humanoid>().TakeDmage(AttackPowerIdle);
            yield return new WaitForSeconds(2.5f);
            db_attackSp = false;
        }
    }
    //--------------------------------------------------------------//
}
