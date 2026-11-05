using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject nameInputField;
    public TMP_InputField nameInput;
    public GameObject nameWarningPopup;
    public GameObject IntroCanvas;
    public GameObject FirstActivityCanvas;
    public Animator characterAnimator;

    [TextArea(2, 5)]
    public string[] introductionActivityDialogues;

    private int sceneID = 0;
    private string playerName = "";
    // Start is called before the first frame update
    void Start()
    {
        if (introductionActivityDialogues.Length > 0)
        {
            dialogueText.text = introductionActivityDialogues[sceneID];
        }

        if (nameInputField != null)
        {
            nameInputField.SetActive(false);
        }
        if (nameWarningPopup != null)
            nameWarningPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnNextButtonClicked()
    {
        if (sceneID == 1)
        {
            if (string.IsNullOrWhiteSpace(nameInput.text))
            {
                nameWarningPopup.SetActive(true);
                return;
            }
        }

        sceneID++;

        if (sceneID < introductionActivityDialogues.Length)
        {
            if (sceneID == 1 && nameInputField != null)
            {
                nameInputField.SetActive(true);
            }

            if (sceneID == 2)
            {
                playerName = nameInput.text;
                UserData.playerName = playerName;

                if (nameInputField != null)
                    nameInputField.SetActive(false);

                if (characterAnimator != null)
                    characterAnimator.SetTrigger("PlayWave");
            }

            string currentText = introductionActivityDialogues[sceneID];

            if (!string.IsNullOrEmpty(playerName))
            {
                currentText = currentText.Replace("[name]", playerName);
            }

            dialogueText.text = currentText;
        }
        else
        {
            Debug.Log("Diyalog bitti!");
            IntroCanvas.SetActive(false);
            FirstActivityCanvas.SetActive(true);
        }
    }
    public void CloseWarningPopup()
    {
        if (nameWarningPopup != null)
            nameWarningPopup.SetActive(false);
    }
    public void OnBackButtonClicked()
    {
        if (sceneID > 0)
        {
            sceneID--;

            string currentText = introductionActivityDialogues[sceneID];

            if (sceneID == 1)
            {
                if (nameInputField != null)
                    nameInputField.SetActive(true);

                if (nameInput != null)
                    nameInput.text = "";

                playerName = "";
            }
            else
            {
                if (nameInputField != null)
                    nameInputField.SetActive(false);
            }

            dialogueText.text = currentText;
        }
    }
    public void SetScene(int id)
    {
        if (id >= 0 && id < introductionActivityDialogues.Length)
        {
            sceneID = id;
            string text = introductionActivityDialogues[sceneID];

            if (!string.IsNullOrEmpty(playerName))
            {
                text = text.Replace("[name]", playerName);
            }

            dialogueText.text = text;
        }
    }
}