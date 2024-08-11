using UnityEngine;

public class SkillOrb : GameSystem
{
    void OnTriggerEnter2D(Collider2D col){
        if (col.GetComponent<Humanoid>()){
            lastBossTarget_S.GetComponent<Humanoid>().TakeDmage(HarpoonPower * Harpoon_DMG);
            Destroy(gameObject);
        }
    }
}
