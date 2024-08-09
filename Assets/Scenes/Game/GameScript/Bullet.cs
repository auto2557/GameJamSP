using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    public float Speed;
    public float Rotation;
    public float lifeTime;
    float timer;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Rotation);
    }

    void Update()
    {
        transform.Translate(velocity * Speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0) gameObject.SetActive(false);
    }
    public void ResetTimer()
    {
        timer = lifeTime;
    }
}
