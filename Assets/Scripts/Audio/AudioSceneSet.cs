using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.Audio 
{
    public class AudioSceneSet : MonoBehaviour
    {
        [SerializeField] AudioClip AmbientAudio;
        private void Start()
        {
            if (AmbientAudio == null) 
            {
                Debug.LogWarning("This Scene is lacking ambient music go find the obj that set it in scene");
            }
            else 
            {
                AmbientAudioManager ambientAudioMan = FindObjectOfType<AmbientAudioManager>();

                ambientAudioMan.ChangeAmbientAudio(AmbientAudio);
            }
            
        }

      

    }
}
