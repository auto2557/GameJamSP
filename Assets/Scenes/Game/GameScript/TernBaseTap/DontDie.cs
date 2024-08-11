using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDie : MonoBehaviour
{
    public String Scene;
    void Update()
    {
        if(gameObject.GetComponent<Humanoid>().Health <= 0) {
            SceneManager.LoadScene(Scene);
        }
    }
}
