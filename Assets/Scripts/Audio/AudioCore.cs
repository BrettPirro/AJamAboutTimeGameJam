using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.Audio 
{
    public class AudioCore : MonoBehaviour
    {
        public static AudioSource PlayClipAt(AudioClip clip, Vector3 pos, float spatialBlend, float volume)
        {
            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = pos;
            AudioSource aSource = tempGO.AddComponent<AudioSource>();
            aSource.clip = clip;
            aSource.spatialBlend = spatialBlend;
            aSource.volume = volume;
            aSource.Play();
            Destroy(tempGO, clip.length);
            return aSource;
        }

        public static void DestroyAllAudioSourcesInScene() 
        {
            foreach(AudioSource i in FindObjectsOfType<AudioSource>()) 
            {
                Destroy(i);
            }
        }

    }

}