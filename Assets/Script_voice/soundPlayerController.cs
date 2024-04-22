using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//音声に合わせて動く

public class soundPlayerController : MonoBehaviour
{
    //[SerializeField] private string m_DeviceName;
    private const int SAMPLE_RATE = 48000;
    private const float MOVING_AVE_TIME = 0.05f;

    //MOVING_AVE_TIMEに相当するサンプル数
    private const int MOVING_AVE_SAMPLE = (int)(SAMPLE_RATE * MOVING_AVE_TIME);
    
    private AudioSource m_MicAudioSource;

    [SerializeField] private GameObject m_Cube;
    [SerializeField, Range(10, 300)] private float m_AmpGain = 100;

    private void Awake() {
        m_MicAudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_MicAudioSource.isPlaying) return;
        
        float[] waveData = new float[MOVING_AVE_SAMPLE];
        m_MicAudioSource.GetOutputData(waveData, 0);

        //バッファ内の平均振幅を取得（絶対値を平均する）
        float audioLevel = waveData.Average(Mathf.Abs);
        m_Cube.transform.localScale = new Vector3(1+ m_AmpGain * audioLevel, 1 + m_AmpGain * audioLevel, 1);
    }

    private void MicStart(string device) {
        if (device.Equals("")) return;
        
        m_MicAudioSource.clip = Microphone.Start(device, true, 1, SAMPLE_RATE);

        //マイクデバイスの準備ができるまで待つ
        while (!(Microphone.GetPosition("") > 0)) { }
        
        m_MicAudioSource.Play();
    }
}
