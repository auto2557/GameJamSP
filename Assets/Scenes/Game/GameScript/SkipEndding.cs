using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipEndding : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("main");
        }
    }
}
