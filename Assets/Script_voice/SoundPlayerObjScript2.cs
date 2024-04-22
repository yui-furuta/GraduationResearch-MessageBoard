using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//サウンドオブジェクトの設定
//再生回数で成長

public class SoundPlayerObjScript2 : MonoBehaviour
{

    private Vector3 mouse ;//マウスの位置
    private Vector3 target ;
    private Vector3 point ;//決定した位置
    private int state = 0 ;//オブジェクトの状態
    //private float stopTime ;//配置した時の時間

    private int tapCount = 0;//タップした回数

    private int seedTap = 2 ;//タネになる回数
    private int budTap = 3 ;//芽になる回数


    public GameObject seedObject;
    public GameObject budObject;
    public GameObject flowerObject;
    public GameObject flowerFrameObject;
    public GameObject flowerShadowObject;
    //public GameObject SEObject;

    public int hour;//時間の変数

    private DateTime dt;//生成時の時間

    flowerImageScript d1;


    // Start is called before the first frame update
    void Start()
    {
        //現在日時を代入
        dt = DateTime.Now;
        //コンソールに表示
        Debug.Log(dt);

        hour = dt.Hour;//時のみ取得
        Debug.Log(hour);

        d1 = flowerObject.GetComponent<flowerImageScript>();

    }

    // Update is called once per frame
    void Update()
    {

        //置く場所決まってない状態
        if(state == 0)
        {
            //z座標はcanvasのplaneDistanceと同じにする
            // mouse = Input.mousePosition;
            // target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 100));
            // this.transform.position = target;


            Vector3 noStopScale = new Vector3(1.5f,1.5f,1.5f);
            this.transform.localScale = noStopScale;
            
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("ボタンが押されています。");

                //タップした位置に移動
                // mouse = Input.mousePosition;
                Vector3 screenPos = Input.mousePosition;
                Vector3 stopPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 100));
                this.transform.position = stopPosition;
                
                //Debug.Log(screenPos);
                stop();
                SeScript.instance.FlowerPonAction();
            }
        }

        //置く場所決まってる状態
        if(state == 1)
        {   
            //決まったら小さく
            Vector3 stopScale = new Vector3(1f,1f,1f);
            this.transform.localScale = stopScale;

            // if(Input.GetMouseButtonDown(0))
            // {
            //     tapCount++;
            // }

            //芽になる
            if(tapCount>=seedTap & tapCount<budTap)
            {
                seedObject.SetActive (false);
                budObject.SetActive (true);
            }

            //花になる
            if(tapCount==budTap)
            {
                budObject.SetActive (false);
                flowerObject.SetActive (true);
                flowerFrameObject.SetActive (true);
                flowerShadowObject.SetActive (true);

                //flowerImageScript d1 = flowerObject.GetComponent<flowerImageScript>();
                d1.FlowerChange();

                state = 2;
            }
        }

        // // transformを取得
        // Transform myTransform = this.transform;
        //  // ローカル座標での座標を取得
        // Vector3 localPos = myTransform.localPosition;
        // localPos.z = 1f;    // ローカル座標を基準にした、z座標を1に変更
        // myTransform.localPosition = localPos; // ローカル座標での座標を設定
    }

    void stop()
    {
        //その場に止まる
        state = 1;
        Debug.Log("stopが呼ばれた");
        Debug.Log(state);
    }

    public void FlowerTap()
    {
        tapCount++;
    }
}

