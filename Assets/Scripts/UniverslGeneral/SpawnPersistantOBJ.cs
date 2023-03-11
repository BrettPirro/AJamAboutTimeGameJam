using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPersistantOBJ : MonoBehaviour
{
    static bool Spawned = false;
    [SerializeField] GameObject PersistantOBJ;
    
    void Awake()
    {
        if (!Spawned) 
        {
            GameObject obj = Instantiate(PersistantOBJ, transform.position, transform.rotation) as GameObject;
            Spawned = true;
            DontDestroyOnLoad(obj);
        }



    }

   
}
