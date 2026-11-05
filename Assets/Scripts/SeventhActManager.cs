using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class SeventhActManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public List<string> activityDialogues;

    public GameObject seventhActivityCanvas;
    public GameObject seventhactivity_bg;
    public GameObject seventhactivity_bg2;

    public GameObject ileriButonu;
    public GameObject geriButonu;
    public GameObject kontrolEtBt;
    public GameObject negativePopup;
    public GameObject notepadPanel;
    public GameObject badgePopup;
    public GameObject Character;
    public GameObject comparebottles;
    public GameObject form;
    public GameObject bottleSchema;
    public GameObject rankPanel;

    public GameObject noteText1;
    public GameObject noteText2;
    public GameObject noteText3;
    public GameObject noteText4;
    public GameObject noteText5;
    public GameObject noteText6;
    public GameObject noteText7;
    public GameObject noteText8;

    public TMP_Dropdown dropdown1;
    public TMP_Dropdown dropdown2;    
    public TMP_Dropdown dropdown3;
    public TMP_Dropdown dropdown4;
    public TMP_Dropdown dropdown5;
    public TMP_Dropdown dropdown6;
    public TMP_Dropdown dropdown7;
    public TMP_Dropdown dropdown8;
    public TMP_Dropdown dropdown9;
    public TMP_Dropdown dropdown10;
    public TMP_Dropdown dropdown11;
    public TMP_Dropdown dropdown12;

    public int sceneID = 0;

    void Start()
    {
        if (seventhActivityCanvas != null)
            seventhActivityCanvas.SetActive(true);

        SetDialogue(sceneID);
    }
    private void ResetSceneObjects()
    {
        form.SetActive(false);
        badgePopup.SetActive(false);    
        comparebottles.SetActive(false);
        rankPanel.SetActive(false);
        bottleSchema.SetActive(false);  
    }

    public void SetDialogue(int id)
    {
        if (id >= activityDialogues.Count)
        {
            seventhActivityCanvas.SetActive(false);
            return;
        }

        dialogueText.text = activityDialogues[id];

        ResetSceneObjects();
        SetNoteStates(id);

        switch (id)
        {
            case 0:
                notepadPanel.SetActive(false); 
                break;
            case 1:
                badgePopup.SetActive(true);
                break;

            case 2:

                break;

            case 3:
                seventhactivity_bg.SetActive(false);
                seventhactivity_bg2.SetActive(true);
                break;

            case 4:
                form.SetActive(true);

                break;
            case 5:
                bottleSchema.SetActive(true);
                form.SetActive(true);
                break;
            case 6:
                form.SetActive(true);
                comparebottles.SetActive(true);
                break;
            case 7:
                form.SetActive(true);
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                rankPanel.SetActive(true);
                break;

            default:

                break;
        }

        kontrolEtBt?.SetActive(id == 4 || id == 5 || id == 6 || id == 7);
        ileriButonu?.SetActive(!(id == 4 || id == 5 || id == 6 || id == 7 || id == 10));
        geriButonu?.SetActive(sceneID > 0);
    }

    public void SetNoteStates(int id)
    {
        bool isScene4 = (id == 4);
        bool isScene5 = (id == 5);
        bool isScene6 = (id == 6);
        bool isScene7 = (id == 7);

        noteText1?.SetActive(isScene4);
        noteText2?.SetActive(isScene4);
        noteText3?.SetActive(isScene4);

        noteText4?.SetActive(isScene5);

        noteText5?.SetActive(isScene6);

        noteText6?.SetActive(isScene7);
        noteText7?.SetActive(isScene7);
        noteText8?.SetActive(isScene7);

        if (dropdown1 != null)
        {
            dropdown1.gameObject.SetActive(isScene4);
            dropdown1.interactable = isScene4;
            if (isScene4)
            {
                dropdown1.ClearOptions();
                dropdown1.AddOptions(new List<string> { "Seçiniz","Yere Temas Eden Yüzey Alaný", "Basýnç",  "Aðýrlýk" });
                dropdown1.value = 0;
            }
        }
        if (dropdown2 != null)
        {
            dropdown2.gameObject.SetActive(isScene4);
            dropdown2.interactable = isScene4;
            if (isScene4)
            {
                dropdown2.ClearOptions();
                dropdown2.AddOptions(new List<string> { "Seçiniz", "Yere Temas Eden Yüzey Alaný","Basýnç", "Aðýrlýk" });
                dropdown2.value = 0;
            }
        }
        if (dropdown3 != null)
        {
            dropdown3.gameObject.SetActive(isScene4);
            dropdown3.interactable = isScene4;
            if (isScene4)
            {
                dropdown3.ClearOptions();
                dropdown3.AddOptions(new List<string> { "Seçiniz","Yere Temas Eden Yüzey Alaný", "Basýnç",  "Aðýrlýk" });
                dropdown3.value = 0;
            }
        }

        if (dropdown4 != null)
        {
            dropdown4.gameObject.SetActive(isScene5);
            dropdown4.interactable = isScene5;
            if (isScene5)
            {
                dropdown4.ClearOptions();
                dropdown4.AddOptions(new List<string> { "Seçiniz", "Yoðunluk", "Sývý Basýncý ", "Derinlik" });
                dropdown4.value = 0;
            }
        }
        if (dropdown5 != null)
        {
            dropdown5.gameObject.SetActive(isScene5);
            dropdown5.interactable = isScene5;
            if (isScene5)
            {
                dropdown5.ClearOptions();
                dropdown5.AddOptions(new List<string> { "Seçiniz", "Yoðunluk", "Sývý Basýncý ", "Derinlik" });
                dropdown5.value = 0;
            }
        }
        if (dropdown6 != null)
        {
            dropdown6.gameObject.SetActive(isScene5);
            dropdown6.interactable = isScene5;
            if (isScene5)
            {
                dropdown6.ClearOptions();
                dropdown6.AddOptions(new List<string> { "Seçiniz", "Yoðunluk", "Sývý Basýncý ", "Derinlik" });
                dropdown6.value = 0;
            }
        }

        if (dropdown7 != null)
        {
            dropdown7.gameObject.SetActive(isScene6);
            dropdown7.interactable = isScene6;
            if (isScene6)
            {
                dropdown7.ClearOptions();
                dropdown7.AddOptions(new List<string> { "Seçiniz", "Yoðunluk", "Sývý Basýncý ", "Derinlik" });
                dropdown7.value = 0;
            }
        }
        if (dropdown8 != null)
        {
            dropdown8.gameObject.SetActive(isScene6);
            dropdown8.interactable = isScene6;
            if (isScene6)
            {
                dropdown8.ClearOptions();
                dropdown8.AddOptions(new List<string> { "Seçiniz", "Yoðunluk", "Sývý Basýncý ", "Derinlik" });
                dropdown8.value = 0;
            }
        }
        if (dropdown9 != null)
        {
            dropdown9.gameObject.SetActive(isScene6);
            dropdown9.interactable = isScene6;
            if (isScene6)
            {
                dropdown9.ClearOptions();
                dropdown9.AddOptions(new List<string> { "Seçiniz", "Yoðunluk", "Sývý Basýncý ", "Derinlik" });
                dropdown9.value = 0;
            }
        }

        if (dropdown10 != null)
        {
            dropdown10.gameObject.SetActive(isScene7);
            dropdown10.interactable = isScene7;
            if (isScene7)
            {
                dropdown10.ClearOptions();
                dropdown10.AddOptions(new List<string> { "Seçiniz", "Deniz Seviyesinden Yükseklik", "Balon ", "Açýk Hava Basýncý" });
                dropdown10.value = 0;
            }
        }
        if (dropdown11 != null)
        {
            dropdown11.gameObject.SetActive(isScene7);
            dropdown11.interactable = isScene7;
            if (isScene7)
            {
                dropdown11.ClearOptions();
                dropdown11.AddOptions(new List<string> { "Seçiniz", "Deniz Seviyesinden Yükseklik", "Balon ", "Açýk Hava Basýncý" });
                dropdown11.value = 0;
            }
        }
        if (dropdown12 != null)
        {
            dropdown12.gameObject.SetActive(isScene7);
            dropdown12.interactable = isScene7;
            if (isScene7)
            {
                dropdown12.ClearOptions();
                dropdown12.AddOptions(new List<string> { "Seçiniz", "Deniz Seviyesinden Yükseklik", "Balon ", "Açýk Hava Basýncý" });
                dropdown12.value = 0;
            }
        }
    }

    public void CheckNoteValues()
    {
        if (sceneID == 4)
        {
            string d1 = dropdown1.options[dropdown1.value].text.Trim().ToLower();
            string d2 = dropdown2.options[dropdown2.value].text.Trim().ToLower();
            string d3 = dropdown3.options[dropdown3.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d1 == "basýnç" && d2 == "yere temas eden yüzey alaný" && d3 == "aðýrlýk");

            if (dropdownsCorrect)
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                Character.SetActive(false);
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 5)
        {
            string d4 = dropdown4.options[dropdown4.value].text.Trim().ToLower();
            string d5 = dropdown5.options[dropdown5.value].text.Trim().ToLower();
            string d6 = dropdown6.options[dropdown6.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d4 == "sývý basýncý" && d5 == "derinlik" && d6 == "yoðunluk");

            if (dropdownsCorrect)
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                Character.SetActive(false);
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 6)
        {
            string d7 = dropdown7.options[dropdown7.value].text.Trim().ToLower();
            string d8 = dropdown8.options[dropdown8.value].text.Trim().ToLower();
            string d9 = dropdown9.options[dropdown9.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d7 == "sývý basýncý" && d8 == "yoðunluk" && d9 == "derinlik");

            if (dropdownsCorrect)
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                Character.SetActive(false);
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 7)
        {
            string d10 = dropdown10.options[dropdown10.value].text.Trim().ToLower();
            string d11 = dropdown11.options[dropdown11.value].text.Trim().ToLower();
            string d12 = dropdown12.options[dropdown12.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d10 == "açýk hava basýncý" && d11 == "deniz seviyesinden yükseklik" && d12 == "balon");

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
        }
    }

    public void CloseNegativePopup()
    {
        negativePopup.SetActive(false);
    }
    public void ToggleNotepad()
    {
        Character.SetActive(!Character.activeSelf);
        if (notepadPanel != null)
        {

            notepadPanel.SetActive(!notepadPanel.activeSelf);
        }
    }
    public void ToggleBadge()
    {
        if (badgePopup != null)
        {
            badgePopup.SetActive(!badgePopup.activeSelf);
        }
    }

    public void CloseBadgePopup()
    {
        if (badgePopup != null)
            badgePopup.SetActive(false);

    }
    public void CloseNotepad()
    {
        Character.SetActive(true);
        if (notepadPanel != null)
            notepadPanel.SetActive(false);

    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Eðer oyun build alýnmýþsa (exe) uygulamayý tamamen kapat
        Application.Quit();
#endif
    }
}

