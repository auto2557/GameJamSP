using System.Collections;
using UnityEngine;

public class Game : GameSystem
{
    bool db_attackAutoSp = false;
    bool db_attackSp = false;
    public static bool StopAttack = false;
    public Animator GFXPlayer;
    
    public GameObject SceneTernbaseIdle_I;
    public GameObject SceneUpgrade_I;
    public GameObject SceneHellBullet_I;

    void Start(){

        SceneTernbaseIdle = SceneTernbaseIdle_I;
        SceneUpgrade = SceneUpgrade_I;

        //SetupPhase("HellBulletPhase",true);
        SetupPhase("TernBasePhase",true);
        SetupTernBase();
    }
    void Update(){
        if (StagePass < 6){
            if (TernBasePhase == true){

                StartCoroutine(AutoAttack());

                CheckMonster();
                TapHit();
            }
        }else if (StagePass == 6){
                StartCoroutine(ChangeToHellMode());
        }
    }

    //---------------------------------------- Idle zone --------------------------------------//

    //Funtion//
    void CheckMonster(){
        if (EnemyTarget == null) {return;}
        if (EnemyTarget.GetComponent<Humanoid>().Health <= 0f){
            UpdateStage();

            if (Stage == 3 && SkipUpgrade == false && TernBasePhase == true){
                Debug.Log("Rest");
                Stage = 0;
                StagePass += 1;
                SetupPhase("UpgradePhase", true);
                SceneHellBullet_I.SetActive(false);
                SceneTernbaseIdle.SetActive(false);
                SceneUpgrade.SetActive(true);
            }else if (Stage == 3 && SkipUpgrade == true){
                Stage = 0;
                StagePass += 1;
            }

            Destroy(EnemyTarget);
            EnemyTarget = null;

            ExpPoint += (Random.Range(20,50))*Level;

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
        GFXPlayer.SetBool("ChangeStage", true);
        yield return new WaitForSeconds(3f);
        GFXPlayer.SetBool("ChangeStage", false);
        RespawnMon();
        StopAttack = false;
    }
    void UpdateStage(){
        Stage += 1;
    }
    IEnumerator Attack(){
    if (db_attackSp == false && StopAttack == false){
            db_attackSp = true;
            EnemyTarget.GetComponent<Humanoid>().TakeDmage(AttackPowerIdle * (AttackPowerIdle_lv));
            yield return new WaitForSeconds(0.1f);
            db_attackSp = false;
        }
    }
    IEnumerator AutoAttack(){
    if (db_attackAutoSp == false && StopAttack == false && Harpoon_Sup > 0){
            db_attackAutoSp = true;
            Debug.Log("AutoAttack");
            EnemyTarget.GetComponent<Humanoid>().TakeDmage((AttackPowerIdle * 2)* ((AttackPowerIdle_lv/2) + Harpoon_Sup));
            yield return new WaitForSeconds(2.5f);
            db_attackAutoSp = false;
        }
    }
    //--------------------------------------------------------------//

    IEnumerator ChangeToHellMode(){
        SetupPhase("HellBulletPhase", true);
        SceneUpgrade.SetActive(false);

        GFXPlayer.SetBool("ChangeStage", true);
        yield return new WaitForSeconds(3f);

        GFXPlayer.SetBool("ChangeStage", false);
        SceneTernbaseIdle.SetActive(false);

        yield return new WaitForSeconds(2f);
        SceneHellBullet_I.SetActive(true);
    }


    //-----------------------Hell Bullet----------------------------//
}
