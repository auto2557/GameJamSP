using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSpeed : MonoBehaviour
{
    public float typingSpeed = 0.05f; 
    public TextMeshProUGUI textMeshPro; 
    public string nextSceneName; 
    public float waitTimeBeforeSwitching = 5.0f; 

    private string fullText; 
    private string currentText = "";
    private void Start()
    {
        fullText = textMeshPro.text; 
        textMeshPro.text = ""; 
        StartCoroutine(ShowText());
    }

    private System.Collections.IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

       
        yield return new WaitForSeconds(waitTimeBeforeSwitching);

       
        SceneManager.LoadScene(nextSceneName);
    }
}
