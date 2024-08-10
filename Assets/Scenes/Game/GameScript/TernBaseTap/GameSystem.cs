using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static bool TernBasePhase;
    public static bool UpgradePhase;
    public static bool HellBulletPhase;
    public static int Part = 1;
    public static bool SkipUpgrade = false;
    //Scene//
    static public GameObject SceneTernbaseIdle;
    static public GameObject SceneUpgrade;

    
    //Phase TernBase//
    static public GameObject EnemyTarget;
    static public int StagePass = 1;
    static public int StagePassMax = 6;
    static public int Stage;
    static public float Level = 1f;
    public static GameObject PosEnemy_S;
    public GameObject PosEnemy;






    //Pop Up//
    //[HideInInspector]
    public static GameObject HitPopUp_S;
    public GameObject HitPopUp;







    //Zone Stats&Upgrade player//
    public static float AttackPowerIdle = 20f;
    public static float AttackSpeedIdle = 0.1f;
    public static float ExpPoint = 0f;

    //Idle ternbase
    public static float AttackPowerIdleLV = 1;
    public static float AttackPowerIdleLVCost = 5;
    public static float AttackSpeedIdleLV = 1;
    public static float AttackSpeedIdleLVCost = 50;
    //Other
    public static float EXPMultiplyLV = 1;
    public static float EXPMultiplyLVCost = 10;



    public void SetupPhase(string name, bool boolean){
        switch (name){
            case "TernBasePhase":
            TernBasePhase = boolean;
            UpgradePhase = false;
            HellBulletPhase = false;
            break;

            case "UpgradePhase":
            TernBasePhase = false;
            UpgradePhase = boolean;
            HellBulletPhase = false;
            break;

            case "HellBulletPhase":
            TernBasePhase = false;
            UpgradePhase = false;
            HellBulletPhase = boolean;
            break;
        }
    }
    public void SetupTernBase(){
        int number = Random.Range(1,3);
        Debug.Log(number);
        var EnemyTarget_IN = Resources.Load<GameObject>("Monster/Monster"+number);
        var inMOn = Instantiate(EnemyTarget_IN, PosEnemy.transform.position, Quaternion.identity);
        inMOn.GetComponent<Humanoid>().Health = inMOn.GetComponent<Humanoid>().Health * Level;
        inMOn.GetComponent<Humanoid>().MaxHealth = inMOn.GetComponent<Humanoid>().MaxHealth * Level;
        EnemyTarget = inMOn;
        Debug.Log(EnemyTarget);


        PosEnemy_S = PosEnemy;
        HitPopUp_S = HitPopUp;
    }
    void UPLEVELMON(){
        Level += .3f;
    }
    public void RespawnMon(){

        UPLEVELMON();

        int number = Random.Range(1,3);
        Debug.Log(number);
        var EnemyTarget_IN = Resources.Load<GameObject>("Monster/Monster"+number);
        var inMOn = Instantiate(EnemyTarget_IN, PosEnemy.transform.position, Quaternion.identity);
        inMOn.transform.parent = PosEnemy_S.transform.parent;
        inMOn.GetComponent<Humanoid>().Health = inMOn.GetComponent<Humanoid>().Health * Level;
        inMOn.GetComponent<Humanoid>().MaxHealth = inMOn.GetComponent<Humanoid>().MaxHealth * Level;
        EnemyTarget = inMOn;
        Debug.Log(EnemyTarget);
    }








    void Upgrade (){
        
    }
}
