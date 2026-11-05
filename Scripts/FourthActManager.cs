using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Windows;

[System.Serializable]
public class FourthActivityDialogueElement
{
    [TextArea(2, 5)]
    public string dialogueText;
}

public class FourthActManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public List<FourthActivityDialogueElement> activityDialogues;

    public GameObject fourthActivityCanvas;
    public GameObject thirdActivityCanvas;
    public GameObject fifthActivityCanvas;

    public GameObject kontrolEtBt;
    public GameObject ileriButonu;
    public GameObject geriButonu;
    public GameObject notepadPanel;
    public GameObject blur;
    public GameObject needle;
    public GameObject needlebox;
    public GameObject emptybottle1;
    public GameObject emptybottle2;
    public GameObject waterbottle;
    public GameObject muddybottle;
    public GameObject comparebottles;
    public GameObject header1;
    public GameObject header2;
    public GameObject noteText1;
    public GameObject noteText2;
    public GameObject noteText3;
    public GameObject noteText4;
    public GameObject noteText5;
    public GameObject noteText6;
    public GameObject noteText7;
    public GameObject noteText8;
    public GameObject noteText9;
    public GameObject cups;
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;
    public TMP_InputField input4;
    public TMP_InputField input5;
    public TMP_InputField input6;
    public TMP_Dropdown dropdown2;
    public TMP_Dropdown dropdown3;
    public TMP_Dropdown dropdown5;
    public TMP_Dropdown dropdown6;
    public TMP_Dropdown dropdown7;
    public GameObject negativePopup;
    public NeedleDragScript needleDragScript;
    public GameObject highlightzone3;

    public GameObject ruler2;

    [SerializeField] private Vector3 ruler2StartPos;
    private Animator ruler2Animator;

    public int sceneID = 0;

    private void Start()
    {
        if (fourthActivityCanvas != null)
            fourthActivityCanvas.SetActive(true);

        if (dialogueText != null && activityDialogues.Count > 0)
            SetDialogue(sceneID);

        if (ruler2 != null)
        {
            ruler2Animator = ruler2.GetComponent<Animator>();
        }
    }

    public void SetDialogue(int id)
    {
        if (id >= activityDialogues.Count)
        {
            fourthActivityCanvas?.SetActive(false);
            fifthActivityCanvas?.SetActive(true);
            Debug.Log("Fourth activity bitti.");
            return;
        }

        string text = activityDialogues[id].dialogueText;
        if (!string.IsNullOrEmpty(UserData.playerName))
            text = text.Replace("[name]", UserData.playerName);

        if (dialogueText != null)
            dialogueText.text = text;

        ResetSceneObjects();
        SetNoteStates(id);

        switch (id)
        {
            case 0:
                if (notepadPanel != null)
                    notepadPanel.SetActive(false);
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                needle.SetActive(true);
                needlebox.SetActive(true);
                needleDragScript.SetOriginalStartPosition();
                needleDragScript.enabled = true;
                needleDragScript.ResetDrag();
                if (needle != null)
                    needle.SetActive(true);
                if (emptybottle1 != null)
                    emptybottle1.SetActive(true);
                if (emptybottle2 != null)
                    emptybottle2.SetActive(false);
                break;

            case 4:
                needle.SetActive(true);
                needlebox.SetActive(true);
                needleDragScript.enabled = true;
                needleDragScript.ResetDrag();
                if (needle != null)
                    needle.SetActive(true);
                if (emptybottle1 != null)
                    emptybottle1.SetActive(true);
                if (emptybottle2 != null)
                    emptybottle2.SetActive(false);
                break;

            case 5:
                needle.SetActive(true);
                needlebox.SetActive(true);
                needleDragScript.enabled = true;
                needleDragScript.ResetDrag();
                if (needle != null)
                    needle.SetActive(true);
                if (emptybottle1 != null)
                    emptybottle1.SetActive(true);
                if (emptybottle2 != null)
                    emptybottle2.SetActive(false);
                break;
            case 6:
                if (emptybottle2 != null)
                    emptybottle2.SetActive(true);
                if (highlightzone3 != null)
                    highlightzone3.SetActive(true);
                break;
            case 7:
                if (ruler2 != null)
                {
                    ruler2.SetActive(true);

                    if (ruler2StartPos == Vector3.zero)
                        ruler2StartPos = ruler2.transform.position;

                    ruler2.transform.position = ruler2StartPos;
                    ruler2.transform.rotation = Quaternion.identity;

                    if (ruler2Animator != null)
                    {
                        ruler2Animator.Rebind();
                        ruler2Animator.Update(0f);
                    }
                }
                if (waterbottle != null)
                    waterbottle.SetActive(true);
                if (cups != null)
                    cups.SetActive(true);
                break;

            case 8:
                if (ruler2 != null)
                {
                    ruler2.SetActive(true);
                    if (ruler2Animator != null)
                    {
                        ruler2Animator.SetTrigger("playOnce");
                    }
                }
                if (waterbottle != null)
                    waterbottle.SetActive(true);
                if (blur != null)
                    blur.SetActive(true);
                if (cups != null)
                    cups.SetActive(true);
                break;
            case 11:
                if (emptybottle2 != null)
                {
                    emptybottle2.SetActive(true);
                    emptybottle2.GetComponent<EmptyBottleDragScript>().enabled = true;
                    emptybottle2.GetComponent<EmptyBottleDragScript>().ResetDrag();
                }
                if (highlightzone3 != null)
                    highlightzone3.SetActive(true);
                break;
            case 12:
                muddybottle?.SetActive(true);

                if (ruler2 != null)
                {
                    ruler2.SetActive(true);

                    if (ruler2Animator != null)
                        ruler2Animator.enabled = false;

                    RectTransform rt = ruler2.GetComponent<RectTransform>();
                    if (rt != null)
                        rt.anchoredPosition = new Vector3(-226.199997f, -14.8999996f, 0);

                    ruler2.transform.rotation = Quaternion.Euler(0f, 0f, -90f);

                }
                break;
            case 13:
                muddybottle?.SetActive(true);
                if (blur != null)
                    blur.SetActive(true);

                if (ruler2 != null)
                {
                    if (ruler2Animator != null)
                        ruler2Animator.enabled = true;
                    ruler2.SetActive(true);
                    ruler2Animator?.SetTrigger("playOnce");
                }
                break;
            case 14:
            case 15:
                break;
            case 16:
                comparebottles?.SetActive(true);
                break;
        }

        if (kontrolEtBt != null)
            kontrolEtBt.SetActive(id == 8 || id == 9 || id == 13 || id == 14);


        if (ileriButonu != null)
            ileriButonu.SetActive(!(id == 3 || id == 4 || id == 5 || id == 6 || id == 8 || id == 9 || id == 11));

        if (geriButonu != null)
            geriButonu.SetActive(id > 0);
    }

    private void ResetSceneObjects()
    {

        if (kontrolEtBt != null)
            kontrolEtBt.SetActive(false);
        if (negativePopup != null)
            negativePopup.SetActive(false);
        if (needle != null)
            needle.SetActive(false);
        if (needlebox != null)
            needlebox.SetActive(false);
        if (emptybottle1 != null)
            emptybottle1.SetActive(false);
        if (emptybottle2 != null)
            emptybottle2.SetActive(false);
        if (ruler2 != null) 
            ruler2.SetActive(false);
        if (waterbottle != null)
            waterbottle.SetActive(false);
        if (muddybottle != null) 
            muddybottle.SetActive(false);
        if (comparebottles != null)
            comparebottles.SetActive(false);
        if (blur != null)
            blur.SetActive(false);
        if (highlightzone3 != null)
            highlightzone3.SetActive(false);
        if (cups != null)
            cups.SetActive(false);
    }
    public void CheckNoteValues()
    {
        if (sceneID == 8)
        {
            string val1 = input1.text.Trim();
            string val2 = input2.text.Trim();
            string val3 = input3.text.Trim();

            bool inputsCorrect = (val1 == "5" && val2 == "10" && val3 == "20");

            if (inputsCorrect)
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 9)
        {
            string d2 = dropdown2.options[dropdown2.value].text.Trim().ToLower();
            string d3 = dropdown3.options[dropdown3.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d2 == "daha uzağa" && d3 == "arttı");

            if (dropdownsCorrect)
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 13)
        {
            string val4 = input4.text.Trim();
            string val5 = input5.text.Trim();
            string val6 = input6.text.Trim();

            bool inputsCorrect = (val4 == "10" && val5 == "20" && val6 == "30");

            if (inputsCorrect)
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 14)
        {
            string d5 = dropdown5.options[dropdown5.value].text.Trim().ToLower();
            string d6 = dropdown6.options[dropdown6.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d5 == "daha uzağa" && d6 == "arttı");

            if (dropdownsCorrect)
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 16)
        {
            string d7 = dropdown7.options[dropdown6.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d7 == "artar");

            if (dropdownsCorrect)
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
        bool isScene8 = id == 8;
        bool isScene9 = id == 9;
        header1?.SetActive(isScene8 || isScene9);
        noteText1?.SetActive(isScene8 || isScene9);
        noteText2?.SetActive(isScene8 || isScene9);
        noteText3?.SetActive(isScene8 || isScene9);

        input1.interactable = isScene8;
        input2.interactable = isScene8;
        input3.interactable = isScene8;

        noteText4?.SetActive(isScene9);

        dropdown2.interactable = isScene9;
        dropdown3.interactable = isScene9;

        if (isScene9)
        {
            dropdown2.ClearOptions();
            dropdown2.AddOptions(new List<string> { "Seçiniz", "daha yakına", "daha uzağa" });
            dropdown2.value = 0;

            dropdown3.ClearOptions();
            dropdown3.AddOptions(new List<string> { "Seçiniz", "arttı", "azaldı" });
            dropdown3.value = 0;
        }
        bool isScene13 = id == 13;
        bool isScene14 = id == 14;

        header2?.SetActive(isScene13 || isScene14);
        noteText5?.SetActive(isScene13 || isScene14);
        noteText6?.SetActive(isScene13 || isScene14);
        noteText7?.SetActive(isScene13 || isScene14);

        input4.interactable = isScene13;
        input5.interactable = isScene13;
        input6.interactable = isScene13;

        noteText8?.SetActive(isScene14);

        dropdown5.interactable = isScene14;
        dropdown6.interactable = isScene14;

        if (isScene14)
        {
            dropdown5.ClearOptions();
            dropdown5.AddOptions(new List<string> { "Seçiniz", "daha yakına", "daha uzağa" });
            dropdown5.value = 0;

            dropdown6.ClearOptions();
            dropdown6.AddOptions(new List<string> { "Seçiniz", "arttı", "azaldı" });
            dropdown6.value = 0;
        }
        bool isScene16 = id == 16;

        noteText9?.SetActive(isScene16);

        dropdown7.interactable = isScene16;

        if (isScene16)
        {
            dropdown7.ClearOptions();
            dropdown7.AddOptions(new List<string> { "Seçiniz", "azalır", "artar" });
            dropdown7.value = 0;

        }
    }
    public void OnNextButtonClicked()
    {
        sceneID++;
        SetDialogue(sceneID);
    }

    public void OnCorrectDrop()
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
        }
        else
        {
            fourthActivityCanvas.SetActive(false);
            thirdActivityCanvas.SetActive(true);
            Debug.Log("Üçüncü aktiviteye geri dönülüyor...");
        }
    }

    public void ToggleNotepad()
    {
        if (notepadPanel != null)
        {
            notepadPanel.SetActive(!notepadPanel.activeSelf);
        }
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
}