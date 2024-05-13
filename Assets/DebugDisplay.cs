using TMPro;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{
    static TextMeshProUGUI sInstance;

    public static void Display(float number)
    {
        Display(string.Format("{0:0.00}", number));
    }

    public static void Display(string text)
    {
        if (!sInstance.gameObject.activeSelf)
            sInstance.gameObject.SetActive(true);

        sInstance.text = text;
    }

    void Start()
    {
        sInstance = GetComponent<TextMeshProUGUI>();

        sInstance.gameObject.SetActive(false);
    }
}
