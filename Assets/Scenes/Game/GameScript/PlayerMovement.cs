using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;

    public Rigidbody2D rb;
    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
