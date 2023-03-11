using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.UniversalGeneral 
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class OnPlayerCollisonEnableandDisable : MonoBehaviour
    {
        [SerializeField] GameObject[] objsToEnable;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                EnablingObj();
                gameObject.SetActive(false);
            }
        }

        private void EnablingObj()
        {
            if (objsToEnable == null) { return; }
            foreach (GameObject i in objsToEnable)
            {
                i.SetActive(true);
            }
        }


    }
}
