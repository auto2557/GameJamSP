using UnityEngine;

public class TogglePopupUI : MonoBehaviour
{
    public GameObject popupUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // สลับสถานะของ Pop-up UI
            popupUI.SetActive(!popupUI.activeSelf);
        }
    }
}
