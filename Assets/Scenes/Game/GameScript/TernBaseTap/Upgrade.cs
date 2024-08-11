using TMPro;
using UnityEngine;

public class Upgrade : GameSystem
{
    [Space(20)]
    public TextMeshProUGUI AttackPowerIdle_lv_UI;
    public TextMeshProUGUI AttackPowerIdle_lv_CostUI;
    public float AttackPowerIdle_lv_Cost = 100f;
    public void Upgrade_AttackPowerIdle_lv()
    {
        if (ExpPoint >= AttackPowerIdle_lv_Cost * AttackPowerIdle_lv){
            ExpPoint -= AttackPowerIdle_lv_Cost * AttackPowerIdle_lv;
            AttackPowerIdle_lv += 1;
            AttackPowerIdle_lv_UI.text = "LV." + AttackPowerIdle_lv.ToString();
            AttackPowerIdle_lv_CostUI.text = (AttackPowerIdle_lv_Cost * AttackPowerIdle_lv).ToString();
        }
    }
    
    [Space(20)]
    public TextMeshProUGUI Harpoon_Sup_UI;
    public TextMeshProUGUI Harpoon_Sup_CostUI;
    public float Harpoon_Sup_Cost = 200f;
    public void Upgrade_Harpoon_Supv()
    {
        if (ExpPoint >= Harpoon_Sup_Cost * Harpoon_Sup){
            ExpPoint -= Harpoon_Sup_Cost * Harpoon_Sup;
            Harpoon_Sup += 1;
            Harpoon_Sup_UI.text = "LV." + Harpoon_Sup.ToString();
            Harpoon_Sup_CostUI.text = (Harpoon_Sup_Cost * Harpoon_Sup).ToString();
        }
    }

    [Space(20)]
    public TextMeshProUGUI PunchAir_CostUI;
    public float PunchAir_Cost = 200f;
    public void PunchAir_Upgrade()
    {
        if (ExpPoint >= PunchAir_Cost){
            ExpPoint -= PunchAir_Cost;
            PunchAir = true;
            PunchAir_CostUI.text = "Sale Out";
        }
    }

    [Space(20)]
    public TextMeshProUGUI MovementSpeedUI;
    public TextMeshProUGUI MovementSpeed_Cost_UI;
    public float MovementSpeed_Cost = 200f;
    public void MovementSpeed_Upgrade()
    {
        if (ExpPoint >= MovementSpeed_Cost * MovementSpeed){
            ExpPoint -= MovementSpeed_Cost * MovementSpeed;
            MovementSpeed += 1;
            Harpoon_Sup_UI.text = "LV." + Harpoon_Sup.ToString();
            Harpoon_Sup_CostUI.text = (Harpoon_Sup_Cost * Harpoon_Sup).ToString();
        }
    }





    void Start(){
        AttackPowerIdle_lv_UI.text = "LV." + AttackPowerIdle_lv.ToString();
        AttackPowerIdle_lv_CostUI.text = (AttackPowerIdle_lv_Cost * Level).ToString();

        Harpoon_Sup_UI.text = "LV." + Harpoon_Sup.ToString();
        Harpoon_Sup_CostUI.text = (Harpoon_Sup_Cost * Level).ToString();

        PunchAir_CostUI.text = PunchAir_Cost.ToString();
    }
}
