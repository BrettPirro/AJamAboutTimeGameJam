using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.UniversalGeneral 
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DisableObj : MonoBehaviour
    {
        [SerializeField] GameObject[] ObjsToDisable;
        [SerializeField] bool DisableOrEnable;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player") 
            {
                foreach(GameObject i in ObjsToDisable) 
                {
                    if (DisableOrEnable) { i.SetActive(false); }
                    else { i.SetActive(true); }
                }
            }


        }



    }

}
