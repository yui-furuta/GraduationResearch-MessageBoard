using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

//録音、オブジェクトの設置
//名前決定はここから
//サウンドメーターの処理もここから

public class MyRecording : MonoBehaviour
{
    private AudioClip myclip;//録音中のオーディオクリップ（使わないかも）
    private AudioSource myAudioSouece;//私のオーディオソース
    private AudioSource audioSource;//プレハブのオーディオソース
    public GameObject prefab;
    public GameObject canvas;

    string micName = null; //マイクデバイスの名前を確認

    [SerializeField]
    string myMicName = null; //設定したマイクデバイスの名前

    const int samplingFrequency = 44100; //サンプリング周波数
    const int maxTime_s = 11; //最大録音時間[s]
    private float maxTime_f = 10f;//最大録音時間[s]
    public float recordTime = 0;

    public int count = 0;//オブジェクトの番号

    private Vector3 mouse ;//マウスの位置
    private Vector3 point ;//決定した位置
    
    public GameObject startButtonObject;
    public GameObject RecordPanel;
    public GameObject countObject;
    public GameObject startObject;
    public GameObject frameObject1;
    public GameObject frameObject2;
    public GameObject frameObject3;
    public GameObject frameObject4;
    public GameObject fadeImageObject;
    public GameObject Taptext;

    public GameObject clickActionObject;
    clickActionScript d2;


    //メーター用変数
    private const int SAMPLE_RATE = 48000;
    private const float MOVING_AVE_TIME = 0.05f;

    //MOVING_AVE_TIMEに相当するサンプル数
    private const int MOVING_AVE_SAMPLE = (int)(SAMPLE_RATE * MOVING_AVE_TIME);

    [SerializeField, Range(10, 300)] private float m_AmpGain = 100;

    //このdBでlevelMeter表示の下限に到達する
    [SerializeField]
    private float dB_Min= -80.0f;
 
    //このdBでlevelMeter表示の上限に到達する
    [SerializeField]
    private float dB_Max = -0.0f;

    //更新する対象のlevelMeter(uGUI Image)
    public Image levelMeterImage;

    //更新する時間
    public Image timeMeterImage;

    //更新する時間まる
    public GameObject timeMaru;
    float rateMaru;
    // 位置
    Vector3 preposition;            // 移動前位置
    Vector3 postposition;           // 移動後位置


    private int tapState = 0 ;//タップするときのステージ関数
    private Color blackColor;
    private Color whiteColor;


    private int frameState = 0;//フレームの色ステージ関すう

    //初めに
    void Start()
    {
        //マイクデバイスを探す
        foreach (string device in Microphone.devices)
        {
           Debug.Log("Name: " + device);
           micName = device;
        }

        //micName = "Plugable USB Audio Device";

        //soundPlayerObj = new GameObject("SoundPlayer");

        myAudioSouece = GetComponent<AudioSource>();

        blackColor = new Color(0.3f,0.3f,0.3f,1.0f);
        whiteColor = new Color(1.0f,1.0f,1.0f,1.0f);

        d2 = clickActionObject.GetComponent<clickActionScript>();

        preposition = new Vector3(-630+1180,584,100);
        postposition = new Vector3(630+1180,584,100);

    }



//マイフレームごと
    void Update(){

        //音声入力メーター
        //if (!myAudioSouece.isPlaying) return;
        
        if (myAudioSouece.isPlaying)
        {
            float[] waveData = new float[1024];
            myAudioSouece.GetOutputData(waveData, 1);

            //バッファ内の平均振幅を取得（絶対値を平均する）
            float audioLevel = waveData.Average(Mathf.Abs);

            //振幅をdB（デシベル）に変換
            float dB = 20.0f * Mathf.Log10(audioLevel);

            //dB値からlevelMeterImage用のfillAountの値に変換
            float fillAmountValue = dB_ToFillAmountValue(dB);
    
            //fillAmount値更新
            levelMeterImage.fillAmount = fillAmountValue * 1.5f;

            //レコード時間を記録
            recordTime += Time.deltaTime;

            //Debug.Log(recordTime);

            //
            timeMeterImage.fillAmount = recordTime * 0.1f;
            rateMaru = Mathf.Clamp01(recordTime/maxTime_f);

            // 移動・回転
            timeMaru.transform.position =  Vector3.Lerp(preposition, postposition, rateMaru);

            if(recordTime>=maxTime_f){
                EndButton();
            }
        }

        //花の置く位置を悩み中
        if(tapState == 1){
            
            if(frameState == 0){
                Black();
                Taptext.SetActive(true);
                fadeImageObject.SetActive (true);
            }

            if(Input.GetMouseButtonDown(0)){
                //startButtonObject.SetActive (true);
                d2.panelClose();
                Taptext.SetActive(false);
                fadeImageObject.SetActive (false);
                White();
                tapState = 0;
                frameState =0;
            }
        }

        

    }





//スタートボタン押す処理

    public void StartButton()
    {
        Invoke("DelayMethod", 3.0f);

        recordTime = 0;

        //startButtonObject.SetActive (false);
        RecordPanel.SetActive (true);
    }

    void DelayMethod(){
        Debug.Log("recording start");
        ////myclipに録音スタート
        // deviceName: "null" -> デフォルトのマイクを指定
        myAudioSouece.clip = Microphone.Start(deviceName: myMicName, loop: false, lengthSec: maxTime_s, frequency: samplingFrequency);

        //マイクデバイスの準備ができるまで待つ
        while (!(Microphone.GetPosition("") > 0)) { }
        //AudioSouceからの出力を開始
        myAudioSouece.Play();
    }







//エンドボタン押す処理
    public void EndButton()
    {
        if (Microphone.IsRecording(deviceName: myMicName) == true)
        {
            Debug.Log("recording stoped");
            Microphone.End(deviceName: myMicName);

            count ++;

            //花を生成
            //GameObject soundPlayerObj = new GameObject("SoundPlayer");
            GameObject soundPlayerObj = Instantiate(prefab,new Vector3(0, 0, 0),Quaternion.identity);
            soundPlayerObj.transform.parent = canvas.transform;
            // transformを取得
            Transform myTransform = soundPlayerObj.transform;

            // ローカル座標を基準に、座標を取得
            Vector3 Pos = myTransform.localPosition;
            Pos.x = 0;
            Pos.y = -1000;
            Pos.z = 0;
            myTransform.localPosition = Pos;
            
            //音オブジェクトの設定
            //オブジェクトの名前設定
            soundPlayerObj.transform.localScale = new Vector3(1,1,1);
            soundPlayerObj.name = "SoundPlayer" + count.ToString();
            audioSource = soundPlayerObj.GetComponent<AudioSource>();
            audioSource.clip = myAudioSouece.clip;

            //startButtonObject.SetActive (true);

            startObject.SetActive (false);
            countObject.SetActive(true);
            RecordPanel.SetActive (false);

            tapState = 1;
            
        }
        else
        {
            Debug.Log("not recording");
        }
    }



//花を押した時
    public void PlayButton()
    {
        Debug.Log("play");
        //audioSource.clip = myclip;
        audioSource.Play();
        //myclip.Play();
    }




//音声メーターの関数
    float dB_ToFillAmountValue(float dB)
    {
        //入力されたdBをdB_MaxとdBMin値で切り捨て
        float modified_dB = dB;
        if (modified_dB > dB_Max) { modified_dB = dB_Max; }
        else if (modified_dB < dB_Min) { modified_dB = dB_Min; }
 
        //fillAmount値に変換(dB_Min=0.0f, dB_Max=1.0f)
        float fillAountValue = 1.0f + (modified_dB / (dB_Max - dB_Min));
        return fillAountValue;
    }


//フレームの色を暗くする
    void Black(){
        frameObject1.GetComponent<Image>().color = blackColor;
        frameObject2.GetComponent<Image>().color = blackColor;
        frameObject3.GetComponent<Image>().color = blackColor;
        frameObject4.GetComponent<Image>().color = blackColor;
        frameState = 1;
    }
    

//フレームの色を明るくする
    void White(){
        frameObject1.GetComponent<Image>().color = whiteColor;
        frameObject2.GetComponent<Image>().color = whiteColor;
        frameObject3.GetComponent<Image>().color = whiteColor;
        frameObject4.GetComponent<Image>().color = whiteColor;
    }
}

