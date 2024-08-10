using UnityEngine;
using TMPro;

public class blink : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; 
    public float blinkSpeed = 1f; 
    public bool isBlinking = true; 

    void Update()
    {
        if (isBlinking)
        {
            float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f);
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;
        }
    }
}
