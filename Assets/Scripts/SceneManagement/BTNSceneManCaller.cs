using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.SceneManage 
{
    public class BTNSceneManCaller : MonoBehaviour
    {
        bool Pressed = false;

        public void LoadNextLVL() 
        {
            if (Pressed) { return; }
            Pressed = true;
            FindObjectOfType<SceneManagers>().LoadNextScenes();
        }

        public void LoadLastLVL()
        {
            if (Pressed) { return; }
            Pressed = true;
            FindObjectOfType<SceneManagers>().LoadLastScenes();
        }

        public void LoadGameOver()
        {
            if (Pressed) { return; }
            Pressed = true;
            FindObjectOfType<SceneManagers>().LoadGameOvers();
        }

        public void LoadMainMenu()
        {
            if (Pressed) { return; }
            Pressed = true;
            FindObjectOfType<SceneManagers>().LoadMenus();
        }

        public void LoadOption()
        {
            if (Pressed) { return; }
            Pressed = true;
            FindObjectOfType<SceneManagers>().LoadOptions();
        }
    }
}
