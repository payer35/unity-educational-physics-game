using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class FifthActManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public List<string> activityDialogues;

    public GameObject fifthActivityCanvas;
    public GameObject fourthActivityCanvas;
    public GameObject sixthActivityCanvas;

    public GameObject fourthactivity_bg;
    public GameObject fifthactivity_bg;
    public GameObject kontrolEtBt;
    public GameObject ileriButonu;
    public GameObject geriButonu;
    public GameObject badgeBt;
    public GameObject blur;
    public GameObject notepadPanel;
    public GameObject balloon;
    public GameObject balloonstatic;
    public GameObject ruler3;
    public GameObject negativePopup;
    public GameObject noteText1;
    public TMP_InputField note1IF;
    public GameObject noteText2;
    public TMP_InputField note2IF;
    public GameObject noteText3;
    public TMP_Dropdown dropdown1;
    public TMP_Dropdown dropdown2;
    public GameObject badgePopup;
    public GameObject rankPopup;

    private Animator balloonAnimator;
    private Animator ruler3Animator;
    private Vector3 ruler3StartPos;



    public int sceneID = 0;

    private void Start()
    {
        if (fifthActivityCanvas != null)
            fifthActivityCanvas.SetActive(true);

        SetDialogue(sceneID);

        if (balloon != null)
            balloonAnimator = balloon.GetComponent<Animator>();

        if (ruler3 != null)
            ruler3Animator = ruler3.GetComponent<Animator>();
    }

    private void ResetSceneObjects()
    {
        fourthactivity_bg.SetActive(false);
        fifthactivity_bg.SetActive(false );
        kontrolEtBt?.SetActive(false);
        balloon?.SetActive(false);
        balloonstatic?.SetActive(false);
        ruler3?.SetActive(false);
        badgePopup?.SetActive(false);
        rankPopup.SetActive(false);
        blur.SetActive(false);
    }

    public void SetDialogue(int id)
    {

        SetNoteStates(id);
        ResetSceneObjects();

        if (id >= activityDialogues.Count)
        {
            fifthActivityCanvas?.SetActive(false);
            sixthActivityCanvas?.SetActive(true);
            Debug.Log("Fourth activity bitti.");
            return;
        }


        if (dialogueText != null)
            dialogueText.text = activityDialogues[id];

        switch (id)
        {
            case 0:
                notepadPanel?.SetActive(false);
                fourthactivity_bg.SetActive(true);
                break;
            case 1:
                fourthactivity_bg.SetActive(true);
                balloonstatic?.SetActive(true);
                break;

            case 2:
                fourthactivity_bg.SetActive(true);
                balloon?.SetActive(true);
                ruler3?.SetActive(true);
                blur.SetActive(true);

                balloonAnimator?.SetTrigger("playOnce");
                ruler3Animator?.SetTrigger("playOnce");
                break;

            case 3:
                fourthactivity_bg.SetActive(true);
                balloonstatic?.SetActive(true);
                break;

            case 4:
                fourthactivity_bg?.SetActive(false);
                fifthactivity_bg?.SetActive(true);
                if (balloonstatic != null)
                {
                    balloonstatic.SetActive(true);
                    balloonstatic.transform.localScale = new Vector3(1.2f, 1.2f, 1f); //localscale kodunu internetten buldum, animasyonla değil kodla boyut büyütmem gerekiyordu. 
                }
                break;
            case 5:
                badgePopup.SetActive(true);
                fifthactivity_bg?.SetActive(true);
                balloonstatic.SetActive(true);
                break;
            case 6:
                fifthactivity_bg?.SetActive(true);
                balloonstatic?.SetActive(true);

                break;
            case 7:
                fifthactivity_bg?.SetActive(true);
                blur.SetActive(true);

                if (balloon != null)
                {
                    balloon.SetActive(true);
                    balloonAnimator?.SetTrigger("playSecond");
                }

                if (ruler3 != null)
                {
                    ruler3.SetActive(true);

                    if (ruler3Animator != null)
                        ruler3Animator.enabled = false;

                    RectTransform rt = ruler3.GetComponent<RectTransform>();
                    if (rt != null)
                        rt.anchoredPosition = new Vector2(172.699997f, -6.9000001f);

                    ruler3.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

                    if (ruler3Animator != null)
                    {
                        ruler3Animator.enabled = true;
                        ruler3Animator.Rebind();
                        ruler3Animator.Update(0f);
                        ruler3Animator.SetTrigger("playOnce");
                    }
                }
                    break;
                case 8:
                    fifthactivity_bg?.SetActive(true);
                    balloonstatic.SetActive(true);
                    break;
                case 9:
                    fifthactivity_bg?.SetActive(true);
                    balloonstatic.SetActive(true);
                    break;
                case 10:
                    balloonstatic.SetActive(true);
                    fifthactivity_bg?.SetActive(true);
                    break;
                case 11:
                    rankPopup.SetActive(true);
                    balloonstatic.SetActive(true);
                    fifthactivity_bg?.SetActive(true);
                    break;
                case 12:
                    balloonstatic.SetActive(true);
                    fifthactivity_bg?.SetActive(true);
                    break;
        }
        badgeBt?.SetActive(id >= 5);
        kontrolEtBt?.SetActive(id == 2 || id == 7 || id == 8);
        ileriButonu?.SetActive(true);
        geriButonu?.SetActive(sceneID > 0);
    }
    private void SetNoteStates(int id)
    {
        bool isScene2 = id == 2;

        noteText1?.SetActive(id >=2);

        if (note1IF != null)
            note1IF.interactable = isScene2;

        bool isScene7 = id == 7;
        bool isScene8 = id == 8;

        noteText2?.SetActive(id >= 7);
        noteText3?.SetActive(id >= 8);

        if (note2IF != null)
            note2IF.interactable = isScene7;

        if (dropdown1 != null)
            dropdown1.interactable = isScene8;

        if (dropdown2 != null)
            dropdown2.interactable = isScene8;

        if (isScene8)
        {
            dropdown1.ClearOptions();
            dropdown1.AddOptions(new List<string> { "Seçiniz", "artarken", "azalırken" });
            dropdown1.value = 0;

            dropdown2.ClearOptions();
            dropdown2.AddOptions(new List<string> { "Seçiniz", "arttı", "azaldı" });
            dropdown2.value = 0;
        }
    }

    public void CheckNoteValues()
    {
        if (sceneID == 2)
        {
            string val = note1IF.text.Trim();

            if (val == "7")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        else if (sceneID == 7)
        {
            string val = note2IF.text.Trim();
            if (val == "10")
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
            string d1 = dropdown1.options[dropdown1.value].text.Trim().ToLower();
            string d2 = dropdown2.options[dropdown2.value].text.Trim().ToLower();

            bool dropdownsCorrect = (d1 == "azalırken" && d2 == "arttı");

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
        else
        {
            fifthActivityCanvas?.SetActive(false);
            fourthActivityCanvas?.SetActive(true);
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
        if (negativePopup != null)
            negativePopup.SetActive(false);
    }
    public void CloseBadgePopup()
    {
        if (badgePopup != null)
            badgePopup.SetActive(false);

    }
    public void CloseRankPopup()
    {
        if (rankPopup != null)
            rankPopup.SetActive(false);

    }
    public void CloseNotepad()
    {
        if (notepadPanel != null)
            notepadPanel.SetActive(false);

    }
}