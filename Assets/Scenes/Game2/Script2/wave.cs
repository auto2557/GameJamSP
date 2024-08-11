using UnityEngine;

public class wave : MonoBehaviour
{
    public float speed = 5f; // ความเร็วของกระสุน
    public float frequency = 2f; // ความถี่ของการเคลื่อนไหว
    public float magnitude = 0.5f; // ขนาดของการเคลื่อนไหว

    private Vector3 axis; // แกนการเคลื่อนไหว
    private Vector3 pos; // ตำแหน่งเริ่มต้นของกระสุน

    void Start()
    {
        pos = transform.position; // ตั้งค่าตำแหน่งเริ่มต้นของกระสุน
        axis = transform.up; // แกนการเคลื่อนไหวตามแกน y
    }

    void Update()
    {
        pos += transform.right * speed * Time.deltaTime; // เคลื่อนที่ไปข้างหน้าตามแกน x
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude; // เพิ่มการเคลื่อนไหวแบบคลื่น
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // ทำลายกระสุนเมื่อออกจากหน้าจอ
    }
}
