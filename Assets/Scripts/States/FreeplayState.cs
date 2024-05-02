using UnityEngine;
using UnityEngine.UI;

public class FreeplayState : MonoBehaviour
{
    [Header("Diff Text Related Stuff")]
    public GameObject[] diffs;
    private int currentIndex = 1;
    [Header("Swagger Camera")]
    public Camera swaggerCam;
    [Header("Sound Stuff")]
    private AudioSource pressedAudio;   
    private AudioSource scrollAudio;   
    public AudioSource backitup;  
    [Header("Week Related Stuff")]
    public Transform[] weeks;
    private int selectedIndex = 0;

    void Start()
    {
        ShowText(currentIndex);
    }

    void Update()
    {
        // DIFICULTY CONTROLS
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchToNextText();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchToPreviousText();
        } 

        // SONG SWITCHING CONTROLS
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectPrevWeek();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectNextWeek();
        }
    }

    void ShowText(int index)
    {
        for (int i = 0; i < diffs.Length; i++)
        {
            diffs[i].gameObject.SetActive(i == index);
        }
    }

    void SwitchToNextText()
    {
        currentIndex = (currentIndex + 1) % diffs.Length;
        ShowText(currentIndex);
    }

    void SwitchToPreviousText()
    {
        currentIndex = (currentIndex - 1 + diffs.Length) % diffs.Length;
        ShowText(currentIndex);
    }

    // WEEK SHII
    void SelectPrevWeek()
    {
        // Week Text Thingy
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = weeks.Length - 1;
        }
        UpdateSelectedSprite();
    }

    void UpdateSelectedSprite()
    {
        // Week Texts
        foreach (Transform sprite in weeks)
        {
            sprite.gameObject.SetActive(false);
        }
        weeks[selectedIndex].gameObject.SetActive(true);
    }

    void SelectNextWeek()
    {
        // Week Text Thingy
        selectedIndex++;
        if (selectedIndex >= weeks.Length)
        {
            selectedIndex = 0;
        }
        UpdateSelectedSprite();
    }
}
