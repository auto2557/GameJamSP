using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public string sceneName;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Change);
    }

    void Change()
    {
        SceneManager.LoadScene(sceneName);
    }
}
