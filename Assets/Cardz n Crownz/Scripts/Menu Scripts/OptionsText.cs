using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsText : MonoBehaviour
{
    [SerializeField] TMP_Dropdown fontDropdown;
    public List<TMP_FontAsset> fonts;
    TMP_Text[] texts;

    // Start is called before the first frame update
    void Start()
    {
        FontStart();
        foreach (TMP_Text text in texts)
        {
            TMP_FontAsset font = fonts[PlayerPrefs.GetInt("ActiveFont", 0)];
            text.font = font;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FontStart()
    {
        List<string> fontOptions = new List<string>();
        fontDropdown.ClearOptions();
        foreach (TMP_FontAsset font in fonts)
        {
            string fontName = font.name;
            fontOptions.Add(fontName);
        }
        fontDropdown.AddOptions(fontOptions);
        texts = FindObjectsOfType<TMP_Text>(true);
    }
    public void SetFont()
    {
        TMP_FontAsset font = fonts[fontDropdown.value];
        foreach (TMP_Text text in texts)
        {
            text.font = font;
        }
        PlayerPrefs.SetInt("ActiveFont", fontDropdown.value);
    }

}
