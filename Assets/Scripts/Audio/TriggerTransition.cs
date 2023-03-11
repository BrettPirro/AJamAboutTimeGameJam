using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.Audio 
{
    public class TriggerTransition : MonoBehaviour
    {
        AmbientAudioManager AudioManager;
        [SerializeField] float timeTrans;
        [SerializeField] float Vol;
        [SerializeField] bool fadeIntoo;

        private void Start()
        {
            AudioManager = FindObjectOfType<AmbientAudioManager>();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player") 
            {
                if (fadeIntoo == true) { AudioManager.FadeTheVolumeIntoo(timeTrans, Vol); }
                else {AudioManager.FadeTheVolumeOuttoo(timeTrans, Vol);  }
            }



        }
    }
}
