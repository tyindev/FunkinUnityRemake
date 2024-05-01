using UnityEngine;
using UnityEngine.UI;

public class FreeplayState : MonoBehaviour
{
    [Header("Diff Text Related Stuff")]
    public GameObject[] diffs;
    private int currentIndex = 1;
    [Header("Buttons")]
    public GameObject[] songs;
    private int currentIndexSong = 0;
    [Header("Swagger Camera")]
    public Camera swaggerCam;
    [Header("Sound Stuff")]
    private AudioSource pressedAudio;   
    private AudioSource scrollAudio;   
    public AudioSource backitup;  

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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //scrollAudio.Play();
            currentIndex = (currentIndex + 1) % songs.Length;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //scrollAudio.Play();
            currentIndex = (currentIndex + songs.Length - 1) % songs.Length;
            UpdateButtonSelection();
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

    void UpdateButtonSelection()
    {
        Vector3 targetPosition = songs[currentIndexSong].transform.position;
        targetPosition.z = swaggerCam.transform.position.z;
        swaggerCam.transform.position = targetPosition;
    } 
}
