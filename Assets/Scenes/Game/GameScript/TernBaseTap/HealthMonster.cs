using UnityEngine;
using UnityEngine.UI;

public class HealthMonster : MonoBehaviour
{
    public Slider HealthSlider;

    void Update(){
        HealthSlider.value = gameObject.GetComponent<Humanoid>().Health/gameObject.GetComponent<Humanoid>().MaxHealth;
    }
}
