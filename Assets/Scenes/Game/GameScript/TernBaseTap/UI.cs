using TMPro;
using UnityEngine;

public class GUIStats : GameSystem
{
    [Space(10)]
    public TextMeshProUGUI LabelExp;
    public TextMeshProUGUI LabelStage;

    [Space(10)]
    public TextMeshProUGUI TextINButtom;

    void Update(){
        if (LabelExp){
            LabelExp.text = "EXP: " + ExpPoint.ToString();
        }
        if (LabelStage){
            LabelStage.text = "Stage: " + StagePass.ToString() + "/" + StagePassMax.ToString();
        }
    }

    public void Ready(){
        Game.StopAttack = false;
        Debug.Log("Ready");

        SceneTernbaseIdle.SetActive(true);
        SceneUpgrade.SetActive(false);

        SetupPhase("TernBasePhase", true);
        SetupTernBase();
    }


    bool db = false;
    public void Enabled (){
        if (db == false){
            db =true;
            SkipUpgrade = true;
            TextINButtom.color = Color.green;
            TextINButtom.text = "Enabled";
        }else if (db == true){
            db = false;
            SkipUpgrade = false;
            TextINButtom.text = "Disabled";
            TextINButtom.color = Color.red;
        }
    }

}
