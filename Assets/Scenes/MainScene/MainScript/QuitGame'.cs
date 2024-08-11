using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
