using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.Audio 
{
    [RequireComponent(typeof(AudioSource))]
    
    public class AmbientAudioManager : MonoBehaviour
    {
        AudioSource audioSource;
       

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }


        public void ChangeAmbientAudio(AudioClip audioClip) 
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void FadeTheVolumeIntoo(float time, float point) 
        {
           
           
            StartCoroutine(FadeInAudioToo(time, point));

        }

        public void FadeTheVolumeOuttoo(float time, float point)
        {
            
       
            StartCoroutine(FadeOutAudioToo(time, point));

        }


        public IEnumerator FadeOutAudio(float time) 
        {
            while (audioSource.volume != 0)
            {
                audioSource.volume -= Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeInAudio(float time)
        {
            while (audioSource.volume != 1)
            {
                audioSource.volume += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeOutAudioToo(float time,float Point)
        {
            while (audioSource.volume > Point)
            {
                audioSource.volume -= Time.deltaTime / time;
                yield return null;
            }
            
        }

        public IEnumerator FadeInAudioToo(float time, float Point)
        {
            while (audioSource.volume < Point)
            {
                audioSource.volume += Time.deltaTime / time;
                yield return null;
            }
        
        }

    }
}
