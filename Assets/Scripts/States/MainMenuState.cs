using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleSpriteAnimator;
using UnityEngine.SceneManagement;

public class MainMenuState : MonoBehaviour
{
    [Header("Sound Stuff")]
    public AudioClip selectionclip;
    private AudioSource audioSource;   
    public AudioClip actuallypressedclip;
    private AudioSource audioSource2;   
    [Header("Buttons")]
    public GameObject[] menuButtons;
    private int currentIndex = 0;
    [Header("Anims/Input")]
    public KeyCode titleenterinput;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        // Sound stuff
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = selectionclip;
        audioSource.loop = false; 
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = actuallypressedclip;
        audioSource2.loop = false;                 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.Play();
            currentIndex = (currentIndex + 1) % menuButtons.Length;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.Play();
            currentIndex = (currentIndex + menuButtons.Length - 1) % menuButtons.Length;
            UpdateButtonSelection();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("PlayState");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource2.Play();
            StartCoroutine(LoadNextSceneAfterDelay(1f));
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(delay);
        string sceneName = menuButtons[currentIndex].GetComponent<MenuButton>().sceneToLoad;
        SceneManager.LoadScene(sceneName);
    } 

    void UpdateButtonSelection()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            Animator animator = menuButtons[i].GetComponent<Animator>();
            if (i == currentIndex)
            {
                animator.Play("Default"); // OG SELECTED
            }
            else
            {
                animator.Play("Selected"); // OG DEFAULT
            }
        }
    }  
}
