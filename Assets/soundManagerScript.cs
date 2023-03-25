using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static AudioClip GunShotSound;
    static AudioSource audioSrc;
    void Start()
    {
        GunShotSound = Music.Load<AudioClip> ("51749__erkanozan__gunshot ");
        audioSrc = GetComponet<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip){
        switch (clip) {
            case "51749__erkanozan__gunshot ":
            audioSrc.PlayOneShot(GunShotSound);
            break;
        }
    }

}
