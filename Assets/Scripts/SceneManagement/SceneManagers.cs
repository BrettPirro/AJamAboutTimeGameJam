using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TimeJam.Audio;

namespace TimeJam.SceneManage 
{
    public class SceneManagers : MonoBehaviour
    {
        [SerializeField] float SceneTransitionFade = 0.8f;
        int LastSceneLoaded;

        public void LoadLastScenes()
        {
            StartCoroutine(LoadLastScene());
        }


        public void LoadNextScenes() 
        {
            StartCoroutine(LoadNextScene());
        }

        public void LoadMenus()
        {
            StartCoroutine(LoadMenu());
        }

        public void LoadGameOvers()
        {
            StartCoroutine(LoadGameOver());
        }

        public void LoadOptions()
        {
            StartCoroutine(LoadOption());
        }


        IEnumerator LoadNextScene()
        {
           Fader fader= FindObjectOfType<Fader>();
            LastSceneLoaded = SceneManager.GetActiveScene().buildIndex;
            AmbientAudioManager audioManager = FindObjectOfType<AmbientAudioManager>();
             yield return fader.FadeIn(SceneTransitionFade);
            yield return audioManager.FadeOutAudio(SceneTransitionFade);

            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

            yield return fader.FadeOut(SceneTransitionFade);

            yield return audioManager.FadeInAudio(SceneTransitionFade);

        }


        IEnumerator LoadLastScene()
        {
            Fader fader = FindObjectOfType<Fader>();
        
            AmbientAudioManager audioManager = FindObjectOfType<AmbientAudioManager>();
            yield return fader.FadeIn(SceneTransitionFade);
            yield return audioManager.FadeOutAudio(SceneTransitionFade);

            yield return SceneManager.LoadSceneAsync(LastSceneLoaded);

            yield return fader.FadeOut(SceneTransitionFade);

            yield return audioManager.FadeInAudio(SceneTransitionFade);

        }

        IEnumerator LoadMenu()
        {
            AmbientAudioManager audioManager = FindObjectOfType<AmbientAudioManager>();
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeIn(SceneTransitionFade);
            yield return audioManager.FadeOutAudio(SceneTransitionFade);
            yield return SceneManager.LoadSceneAsync("MainMenu");
           
            yield return fader.FadeOut(SceneTransitionFade);
            yield return audioManager.FadeInAudio(SceneTransitionFade);

        }

        IEnumerator LoadGameOver()
        {
            AmbientAudioManager audioManager = FindObjectOfType<AmbientAudioManager>();
            LastSceneLoaded = SceneManager.GetActiveScene().buildIndex;
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeIn(SceneTransitionFade);
            yield return audioManager.FadeOutAudio(SceneTransitionFade);
            yield return SceneManager.LoadSceneAsync("GameOver");
       
            yield return fader.FadeOut(SceneTransitionFade);
            yield return audioManager.FadeInAudio(SceneTransitionFade);

        }

        IEnumerator LoadOption()
        {
            Fader fader = FindObjectOfType<Fader>();
            AmbientAudioManager audioManager = FindObjectOfType<AmbientAudioManager>();
            yield return fader.FadeIn(SceneTransitionFade);
            yield return audioManager.FadeOutAudio(SceneTransitionFade);

            yield return SceneManager.LoadSceneAsync("Options");

            yield return fader.FadeOut(SceneTransitionFade);

            yield return audioManager.FadeInAudio(SceneTransitionFade);


        }




    }
}
