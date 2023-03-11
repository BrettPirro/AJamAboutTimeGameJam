using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.SceneManage 
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class NextLevelCollider : MonoBehaviour
    {
        bool Done=false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player"&& !Done) 
            {
                Done = true;
                FindObjectOfType<SceneManagers>().LoadNextScenes();
            }


        }
    }
}
