using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class viceCountScript : MonoBehaviour
{

    Text timerText;
    public GameObject startObject;
    //public GameObject recordingObject;

    public MyRecording myRecording;
 
	public float totalTime = 4.0f;
	int seconds;

    // Start is called before the first frame update

    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text= seconds.ToString();
        if(seconds<=0){

            myRecording.recordTime =0;
            startObject.SetActive (true);
            totalTime = 4.0f;
            this.gameObject.SetActive(false);

        }
        //Debug.Log(Time.deltaTime);
    }
}
