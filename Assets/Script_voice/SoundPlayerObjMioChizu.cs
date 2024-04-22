using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//MioChizuサウンドオブジェクトの設定
//再生回数で成長

public class SoundPlayerObjMioChizu : MonoBehaviour
{

    public GameObject seedObject;
    public GameObject budObject;
    public GameObject flowerObject;
    public GameObject flowerFrameObject;
    public GameObject flowerShadowObject;


    private int tapCount = 0;//タップした回数

    private int seedTap = 3 ;//タネになる回数
    private int budTap = 6 ;//芽になる回数


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                //d1.FlowerChange();
            } 
    }

    public void FlowerTapMioChizu()
    {
        tapCount++;
    }
}
