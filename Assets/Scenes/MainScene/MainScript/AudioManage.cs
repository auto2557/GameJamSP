using UnityEngine;

public class AudioManage : MonoBehaviour
{
    [SerializeField] AudioSource music1;
    [SerializeField] AudioSource SFX;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
