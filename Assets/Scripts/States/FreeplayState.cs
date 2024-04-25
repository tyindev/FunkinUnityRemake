using UnityEngine;
using UnityEngine.UI;

public class FreeplayState : MonoBehaviour
{
    [Header("Diff Text Related Stuff")]
    public Text[] texts;
    private int currentIndex = 0;

    void Start()
    {
        ShowText(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchToNextText();
            //SwitchToPreviousText();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchToPreviousText();
            //SwitchToNextText();
        }
    }

    void ShowText(int index)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == index);
        }
    }

    void SwitchToNextText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        ShowText(currentIndex);
    }

    void SwitchToPreviousText()
    {
        currentIndex = (currentIndex - 1 + texts.Length) % texts.Length;
        ShowText(currentIndex);
    }
}
