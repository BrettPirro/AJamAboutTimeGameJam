using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimeJam.SceneManage 
{
    public class Fader : MonoBehaviour
    {

        CanvasGroup canvas;

        void Start()
        {
            canvas = GetComponent<CanvasGroup>();
            instantFadeIn();
            StartCoroutine(FadeOut(1f));
        }

        public IEnumerator FadeIn(float time)
        {
            while (canvas.alpha < 1)
            {
                canvas.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }


        public void instantFadeOut()
        {
            canvas.alpha = 0;
        }

        public void instantFadeIn()
        {
            canvas.alpha = 1;
        }

    }
}
