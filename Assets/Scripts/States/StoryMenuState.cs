using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuState : MonoBehaviour
{
    [Header("Sound Stuff")]
    public AudioClip selectionclip;
    private AudioSource audioSource;
    public AudioClip actuallypressedclip;
    private AudioSource audioSource2;       
    [Header("Arrow Anim Stuffs")]
    public Animator leftArrow;
    public Animator rightArrow;
    [Header("Diff Text Related Stuff")]
    public GameObject[] texts;
    private int currentIndex = 0;
    [Header("Week Related Stuff")]
    public Transform[] weeks;
    public Transform[] chars;
    private int selectedIndex = 0;
    private int selectedIndex2 = 0;
    [Header("Week Songs Stuff")]
    public Transform[] songs;
    private int selectedIndex3 = 0;

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
        // DIFF SHII
        ShowDiffText(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        // When I enter my credit card info onto a free robux site:
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectCurWeek();
        }
        // Week Selection
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.Play();
            SelectPrevWeek();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.Play();
            SelectNextWeek();
        }

        // Difficulty Selection
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftArrow.Play("LeftArrowPressed");
            SwitchToNextText();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //rightArrow.SetTrigger("RAPressed");
            rightArrow.Play("RightArrowPressed");
            SwitchToPreviousText();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftArrow.Play("LeftArrowAnim");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //rightArrow.SetTrigger("RAPressed");
            rightArrow.Play("RightArrowAnim");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource2.Play();
        }        
    }

    // When I enter
    void SelectCurWeek()
    {
        // Swag
    }

    // WEEK SHII
    void SelectPrevWeek()
    {
        // Silly Songs List
        selectedIndex3--;
        if (selectedIndex3 < 0)
        {
            selectedIndex3 = songs.Length - 1;
        }        
        // Silly Chars
        selectedIndex2--;
        if (selectedIndex2 < 0)
        {
            selectedIndex2 = chars.Length - 1;
        }
        UpdateSelectedSprite();
        // Week Text Thingy
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = weeks.Length - 1;
        }
        UpdateSelectedSprite();
    }

    void SelectNextWeek()
    {
        // Songs List
        selectedIndex3++;
        if (selectedIndex3 >= songs.Length)
        {
            selectedIndex3 = 0;
        }
        // Week Chars
        selectedIndex2++;
        if (selectedIndex2 >= chars.Length)
        {
            selectedIndex2 = 0;
        }
        // Week Text Thingy
        selectedIndex++;
        if (selectedIndex >= weeks.Length)
        {
            selectedIndex = 0;
        }
        UpdateSelectedSprite();
    }

    void UpdateSelectedSprite()
    {
        // Week Chars
        foreach (Transform sprite in chars)
        {
            sprite.gameObject.SetActive(false);
        }
        chars[selectedIndex2].gameObject.SetActive(true);
        // Week Texts
        foreach (Transform sprite in weeks)
        {
            sprite.gameObject.SetActive(false);
        }
        weeks[selectedIndex].gameObject.SetActive(true);
    }

    // DIFFICULTY SHII
    void ShowDiffText(int index)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == index);
        }
    }

    void SwitchToNextText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        ShowDiffText(currentIndex);
    }

    void SwitchToPreviousText()
    {
        currentIndex = (currentIndex - 1 + texts.Length) % texts.Length;
        ShowDiffText(currentIndex);
    }
}
