using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

[System.Serializable]
public class SecondActivityDialogueElement
{
    [TextArea(2, 5)]
    public string dialogueText;
}

public class SecondActivityManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public List<SecondActivityDialogueElement> activityDialogues;

    public GameObject secondActivityCanvas;
    public GameObject firstActivityCanvas;
    public GameObject kontrolEtBt;
    public GameObject ileriButonu;
    public GameObject geriButonu;

    public GameObject firstActivityBG;
    public GameObject secondActivityBG;
    public GameObject secondActivityBG2;
    public GameObject secondActivityBG3;
    public GameObject mudfloor;
    public GameObject backpack;
    public GameObject olcer2;

    public SpriteRenderer char_foot1;
    public SpriteRenderer char_foot2;

    public SecondDragScript dragScript2;
    public Vector3 initialPos1 = Vector3.zero;
    public Vector3 initialPos2 = Vector3.zero;

    public bool isDrag1Completed = false;
    public bool isDrag2Completed = false;

    public GameObject notepadPanel;
    public GameObject noteDropdownObj1;
    public GameObject noteDropdownObj2;
    public GameObject noteDropdownObj3;
    public GameObject noteDropdownObj4;
    public TMP_Dropdown noteDropdown;
    public TMP_Dropdown noteDropdown2;
    public TMP_Dropdown noteDropdown3;
    public TMP_Dropdown noteDropdown4;
    public TMP_Dropdown noteDropdown5;
    public GameObject negativePopup;
    public GameObject noteText1;
    public GameObject noteText2;
    public GameObject noteText3;
    public GameObject noteText4;
    public TMP_InputField kuvvetInputField;
    public TMP_InputField yuzeyInputField;
    public GameObject basincvalueText;
    public GameObject negativePopup2;
    public GameObject badgePopup;
    public GameObject highlightarrow;
    public GameObject highlightzone1;
    public GameObject highlightzone2;
    public GameObject thirdActivityCanvas;
    public ThirdActivityManager thirdActivityManager;
    public int sceneID = 0;

    private void Start()
    {
        if (secondActivityCanvas != null)
            secondActivityCanvas.SetActive(true);

        SetDialogue(sceneID);


        if (dragScript2 != null)
        {
            initialPos2 = dragScript2.transform.position;
        }

    }
    private void ResetSceneObjects()
    {
        if (firstActivityBG != null) firstActivityBG.SetActive(false);
        if (secondActivityBG != null) secondActivityBG.SetActive(false);
        if (secondActivityBG2 != null) secondActivityBG2.SetActive(false);
        if (secondActivityBG3 != null) secondActivityBG3.SetActive(false);

        if (mudfloor != null) mudfloor.SetActive(false);
        if (backpack != null) backpack.SetActive(false);
        if (olcer2 != null) olcer2.SetActive(false);
        if (badgePopup != null) badgePopup.SetActive(false);
        if (basincvalueText != null) basincvalueText.SetActive(false);
        if (negativePopup != null) negativePopup.SetActive(false);
        if (negativePopup2 != null) negativePopup2.SetActive(false);
        if (kontrolEtBt != null) kontrolEtBt.SetActive(false);
        if (highlightarrow != null) highlightarrow.SetActive(false);
        if (highlightzone1 != null) highlightzone1.SetActive(false);
        if (highlightzone2 != null) highlightzone2.SetActive(false);


        if (dragScript2 != null)
        {
            dragScript2.enabled = false;

            if (sceneID == 2)
            {
                if (initialPos1 == Vector3.zero)
                    initialPos1 = dragScript2.transform.position;

                dragScript2.ResetToPosition(initialPos1);
            }
            else if (sceneID == 5)
            {
                if (initialPos2 == Vector3.zero)
                    initialPos2 = dragScript2.transform.position;

                dragScript2.ResetToPosition(initialPos2);
            }
        }

    }
    private void UpdateFootSortingLayer(int currentScene)
    {
        int footSortingOrder = (currentScene >= 2 && currentScene <= 4) ? -1 : 0;

        if (char_foot1 != null)
            char_foot1.sortingOrder = footSortingOrder;

        if (char_foot2 != null)
            char_foot2.sortingOrder = footSortingOrder;
    }

    public void SetDialogue(int id)
    {
        if (id >= activityDialogues.Count)
        {
            Debug.Log("Second activity bitti, üçüncü aktiviteye geçiliyor.");

            secondActivityCanvas.SetActive(false);
            thirdActivityCanvas.SetActive(true);
            thirdActivityManager.SetDialogue(0);

            return;
        }

        string text = activityDialogues[id].dialogueText;
        if (!string.IsNullOrEmpty(UserData.playerName))
            text = text.Replace("[name]", UserData.playerName);

        if (dialogueText != null)
            dialogueText.text = text;

        ResetSceneObjects();
        UpdateFootSortingLayer(id);

        switch (id)
        {
            case 0:
                if (notepadPanel != null) notepadPanel.SetActive(false);
                if (firstActivityBG != null) firstActivityBG.SetActive(true);
                break;
            case 1:
                secondActivityBG?.SetActive(true);
                break;

            case 2:
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);
                highlightarrow?.SetActive(true);
                highlightzone1?.SetActive(true);

                if (dragScript2 != null)
                {
                    dragScript2.enabled = true;
                    dragScript2.hedeftag = "dropzone1";
                }
                break;

            case 3:
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);

                if (backpack != null)
                {
                    Vector3 pos = backpack.transform.position;
                    backpack.transform.position = pos;
                }
                if (notepadPanel != null)
                    notepadPanel.SetActive(false);

                if (noteDropdown != null)
                {
                    noteDropdown.ClearOptions();
                    noteDropdown.AddOptions(new List<string> {"seçiniz", "kütle", "kuvvet" });
                    noteDropdown.value = 0;
                }
                break;

            case 4:
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);
                noteDropdown.interactable = false;
                if (noteDropdown != null)
                {
                    noteDropdown.interactable = false;
                }
                break;

            case 5:
                backpack.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);
                highlightarrow?.SetActive(true);
                highlightzone2?.SetActive(true);
                if (dragScript2 != null)
                {
                    dragScript2.enabled = true;
                    dragScript2.hedeftag = "dropzone2";
                }
                break;

            case 6:
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);
                notepadPanel?.SetActive(false);

                if (noteDropdown2 != null)
                {
                    noteDropdown2.ClearOptions();
                    noteDropdown2.AddOptions(new List<string> { "Seçiniz", "daha çok", "daha az" });
                    noteDropdown2.value = 0;
                }
                break;
            case 7:
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);
                break;

            case 8:
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);
                if (noteDropdown3 != null)
                {
                    noteDropdown3.ClearOptions();
                    noteDropdown3.AddOptions(new List<string> { "Seçiniz", "kütle", "basınç" });
                    noteDropdown3.value = 0;
                }
                break;

            case 9:
                secondActivityBG2?.SetActive(true);
                backpack?.SetActive(true);
                mudfloor?.SetActive(true);
                break;

            case 10:
                secondActivityBG2?.SetActive(true);
                backpack?.SetActive(true);
                mudfloor?.SetActive(true);
                break;

            case 11:
                secondActivityBG2?.SetActive(true);
                olcer2?.SetActive(true);
                backpack?.SetActive(true);
                mudfloor?.SetActive(true);
                break;

            case 12:
                secondActivityBG2?.SetActive(true);
                mudfloor?.SetActive(true);
                olcer2?.SetActive(true);
                backpack?.SetActive(true);
                basincvalueText.SetActive(true);
                kuvvetInputField.interactable = false;
                yuzeyInputField.interactable = false;
                if (noteDropdown4 != null)
                {
                    noteDropdown4.ClearOptions();
                    noteDropdown4.AddOptions(new List<string> { "Seçiniz", "Ağırlık", "Kuvvet" });
                    noteDropdown4.value = 0;
                }
                if (noteDropdown5 != null)
                {
                    noteDropdown5.ClearOptions();
                    noteDropdown5.AddOptions(new List<string> { "Seçiniz", "Kütle", "Yüzey Alanı" });
                    noteDropdown5.value = 0;
                }
                break;


            case 13:
                secondActivityBG2?.SetActive(true);
                olcer2?.SetActive(true);
                mudfloor?.SetActive(true);
                backpack?.SetActive(true);
                basincvalueText.SetActive(true);
                kuvvetInputField.interactable = false;
                yuzeyInputField.interactable = false;
                break;

            case 14:
                firstActivityBG?.SetActive(true);
                break;

            case 15:
                firstActivityBG?.SetActive(true);
                badgePopup?.SetActive(true);
                break;
        }

        if (kontrolEtBt != null)
            kontrolEtBt.SetActive(sceneID == 3 || sceneID == 6 || sceneID == 8 || sceneID == 11 || sceneID == 12);

        if (ileriButonu != null)
            ileriButonu.SetActive(sceneID != 2 && sceneID != 5);

        if (geriButonu != null)
            geriButonu.SetActive(sceneID > 0);
        SetNoteStates(id);

    }
    public void OnCorrectDrop()
    {
        if (sceneID == 2) isDrag1Completed = true;
        if (sceneID == 5) isDrag2Completed = true;

        sceneID++;
        SetDialogue(sceneID);
    }

    public void OnNextButtonClicked()
    {
        sceneID++;
        SetDialogue(sceneID);
    }

    public void OnBackButtonClicked()
    {
        if (sceneID > 0)
        {
            sceneID--;
            SetDialogue(sceneID);

            if (sceneID == 2) isDrag1Completed = false;
            if (sceneID == 5) isDrag2Completed = false;
        }
        else
        {
            secondActivityCanvas.SetActive(false);
            firstActivityCanvas.SetActive(true);
            Debug.Log("İlk aktiviteye geri dönülüyor...");
        }
    }

    public void ToggleNotepad()
    {
        if (notepadPanel != null)
        {
            notepadPanel.SetActive(!notepadPanel.activeSelf);
        }
    }
    public void CheckNoteValues()
    {
        if (sceneID == 3)
        {
            if (noteDropdown == null || noteDropdown.options.Count == 0)
            {
                negativePopup?.SetActive(true);
                return;
            }

            string selected = noteDropdown.options[noteDropdown.value].text.ToLower();

            if (selected == "kuvvet")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 6)
        {
            string selected2 = noteDropdown2.options[noteDropdown2.value].text.ToLower();

            if (selected2 == "daha az")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 8)
        {
            string selected3 = noteDropdown3.options[noteDropdown3.value].text.ToLower();

            if (selected3 == "basınç")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 11)
        {
            string val1 = kuvvetInputField.text.Trim();
            string val2 = yuzeyInputField.text.Trim();

            if (val1 == "80" && val2 == "2")
            {

                sceneID++;
                SetDialogue(sceneID);

            }
            else
            {
                if (negativePopup2 != null)
                    negativePopup2.SetActive(true);
            }
        }
        else if (sceneID == 12)
        {
            string selected4 = noteDropdown4.options[noteDropdown4.value].text.ToLower();
            string selected5 = noteDropdown5.options[noteDropdown5.value].text.ToLower();

            if (selected4 == "kuvvet" && selected5 == "yüzey alanı")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
    }
    private void SetNoteStates(int id)
    {
        if (noteDropdownObj1 != null)
        {
            bool shouldBeVisible1 = id >= 3 && id != 11;
            noteDropdownObj1.SetActive(shouldBeVisible1);

            if (noteDropdown != null)
                noteDropdown.interactable = (id == 3);
        }

        if (noteDropdownObj2 != null)
        {
            bool shouldBeVisible2 = id >= 6 && id != 11;
            noteDropdownObj2.SetActive(shouldBeVisible2);

            if (noteDropdown2 != null)
                noteDropdown2.interactable = (id == 6);
        }
        if (noteDropdownObj3 != null)
        {
            bool shouldBeVisible3 = id >= 8 && id != 11;
            noteDropdownObj3.SetActive(shouldBeVisible3);

            if (noteDropdown3 != null)
                noteDropdown3.interactable = (id == 8);
        }
        if (noteDropdownObj4 != null)
        {
            bool shouldBeVisible4 = id >=12 ;
            noteDropdownObj4.SetActive(shouldBeVisible4);

            if (noteDropdown4 != null)
                noteDropdown4.interactable = (id == 12);
            if (noteDropdown5 != null)
                noteDropdown5.interactable = (id == 12);
        }

        bool showNotesAsText = (id == 11);

        noteText1?.SetActive(showNotesAsText);
        noteText2?.SetActive(showNotesAsText);
        noteText3?.SetActive(showNotesAsText);
        noteText4?.SetActive(showNotesAsText);

    }
    public void CloseNegativePopup()
    {
        if (negativePopup != null)
            negativePopup.SetActive(false);

    }
    public void CloseNotepad()
    {
        if (notepadPanel != null)
            notepadPanel.SetActive(false);
    }
    public void CloseNegativePopupSec()
    {
        if (negativePopup2 != null)
            negativePopup2.SetActive(false);

    }
    public void CloseBadgePopup()
    {
        if (badgePopup != null)
            badgePopup.SetActive(false);

    }
}