using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.SceneManage 
{
    public class MoveToSceneAfterCertainTime : MonoBehaviour
    {
        [SerializeField] float WaitTime = 0.9f;
        [SerializeField] bool LoadMenu = false;
        void Start()
        {
            StartCoroutine(LoadToNextSceneAfterSec());
        }
        IEnumerator LoadToNextSceneAfterSec() 
        {
            yield return new WaitForSeconds(WaitTime);
            if (LoadMenu) 
            {
                FindObjectOfType<SceneManagers>().LoadMenus();
            }
            else 
            {
                FindObjectOfType<SceneManagers>().LoadNextScenes();
            }
        }

    }
}
