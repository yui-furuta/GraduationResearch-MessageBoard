using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImageScript : MonoBehaviour
{
    Image fadeImage;

    private byte alpha = 0;

    private bool flag =true;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha >=90){
            flag = false;
        }
        else if(alpha<=0){
            flag = true;
        }

        if(flag){
            alpha+=15;
        }
        else if(!flag){
            alpha-=15;
        }

        Debug.Log(alpha);

        fadeImage.color = new Color32(255,255,255,alpha);
    }
}
