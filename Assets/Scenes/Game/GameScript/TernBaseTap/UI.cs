using TMPro;
using UnityEngine;

public class GUIStats : GameSystem
{
    [Space(10)]
    public TextMeshProUGUI LabelExp;
    public TextMeshProUGUI LabelStage;

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
}
