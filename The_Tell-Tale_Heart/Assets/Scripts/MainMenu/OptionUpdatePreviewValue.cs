using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionUpdatePreviewValue : MonoBehaviour
{
    [SerializeField]
    private Slider selectedSlider;

    private TextMeshProUGUI myTextMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        myTextMeshProUGUI = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        myTextMeshProUGUI.text = selectedSlider.value.ToString();
    }
}
