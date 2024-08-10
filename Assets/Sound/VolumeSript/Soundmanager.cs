using UnityEngine;
using UnityEngine.UI;
public class Soundmanager : MonoBehaviour
{
    public Slider musicSlider, SFXslider;

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(SFXslider.value);
    }



}
