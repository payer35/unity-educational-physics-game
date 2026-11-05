using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data;
using UnityEngine.TextCore.Text;

public class SixthActivityManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public List<string> activityDialogues;

    public GameObject sixthActivityCanvas;
    public GameObject seventhActivityCanvas;
    public GameObject kontrolEtBt;
    public GameObject ileriButonu;
    public GameObject geriButonu;
    public GameObject negativePopup;
    public GameObject highlight_arrow;
    public GameObject highlight_arrow2;
    public GameObject highlight_zone;
    public GameObject emptyhose;
    public GameObject waterhose;
    public GameObject bigrock;
    public GameObject smallrock;
    public GameObject notepadPanel;
    public GameObject badgePopup;
    public GameObject hydraulicjack;
    public GameObject noteText1;
    public GameObject noteText2;
    public TMP_Dropdown dropdown1;
    public TMP_Dropdown dropdown2;
    public TMP_Dropdown dropdown3;
    public GameObject hydraulicjackSchema;
    public GameObject hydraulic_head;
    public GameObject Character;
    public GameObject bgblur;


    public HydraulicDrag hydraulicjackDrag;



    public int sceneID = 0;

    private void Start()
    {
        if (sixthActivityCanvas != null)
            sixthActivityCanvas.SetActive(true);

        SetDialogue(sceneID);
    }

    private void ResetSceneObjects()
    {
        kontrolEtBt?.SetActive(false);
        highlight_arrow?.SetActive(false);
        highlight_arrow2?.SetActive(false);
        highlight_zone?.SetActive(false);
        emptyhose?.SetActive(false);
        waterhose?.SetActive(false);
        hydraulicjack?.SetActive(false);
        hydraulic_head?.SetActive(false);
        badgePopup?.SetActive(false);
        bgblur?.SetActive(false);
        if (hydraulicjackDrag != null)
            hydraulicjackDrag.enabled = false;
    }

    public void SetDialogue(int id)
    {
        ResetSceneObjects();
        SetNoteStates(id);

        if (id >= activityDialogues.Count)
        {
            seventhActivityCanvas.SetActive(true);
            sixthActivityCanvas?.SetActive(false);
            return;
        }

        if (dialogueText != null)
            dialogueText.text = activityDialogues[id];

        switch (id)
        {
            case 0:
                notepadPanel.SetActive(false);
                break;
            case 1:
                break;
            case 2:
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);

                if (hydraulicjackDrag != null)
                    hydraulicjackDrag.enabled = false;
                bgblur.SetActive(true);
                break;
            case 3:
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);

                if (hydraulicjackDrag != null)
                    hydraulicjackDrag.enabled = false;
                bgblur.SetActive(true);
                break;
            case 4:
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);

                if (hydraulicjackDrag != null)
                {
                    hydraulicjackDrag.SetStartPosition();
                    hydraulicjackDrag.enabled = true;
                    hydraulicjackDrag.ResetDrag();
                }
                highlight_arrow2?.SetActive(true);
                highlight_zone?.SetActive(true);
                break;
            case 5:
                hydraulicjack.GetComponent<RectTransform>().anchoredPosition = new Vector2(-112.2f, -95.1000061f);
                emptyhose.SetActive(true);
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);
                break;
            case 6:
                waterhose.SetActive(true);
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);
                break;
            case 7:
                highlight_arrow?.SetActive(true);
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);
                break;
            case 8:
                hydraulic_head?.SetActive(true);
                highlight_arrow?.SetActive(true);
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);
                break;
            case 9:
                if (bigrock != null)
                {
                    Animator rockAnim = bigrock.GetComponent<Animator>();
                    rockAnim?.SetTrigger("playRotate");
                }
                hydraulic_head?.SetActive(true);
                highlight_arrow?.SetActive(true);
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);
                break;
            case 10:
                if (bigrock != null)
                {
                    Animator rockAnim = bigrock.GetComponent<Animator>();
                    rockAnim?.SetTrigger("playOnce");
                }
                hydraulic_head?.SetActive(true);
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);
                break;
            case 11:
                if (Character != null)
                {
                    Animator anim = Character.GetComponent<Animator>();
                    anim?.SetTrigger("playOnce");
                }
                break;
            case 12:
                if (hydraulicjack != null)
                    hydraulicjack.SetActive(true);
                break;
        }


        if (hydraulic_head != null)
        {
            var anim = hydraulic_head.GetComponent<Animator>();

            if (id == 8)
            {
                anim?.SetTrigger("playHeader1");
            }
            else if (id == 9)
            {
                anim?.SetTrigger("playHeader2");
            }
            else if (id == 10)
            {
                anim?.SetTrigger("playHeader3");
            }
        }
        kontrolEtBt?.SetActive(id == 11);
        ileriButonu?.SetActive(!(id == 4 || id == 7 || id == 8 || id == 9 || id == 11));
        geriButonu?.SetActive(sceneID > 0);
    }

    public void CheckNoteValues()
    {
        if (sceneID == 11)
        {
            string d1 = dropdown1.options[dropdown1.value].text.Trim().ToLower();
            string d2 = dropdown2.options[dropdown2.value].text.Trim().ToLower();
            string d3 = dropdown3.options[dropdown3.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d1 == "daha büyük" && d2 == "daha büyük" && d3 == "sývý basýncý");

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
    }

    public void SetNoteStates(int id)
    {
        bool isScene11 = id == 11;

        noteText1?.SetActive(id >= 11);
        noteText2?.SetActive(id >= 11);
        hydraulicjackSchema.SetActive(id >= 11);
        if (dropdown1 != null) dropdown1.interactable = isScene11;
        if (dropdown2 != null) dropdown2.interactable = isScene11;
        if (dropdown3 != null) dropdown3.interactable = isScene11;

        if (isScene11)
        {
            dropdown1.ClearOptions();
            dropdown1.AddOptions(new List<string> { "Seçiniz", "daha büyük", "daha küçük" });
            dropdown1.value = 0;

            dropdown2.ClearOptions();
            dropdown2.AddOptions(new List<string> { "Seçiniz", "daha büyük", "daha küçük" });
            dropdown2.value = 0;

            dropdown3.ClearOptions();
            dropdown3.AddOptions(new List<string> { "Seçiniz", "katý basýncý", "sývý basýncý" });
            dropdown3.value = 0;
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
        else
        {
            sixthActivityCanvas?.SetActive(false);
        }
    }

    public void OnCorrectDrop()
    {
        sceneID++;
        SetDialogue(sceneID);
    }

    public void ToggleNotepad()
    {
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
    public void CloseNegativePopup()
    {
        Character.SetActive(true);
        if (negativePopup != null)
            negativePopup.SetActive(false);
    }
    public void CloseBadgePopup()
    {
        if (badgePopup != null)
            badgePopup.SetActive(false);

    }
    public void CloseNotepad()
    {
        if (notepadPanel != null)
            notepadPanel.SetActive(false);

    }
}

