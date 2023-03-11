using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeJam.Audio;

namespace TimeJam.Effects 
{
    public class ThunderEffect : MonoBehaviour
    {
        [SerializeField] GameObject[] LightningLightObjs;
        bool EffectCommencing;
        [SerializeField] AudioClip[] thunder;

        void Update()
        {
            if (EffectCommencing) { return; }
            if (LightningLightObjs == null) { return; }
            StartCoroutine(Lightning());

        }
    
        IEnumerator Lightning()
        {
            EffectCommencing = true;
            yield return new WaitForSeconds(Random.Range(4f, 7f));
            AudioCore.PlayClipAt(thunder[Random.Range(0, thunder.Length)], Camera.main.transform.position, 0f,1f);
            DisableObj(true);
            yield return new WaitForSeconds(Random.Range(0.01f, 0.2f));
            DisableObj(false);
            yield return new WaitForSeconds(Random.Range(0.01f, 0.2f));
            AudioCore.PlayClipAt(thunder[Random.Range(0, thunder.Length)], Camera.main.transform.position, 0f,1f);
            DisableObj(true);
            yield return new WaitForSeconds(Random.Range(0.01f, 0.2f));
            DisableObj(false);

            EffectCommencing = false;

        }

        private void DisableObj(bool EnableOrDisable)
        {
            foreach (GameObject obj in LightningLightObjs)
            {
                obj.SetActive(EnableOrDisable);

            }
        }






    }


}