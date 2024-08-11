using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;

    public GameObject PrefebAirPunch;

    public Rigidbody2D rb;
    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Speed * Time.deltaTime;

        BulletAirPunch();
    }

    void BulletAirPunch (){
        if (GameSystem.PunchAir == true && db == false){
            StartCoroutine(Bullet());
        }
    }
    
    bool db = false;
    IEnumerator Bullet (){
        db = true;
        GameObject obj = Instantiate(PrefebAirPunch, transform.position, Quaternion.identity);
        obj.transform.parent = transform.parent;
        yield return new WaitForSeconds(1f);
        db = false;
    }
}
