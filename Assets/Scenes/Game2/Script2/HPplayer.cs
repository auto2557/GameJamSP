using UnityEngine;
using UnityEngine.SceneManagement; // ใช้งาน SceneManager

public class HPplayer : MonoBehaviour
{
    public float health = 30f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // จัดการกับการตายของผู้เล่น
        Debug.Log("Player has died!");

        // โหลดซีนใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // หรือสามารถระบุชื่อซีนเป็น string ได้ เช่น
        // SceneManager.LoadScene("ชื่อซีนที่ต้องการโหลด");
    }
}
