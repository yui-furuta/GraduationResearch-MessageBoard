using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//花の色の設定

public class flowerImageScript : MonoBehaviour
{

    //親オブジェクトのスクリプト
    public SoundPlayerObjScript2 Script2 ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlowerChange()
    {

        Color32 color = this.GetComponent<Image>().color;

        Debug.Log(Script2.hour);

        if(Script2.hour==0){
            color.r = 32;
            color.g = 45;
            color.b = 117;
        }else if(Script2.hour==1){
            color.r = 68;
            color.g = 73;
            color.b = 122;
        }else if(Script2.hour==2){
            color.r = 106;
            color.g = 101;
            color.b = 134;
        }else if(Script2.hour==3){
            color.r = 147;
            color.g = 131;
            color.b = 147;
        }else if(Script2.hour==4){
            color.r = 188;
            color.g = 157;
            color.b = 160;
        }else if(Script2.hour==5){
            color.r = 226;
            color.g = 189;
            color.b = 172;
        }else if(Script2.hour==6){
            color.r = 218;
            color.g = 198;
            color.b = 188;
        }else if(Script2.hour==7){
            color.r = 203;
            color.g = 206;
            color.b = 209;
        }else if(Script2.hour==8){
            color.r = 193;
            color.g = 212;
            color.b = 225;
        }else if(Script2.hour==9){
            color.r = 180;
            color.g = 213;
            color.b = 233;
        }else if(Script2.hour==10){
            color.r = 162;
            color.g = 205;
            color.b = 231;
        }else if(Script2.hour==11){
            color.r = 133;
            color.g = 197;
            color.b = 229;
        }else if(Script2.hour==12){
            color.r = 94;
            color.g = 188;
            color.b = 227;
        }else if(Script2.hour==13){
            color.r = 101;
            color.g = 178;
            color.b = 225;
        }else if(Script2.hour==14){
            color.r = 128;
            color.g = 174;
            color.b = 184;
        }else if(Script2.hour==15){
            color.r = 153;
            color.g = 174;
            color.b = 140;
        }else if(Script2.hour==16){
            color.r = 193;
            color.g = 164;
            color.b = 98;
        }else if(Script2.hour==17){
            color.r = 213;
            color.g = 159;
            color.b = 63;
        }else if(Script2.hour==18){
            color.r = 255;
            color.g = 132;
            color.b = 56;
        }else if(Script2.hour==19){
            color.r = 189;
            color.g = 104;
            color.b = 103;
        }else if(Script2.hour==20){
            color.r = 110;
            color.g = 78;
            color.b = 174;
        }else if(Script2.hour==21){
            color.r = 78;
            color.g = 67;
            color.b = 187;
        }else if(Script2.hour==22){
            color.r = 47;
            color.g = 60;
            color.b = 163;
        }else if(Script2.hour==23){
            color.r = 39;
            color.g = 53;
            color.b = 140;
        }

        this.GetComponent<Image>().color = color;
    }
}
