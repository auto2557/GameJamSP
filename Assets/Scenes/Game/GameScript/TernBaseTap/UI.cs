using TMPro;
using UnityEngine;

public class GUIStats : Game
{
    [Space(10)]
    public TextMeshProUGUI LabelExp;
    public TextMeshProUGUI LabelStage;

    void Update(){
        LabelExp.text = "EXP: " + ExpPoint.ToString();
        LabelStage.text = "Stage: " + StagePass.ToString() + "/" + StagePassMax.ToString();
    }

    public void Ready(){
        
    }
}
