using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterflyScript : MonoBehaviour
{
    private int d;

    private float moveSpeed = 5f;

    private float rotateSpeed = 0;
    private float rotateAbs = 0.7f;

    private float rotateZ = 0f;

    private bool rotate01;

    private bool rotate02;

    internal static T GetRandom<T> (params T [] Params)
    {
        return Params [Random.Range (0, Params.Length)];
    }

    float[] array = {-600,200,1000};


    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed= rotateAbs;
    }

    // Update is called once per frame
    void Update()
    {
        rotateZ +=  rotateSpeed*Time.deltaTime;

        //Debug.Log(rotateZ);

        if(rotateZ > 1){
            rotate01 = true;
            rotate02 = false;
        }
        if(rotateZ < -1){
            rotate02 = true;
            rotate01 = false;
        }

        if(rotate01){
            rotateSpeed = rotateAbs*-1;
        }
        if(rotate02){
            rotateSpeed = rotateAbs;
        }

        // transformを取得
        Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.localPosition;

        if(pos.y>950){
            pos.y = -950;
            pos.x = GetRandom(array);
            myTransform.localPosition = pos;  // 座標を設定
        }





        ///移動させる処理　引数は(移動する方向*移動する距離(速度)*Time.deltaTime)
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0,0,rotateZ));
        // if(d == 0){
            
        // }
        // else if(d == 1){

        // }
    }
}
