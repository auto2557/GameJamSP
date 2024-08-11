using UnityEngine;

public class AirPunch : MonoBehaviour
{
    public Vector2 velocity;
    public float Speed;
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.GetComponent<Humanoid>() && col.GetComponent<Humanoid>() != transform.GetChild(0).GetComponent<Humanoid>()){
            col.GetComponent<Humanoid>().TakeDmage(10);
            Destroy(gameObject);
        }
    }

    void Update()
    {   
        transform.Translate(velocity * Speed * Time.deltaTime);
    }
}
