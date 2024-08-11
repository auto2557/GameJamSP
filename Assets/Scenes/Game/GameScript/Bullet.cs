using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    public float Speed;
    public float Rotation;
    public float lifeTime;
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.GetComponent<Humanoid>() && col.GetComponent<Humanoid>() != transform.GetComponent<Humanoid>()){
            col.GetComponent<Humanoid>().Health -= 10;
            Destroy(gameObject);
        }
    }

    void Update()
    {   
        
        transform.Translate(velocity * Speed * Time.deltaTime);
    }

}
