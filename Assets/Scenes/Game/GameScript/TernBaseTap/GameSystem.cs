using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static bool TernBasePhase;
    public static bool UpgradePhase;
    public static bool HellBulletPhase;
    public static int Part = 1;
    public static bool SkipUpgrade = false;



    public static GameObject lastBossTarget_S;


    //Scene//
    static public GameObject SceneTernbaseIdle;
    static public GameObject SceneUpgrade;

    
    //Phase TernBase//
    static public GameObject EnemyTarget;
    static public int StagePass = 11;
    static public int StagePassMax = 12;
    static public int Stage;
    static public float Level = 1f;
    public static GameObject PosEnemy_S;
    public GameObject PosEnemy;
    






    //Pop Up//
    //[HideInInspector]
    public static GameObject HitPopUp_S;
    public GameObject HitPopUp;







    //Zone Stats&Upgrade player//
    public static float AttackPowerIdle = 30f;
    public static float AttackSpeedIdle = 0.1f;
    public static float ExpPoint = 10000f;

    public static float HarpoonPower = 5;



    //Idle ternbase
    public static float AttackPowerIdle_lv = 1f;
    public static float Harpoon_Sup = 0f;

    //HellMode ternbase
    public static bool PunchAir = false;
    public static float MovementSpeed = 1f;
    public static float Harpoon_DMG = 1f;

    //Other
    public static float ExpPoint_Multiple = 1f;



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
