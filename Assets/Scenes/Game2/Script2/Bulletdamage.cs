using UnityEngine;

public class Bulletdamage : MonoBehaviour
{
    public float damage = 1f; // ปริมาณดาเมจที่กระสุนจะทำ


    void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่ากระสุนชนกับผู้เล่น
        if (collision.CompareTag("Player"))
        {
            // เข้าถึงสคริปต์ของผู้เล่นเพื่อทำดาเมจ
            HPplayer HPplayer = collision.GetComponent<HPplayer>();
            if (HPplayer != null)
            {
                HPplayer.TakeDamage(damage);
                Debug.Log("HP = "+HPplayer.health);
            }

            // ทำลายกระสุนหลังจากชน
            Destroy(gameObject);
        }
    }
}
