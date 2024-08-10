using UnityEngine;

public class OpenSetting : MonoBehaviour
{
    public GameObject objectToToggle;
    public void Toggle()
    {
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}

