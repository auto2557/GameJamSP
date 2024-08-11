using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBullet : MonoBehaviour
{
    public float lifetime = 5f; // เวลาที่กระสุนจะอยู่ก่อนจะถูกทำลาย

    void Start()
    {
        // ทำลายกระสุนหลังจากเวลาที่กำหนดไว้
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ถ้ากระสุนชนกับวัตถุใดๆ ให้ทำลายกระสุน
        Destroy(gameObject);

        // เพิ่มโค้ดเพื่อจัดการเมื่อกระสุนชนกับวัตถุต่างๆ ได้ที่นี่
        // เช่น ลดพลังชีวิตของศัตรูเมื่อโดนกระสุน
    }
}
