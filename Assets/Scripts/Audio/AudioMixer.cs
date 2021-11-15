using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    [SerializeField] Slider sliderBGM;
    [SerializeField] Slider sliderSE;

    // Start is called before the first frame update
    void Start()
    {
        sliderBGM.value = AudioPlayer.GetVolume_BGM();
        sliderSE.value = AudioPlayer.GetVolume_SE();
    }

    // Update is called once per frame
    void Update()
    {
        AudioPlayer.SetVolume_BGM(sliderBGM.value);
        AudioPlayer.SetVolume_SE(sliderSE.value);
    }
}