using System.Collections;
using UnityEngine;

public class Game : GameSystem
{
    bool db_attackAutoSp = false;
    bool db_attackSp = false;
    public static bool StopAttack = false;
    public Animator GFXPlayer;

    public AudioManager AudioManager;
    
    public GameObject SceneTernbaseIdle_I;
    public GameObject SceneUpgrade_I;
    public GameObject SceneHellBullet_I;




       //HellBullet//
    public GameObject PosSKill1;
    public GameObject PosSKill2;
    public GameObject PosSKill3;
    public GameObject SkillOrb;

    public GameObject BossAram;
    public GameObject ChangeFade;

    public GameObject lastBossTarget;


    bool db_RandomSkill = false;

    void Start(){

        SceneTernbaseIdle = SceneTernbaseIdle_I;
        SceneUpgrade = SceneUpgrade_I;

        lastBossTarget_S = lastBossTarget;

        //SetupPhase("HellBulletPhase",true);
        SetupPhase("TernBasePhase",true);
        SetupTernBase();
    }
    void Update(){
        if (StagePass < StagePassMax){
            if (TernBasePhase == true){

                StartCoroutine(AutoAttack());

                CheckMonster();
                TapHit();
            }
        }else if (StagePass == StagePassMax){
                StartCoroutine(ChangeToHellMode());
        }

        if (HellBulletPhase == true){
            SpawnSKill();
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
        ChangeFade.SetActive(true);
        GFXPlayer.SetBool("ChangeStage", true);
        AudioManager.PlaySFX("Swim");
        yield return new WaitForSeconds(3f);
        GFXPlayer.SetBool("ChangeStage", false);
        ChangeFade.SetActive(false);
        RespawnMon();
        StopAttack = false;
    }
    void UpdateStage(){
        Stage += 1;
    }
    IEnumerator Attack(){
    if (db_attackSp == false && StopAttack == false){
            AudioManager.PlaySFX("Slash");
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
        BossAram.SetActive(true);

        GFXPlayer.SetBool("ChangeStage", true);
        yield return new WaitForSeconds(3f);
        

        GFXPlayer.SetBool("ChangeStage", false);
        SceneTernbaseIdle.SetActive(false);

        yield return new WaitForSeconds(2f);
        BossAram.SetActive(false);
        SceneHellBullet_I.SetActive(true);
    }

    void SpawnSKill(){
        if (db_RandomSkill == false){
            StartCoroutine(SkillRandom());
        }
    }
    IEnumerator SkillRandom(){
        db_RandomSkill = true;
        var numran = Random.Range(1, 3);
        if (numran == 1){
            if (PosSKill1.transform.childCount == 0){
                var obj = Instantiate(SkillOrb, PosSKill1.transform.position, Quaternion.identity);
                obj.transform.parent = PosSKill1.transform;
            }
        }else if (numran == 2){
            if (PosSKill2.transform.childCount == 0){
                var obj = Instantiate(SkillOrb, PosSKill2.transform.position, Quaternion.identity);
                obj.transform.parent = PosSKill2.transform;
            }
        }else if (numran == 3){
            if (PosSKill3.transform.childCount == 0){
                var obj = Instantiate(SkillOrb, PosSKill3.transform.position, Quaternion.identity);
                obj.transform.parent = PosSKill3.transform;
            }
        }
        yield return new WaitForSeconds(5f);
        db_RandomSkill = false;
    }


    //-----------------------Hell Bullet----------------------------//
}
