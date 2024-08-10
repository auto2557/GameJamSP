using TMPro;
using UnityEngine;

public class GUIStats : GameSystem
{
    [Space(10)]
    public TextMeshProUGUI LabelExp;

    void Update(){
        LabelExp.text = "EXP: " + ExpPoint.ToString();
    }
}
