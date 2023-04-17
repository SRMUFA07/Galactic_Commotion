using UnityEngine.UI;
using UnityEngine;

public class LanguageText : MonoBehaviour
{
    public static int languageNumber;
    public string[] translation;
    private Text _textLine;

    private void Start()
    {
        _textLine = GetComponent<Text>();
        _textLine.text = "" + translation[languageNumber];
    }
}
