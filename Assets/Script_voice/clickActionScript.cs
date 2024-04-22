using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickActionScript : MonoBehaviour
{

    public GameObject butterflyPanel;
    public GameObject butterfly01;
    public GameObject butterfly02;
    public GameObject butterfly03;

    public GameObject beePanel;
    public GameObject bee01;
    public GameObject bee02;

    public GameObject helpPanel;

    public GameObject joroButton;
    public GameObject helpButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //蜂をタップ
    public void beeTap(){
        beePanel.SetActive (true);
        panelOpen();
    }

    public void beeNext01Tap(){
        bee01.SetActive (false);
        bee02.SetActive (true);
    }

    public void beeReturn02Tap(){
        bee01.SetActive (true);
        bee02.SetActive (false);
        beePanel.SetActive(false);
        panelClose();
    }

    //蝶をタップ
    public void buttrflyTap(){
        butterflyPanel.SetActive(true);
        panelOpen();
    }

    public void butterflyNext01Tap(){
        butterfly01.SetActive(false);
        butterfly02.SetActive(true);
    }

    public void butterflyNext02Tap(){
        butterfly02.SetActive(false);
        butterfly03.SetActive(true);
    }

    public void butterflyReturn03Tap(){
        butterfly03.SetActive(false);
        butterfly01.SetActive(true);
        butterflyPanel.SetActive(false);
        panelClose();
    }

    //ヘルプボタンタップ
    public void helpTap(){
        helpPanel.SetActive(true);
        panelOpen();
    }

    public void helpReturn01Tap(){
        helpPanel.SetActive(false);
        panelClose();
    }

    //何かのボタンを押す
    public void panelOpen(){
        helpButton.SetActive(false);
        joroButton.SetActive(false);
    }

    //パネルを閉じる
    public void panelClose(){
        helpButton.SetActive(true);
        joroButton.SetActive(true);
    }

}
