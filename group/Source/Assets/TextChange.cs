using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    private Text text_Value;

    // Start is called before the first frame update
    void Start()
    {
        text_Value = GetComponent<Text>();
    }

    // Update is called once per frame
    public void OnSliderValueChanged(float value)
    {
        text_Value.text = value.ToString("0");
    }
}
