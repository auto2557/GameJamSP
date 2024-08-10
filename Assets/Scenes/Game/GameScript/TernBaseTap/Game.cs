using System.Collections;
using UnityEngine;

public class Game : GameSystem
{
    bool db_attackAutoSp = false;
    bool db_attackSp = false;
    bool StopAttack = false;

    public GameObject SceneTernbaseIdle;
    public GameObject SceneUpgrade;

    void Start(){
        SetupPhase("TernBasePhase",true);
        SetupTernBase();
    }
    void Update(){
        if (TernBasePhase == true){

            StartCoroutine(AutoAttack());

            CheckMonster();
            TapHit();
        }
    }

    //---------------------------------------- Idle zone --------------------------------------//

    //Funtion//
    void CheckMonster(){
        if (EnemyTarget.GetComponent<Humanoid>().Health <= 0f){
            UpdateStage();

            if (Stage == 3){
                Debug.Log("Rest");
                Stage = 0;
                StagePass += 1;
                SetupPhase("UpgradePhase", true);
                SceneTernbaseIdle.SetActive(false);
                SceneUpgrade.SetActive(true);
            }

            Destroy(EnemyTarget);
            EnemyTarget = null;

            ExpPoint += (Random.Range(50,100))*Level;

            StopAttack = true;
            if (TernBasePhase == true){
                StartCoroutine(Respawn());
                Debug.Log(ExpPoint);
            }
        }
    }
    void TapHit (){
        if (Input.GetMouseButtonDown(0) && StopAttack == false){
            StartCoroutine(Attack());
        }
    }


    IEnumerator Respawn(){
        yield return new WaitForSeconds(3f);
        RespawnMon();
        StopAttack = false;
    }
    void UpdateStage(){
        Stage += 1;
    }
    IEnumerator Attack(){
    if (db_attackSp == false && StopAttack == false){
            db_attackSp = true;
            EnemyTarget.GetComponent<Humanoid>().TakeDmage(AttackPowerIdle);
            yield return new WaitForSeconds(0.1f);
            db_attackSp = false;
        }
    }
    IEnumerator AutoAttack(){
    if (db_attackAutoSp == false && StopAttack == false){
            db_attackAutoSp = true;
            Debug.Log("AutoAttack");
            EnemyTarget.GetComponent<Humanoid>().TakeDmage(AttackPowerIdle * 2);
            yield return new WaitForSeconds(2.5f);
            db_attackAutoSp = false;
        }
    }
    //--------------------------------------------------------------//
}
