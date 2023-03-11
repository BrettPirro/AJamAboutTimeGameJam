using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.Effects 
{
    public class BrokenLightEffect : MonoBehaviour
    {
        [SerializeField] GameObject LightObj;
        bool FlashDone = false;



        void Update()
        {
            if (!FlashDone)
            {
                StartCoroutine(Flash());
            }
        }

        IEnumerator Flash()
        {
            FlashDone = true;
            LightObj.SetActive(false);
            yield return new WaitForSeconds(Random.Range(1.2f, 2f));
            LightObj.SetActive(true);
            yield return new WaitForSeconds(Random.Range(1.2f, 2f));
            LightObj.SetActive(false);
            yield return new WaitForSeconds(Random.Range(1.2f, 2f));
            LightObj.SetActive(true);
            FlashDone = false;
        }


    }

}
