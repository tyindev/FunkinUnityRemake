using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleSpriteAnimator;
using UnityEngine.SceneManagement;

public class TitleState : MonoBehaviour
{
    [Header("Sound")]
    public AudioClip actuallypressedclip;
    private AudioSource audioSource2;   
    [Header("Anims/Input")]
    private SpriteAnimator spriteAnimator;
    public KeyCode titleenterinput;
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = actuallypressedclip;
        audioSource2.loop = false;           
        spriteAnimator = GetComponent<SpriteAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(titleenterinput)) {
            audioSource2.Play();
            spriteAnimator.Play("titleEnterSELECT");
            StartCoroutine(LoadNextSceneAfterDelay(1f));
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu");
    }    
}
