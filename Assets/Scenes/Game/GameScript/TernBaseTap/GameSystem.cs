using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static bool TernBasePhase;
    public static bool UpgradePhase;
    public static bool HellBulletPhase;
    
    //Phase TernBase//
    static public GameObject EnemyTarget;
    static public int Stage;
    static public float Level = 1f;
    public static GameObject PosEnemy_S;
    public GameObject PosEnemy;






    //Pop Up//
    //[HideInInspector]
    public static GameObject HitPopUp_S;
    public GameObject HitPopUp;







    //Zone stats player//
    public static float AttackPowerIdle = 5f;
    public static float AttackSpeedIdle = 0.1f;
    public static float ExpPoint = 0f;



    public void SetupPhase(string name, bool boolean){
        switch (name){
            case "TernBasePhase":
            TernBasePhase = boolean;
            break;

            case "UpgradePhase":
            UpgradePhase = boolean;
            break;

            case "HellBulletPhase":
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
        Level += .5f;
    }
    public void RespawnMon(){

        UPLEVELMON();

        int number = Random.Range(1,3);
        Debug.Log(number);
        var EnemyTarget_IN = Resources.Load<GameObject>("Monster/Monster"+number);
        var inMOn = Instantiate(EnemyTarget_IN, PosEnemy.transform.position, Quaternion.identity);
        inMOn.GetComponent<Humanoid>().Health = inMOn.GetComponent<Humanoid>().Health * Level;
        inMOn.GetComponent<Humanoid>().MaxHealth = inMOn.GetComponent<Humanoid>().MaxHealth * Level;
        EnemyTarget = inMOn;
        Debug.Log(EnemyTarget);
    }
}
