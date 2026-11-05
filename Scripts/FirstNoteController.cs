using UnityEngine;
using TMPro;

public class FirstNoteController : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject negativePopup;
    public FirstActivityManager manager;
    public GameObject notePanel;
    public GameObject noteText;
    public GameObject noteInput;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public TMP_InputField note2input;
    public TMP_InputField note3input;
    public TMP_InputField note4input;

    public string correctAnswer = "80";

    //ilk başlarda notları ayrı tutmamın daha rahat olacağını düşünmüştüm fakat sonrasında actmanager içlerine yazdım. bunu değiştirmedim.
    void Start()
    {

        if (negativePopup != null)
            negativePopup.SetActive(false);
    }

    public void CheckNoteValue()
    {
        int id = manager.sceneID;

        if (id == 4)
        {
            string userInput = inputField.text;

            if (string.IsNullOrWhiteSpace(userInput) || userInput != correctAnswer)
            {
                if (negativePopup != null)
                    negativePopup.SetActive(true);
            }
            else
            {
                manager.sceneID++;
                manager.SetDialogue(manager.sceneID);
            }
        }
        else if (id == 8)
        {
            string kisa = manager.kisaInputField.text.Trim().Replace(",", ".");

            if (string.IsNullOrWhiteSpace(kisa) || kisa != "1")
            {
                if (manager.negativePopup2 != null)
                    manager.negativePopup2.SetActive(true);

                return;
            }

            manager.sceneID++;
            manager.SetDialogue(manager.sceneID);
        }

        else if (id == 9)
        {
            string kisa = manager.kisaInputField.text.Trim().Replace(",", ".");
            string uzun = manager.uzunInputField.text.Trim().Replace(",", ".");

            if (kisa == "1" && uzun == "2")
            {
                manager.sceneID++;
                manager.SetDialogue(manager.sceneID);
            }
            else
            {
                if (manager.negativePopup2 != null)
                    manager.negativePopup2.SetActive(true);
            }
        }

        else if (id == 10)
        {
            string val2 = note2input.text.Trim();
            string val3 = note3input.text.Trim();
            string val4 = note4input.text.Trim();

            if (val2 == "1" && val3 == "2" && val4 == "2")
            {
                
                manager.sceneID++;
                manager.SetDialogue(manager.sceneID);

            }
            else
            {
                if (manager.negativePopup3 != null)
                    manager.negativePopup3.SetActive(true);
            }
        }
    }

    public void CloseNegativePopup()
    {
        if (negativePopup != null)
            negativePopup.SetActive(false);

        if (manager.negativePopup2 != null)
            manager.negativePopup2.SetActive(false);

        if (manager.negativePopup3 != null)
            manager.negativePopup3.SetActive(false);
    }

    public void CloseNotepad ()
    {
        if (notePanel != null)
            notePanel.SetActive(false);
    }
    public void ToggleNote()
    {
        if (notePanel == null)
            return;

        bool isActive = notePanel.activeSelf;
        notePanel.SetActive(!isActive);
    }
    public void SetNoteContentVisible(bool visible)
    {
        if (noteText != null) noteText.SetActive(visible);
        if (noteInput != null) noteInput.SetActive(visible);

        int id = manager.sceneID;

        if (inputField != null)
        {
            inputField.gameObject.SetActive(visible);
            inputField.interactable = (id == 4);
        }

        bool advancedNotesVisible = visible && id >= 10;

        if (note2 != null) note2.SetActive(advancedNotesVisible);
        if (note3 != null) note3.SetActive(advancedNotesVisible);
        if (note4 != null) note4.SetActive(advancedNotesVisible);

        if (note2input != null)
        {
            note2input.gameObject.SetActive(advancedNotesVisible);
            note2input.interactable = (id == 10);
        }

        if (note3input != null)
        {
            note3input.gameObject.SetActive(advancedNotesVisible);
            note3input.interactable = (id == 10);
        }

        if (note4input != null)
        {
            note4input.gameObject.SetActive(advancedNotesVisible);
            note4input.interactable = (id == 10);
        }
    }
}
