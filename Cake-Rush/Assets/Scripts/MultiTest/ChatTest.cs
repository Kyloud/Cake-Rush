using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ChatTest : MonoBehaviour
{
    [SerializeField]
    private GameObject inputBox;
    [SerializeField]
    private GameObject[] textBoxs;
    [SerializeField]
    private TMP_InputField input;
    [SerializeField]
    private GameObject scrollView;
    [SerializeField]
    private TMP_Text[] texts = new TMP_Text[5];
    private int maxLenght = 5;
    private bool isChat;

    private void Start()
    {
        isChat = false;
        for(int i = 0; i < maxLenght; i++)
        {
            texts[i] = textBoxs[i].GetComponent<TMP_Text>();
        }
        input = inputBox.GetComponent<TMP_InputField>();
        inputBox.SetActive(false);
        scrollView.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            isChat = !isChat;

            if(isChat)
            {
                inputBox.SetActive(true);
                scrollView.SetActive(true);
                input.Select();
                return;
            }
            else if(input.text == "")
            {
                inputBox.SetActive(false);
                scrollView.SetActive(false);
                return;
            }

            for (int i = maxLenght - 1; i > 0; i--)
            {
                texts[i].text = texts[i - 1].text;
            }
            texts[0].text = input.text;
            input.text = "";
            input.Select();
        }

    }
}
