using System.Collections;
using UnityEngine;

public class AirPunch : MonoBehaviour
{
    public Vector2 velocity;
    public float Speed;

    bool db = false;

    void Update()
    {   
        transform.Translate(velocity * Speed * Time.deltaTime);
        if (db == false){
            StartCoroutine(Damage()); 
        }
    }
    
    IEnumerator Damage(){
        db = true;
        yield return new WaitForSeconds(2f);
        GameSystem.lastBossTarget_S.GetComponent<Humanoid>().TakeDmage(10);
        Destroy(gameObject);
        db = false;
    }
}
