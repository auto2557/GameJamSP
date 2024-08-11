using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChangeSceneVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        // ตรวจสอบเมื่อวิดีโอเล่นจบ
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // เปลี่ยน Scene เมื่อวิดีโอจบ
        SceneManager.LoadScene(nextSceneName);
    }
}
