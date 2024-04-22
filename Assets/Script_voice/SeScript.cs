using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeScript : MonoBehaviour
{
    public AudioClip ButtonPon;
    public AudioClip FlowerPon;

    AudioSource audioSource;

    public static SeScript instance;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(instance == null){
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPonAction(){

        audioSource.PlayOneShot(ButtonPon);

    }

    public void FlowerPonAction(){

        audioSource.PlayOneShot(FlowerPon);
    }
}
