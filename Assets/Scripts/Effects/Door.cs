using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeJam.Controls;
using TimeJam.Audio;



namespace TimeJam.Effects 
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Door : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        [SerializeField] float Index;
        [SerializeField]AudioClip clip;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponent<PlayerInput>().CheckForKeyIndex(Index))
                {
                    spriteRenderer.color = new Color(0.2f,0.2f,0.2f);
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    AudioCore.PlayClipAt(clip, Camera.main.transform.position, 1, 1);
                }
            }
        }
    }
}
