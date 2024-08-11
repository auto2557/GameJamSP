using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class CreditsScroll : MonoBehaviour
{
    public float scrollSpeed = 50f; 
    public float stopPositionY = 1000f; 
    public string nextSceneName; 
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        
        if (rectTransform.anchoredPosition.y < stopPositionY)
        {
            
            rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        }
        else
        {
            
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
