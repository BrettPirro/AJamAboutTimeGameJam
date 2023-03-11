using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.Audio 
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ChangeTrackOnTrigger : MonoBehaviour
    {
        [SerializeField] AudioClip clip;
        AmbientAudioManager audioManager;
        [SerializeField]float SelectedAudioVol;
        [SerializeField] float transitionSpeed;
        bool ChangeStarted=false;

        void Start()
        {
            audioManager = FindObjectOfType<AmbientAudioManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player"&&!ChangeStarted) 
            {
                ChangeStarted = true;
                StartCoroutine(TransitionAudio());

            }
        }
    
        IEnumerator TransitionAudio() 
        {
            yield return audioManager.FadeOutAudio(transitionSpeed);
            audioManager.ChangeAmbientAudio(clip);
            yield return audioManager.FadeInAudioToo(transitionSpeed,SelectedAudioVol);
            ChangeStarted = false;

        }
    
    
    }

}