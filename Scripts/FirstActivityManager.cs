using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class FirstActivityDialogueElement
{
    [TextArea(2, 5)]
    public string dialogueText;
}

public class FirstActivityManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public List<FirstActivityDialogueElement> activityDialogues;

    public GameObject firstActivityCanvas;
    public GameObject introductionCanvas;
    public GameObject secondActivityCanvas;

    public GameObject backpack;
    public GameObject dinamometer;
    public GameObject dropzone;
    public GameObject dinamoPanel;

    public GameObject ileriBt;
    public GameObject kontrolEtBt;

    public FirstNoteController noteInputController;

    public dragScript backpackDragScript;

    public GameObject bagarea_panel;
    public GameObject ruler;
    public GameObject olcer;
    public Animator RulerAnimController;
    public TMP_InputField kisaInputField;
    public TMP_InputField uzunInputField;
    public GameObject alanvalueText;

    public GameObject negativePopup2;
    public GameObject negativePopup3;
    public GameObject blur;

    public int sceneID = 0;

    private Vector3 rulerStartPos;
    private Quaternion rulerStartRotation;
    private Vector3 startpos;

    private void Start()
    {
        if (activityDialogues.Count > 0)
        {
            SetDialogue(sceneID);
        }
        if (startpos == Vector3.zero)
        {
            startpos = backpack.transform.position;
        }

        backpack.transform.position = startpos;

        if (backpackDragScript != null)
        {
            backpackDragScript.SetStartPosition(startpos);
        }

        if (backpack != null) backpack.SetActive(false);
        if (dinamometer != null) dinamometer.SetActive(false);
        if (dropzone != null) dropzone.SetActive(false);
        if (dinamoPanel != null) dinamoPanel.SetActive(false);
        if (kontrolEtBt != null) kontrolEtBt.SetActive(false);

        if (bagarea_panel != null) bagarea_panel.SetActive(false);
        if (ruler != null) ruler.SetActive(false);
        if (olcer != null) olcer.SetActive(false);
        if (alanvalueText != null) alanvalueText.SetActive(false);
        if (kisaInputField != null) kisaInputField.interactable = false;
        if (uzunInputField != null) uzunInputField.interactable = false;

        if (ruler != null)
            rulerStartPos = ruler.transform.position;
            rulerStartRotation = ruler.transform.rotation;

        if (negativePopup3 != null)
            negativePopup3.SetActive(false);

        if (secondActivityCanvas != null)
            secondActivityCanvas.SetActive(false);
    }

    public void SetDialogue(int id)
    {
        if (id >= activityDialogues.Count)
        {
            firstActivityCanvas.SetActive(false);
            secondActivityCanvas.SetActive(true);
            return;
        }

        string text = activityDialogues[id].dialogueText;
        if (!string.IsNullOrEmpty(UserData.playerName))
            text = text.Replace("[name]", UserData.playerName);
        dialogueText.text = text;

        kontrolEtBt.SetActive(false);
        kisaInputField.interactable = false;
        uzunInputField.interactable = false;
        if (backpackDragScript != null) backpackDragScript.enabled = false;
        alanvalueText.SetActive(false);

        switch (id)
        {
            case 0:
                if (noteInputController != null)
                    noteInputController.SetNoteContentVisible(false);
                blur.SetActive(false);
                break;

            case 1:
                backpack.SetActive(true);
                dinamometer.SetActive(true);
                dropzone.SetActive(true);
                dinamoPanel.SetActive(false);
                blur.SetActive(true);
                if (noteInputController != null)
                    noteInputController.SetNoteContentVisible(false);
                break;

            case 2:
                backpack.SetActive(true);
                dinamometer.SetActive(true);
                dropzone.SetActive(true);
                dinamoPanel.SetActive(false);
                blur.SetActive(true);

                if (noteInputController != null)
                    noteInputController.SetNoteContentVisible(false);
                break;

            case 3:
                ileriBt.SetActive(false);
                backpack.SetActive(true);
                dinamometer.SetActive(true);
                dropzone.SetActive(true);
                blur.SetActive(false);

                if (backpackDragScript != null)
                {
                    backpack.transform.position = startpos;
                    backpackDragScript.SetStartPosition(startpos);

                    backpackDragScript.enabled = true;
                    backpackDragScript.ResetDragState();

                }

                dinamoPanel.SetActive(false);

                if (noteInputController != null)
                    noteInputController.SetNoteContentVisible(false);

                break;

            case 4:
                ileriBt.SetActive(true);
                backpack.SetActive(true);
                dinamometer.SetActive(true);
                dropzone.SetActive(true);
                dinamoPanel.SetActive(true);
                kontrolEtBt.SetActive(true);
                noteInputController.SetNoteContentVisible(true);
                break;

            case 5:
                backpack.SetActive(true);
                dinamometer.SetActive(true);
                dropzone.SetActive(true);
                dinamoPanel.SetActive(true);
                noteInputController.SetNoteContentVisible(true);
                break;

            case 6:
                backpack.SetActive(false);
                dinamometer.SetActive(false);
                dinamoPanel.SetActive(false);

                noteInputController.SetNoteContentVisible(true);
                break;

            case 7:
                backpack.SetActive(false);
                break;

            case 8:
                bagarea_panel.SetActive(true);
                ruler.SetActive(true);
                olcer.SetActive(true);
                ruler.transform.position = rulerStartPos;
                ruler.transform.rotation = rulerStartRotation;
                kisaInputField.interactable = true;
                backpack.SetActive(false);
                kontrolEtBt.SetActive(true);

                if (ruler != null)
                {

                    Animator anima = ruler.GetComponent<Animator>();
                    if (anima != null)
                    {
                        anima.Rebind();
                        anima.Update(0f);
                        anima.enabled = false;
                    }
                }
                break;

            case 9:
                bagarea_panel.SetActive(true);
                ruler.SetActive(true);
                olcer.SetActive(true);
                uzunInputField.interactable = true;
                backpack.SetActive(false);
                kontrolEtBt.SetActive(true);
                Animator anim = ruler.GetComponent<Animator>();
                if (anim != null)
                {
                    anim.enabled = true;
                    anim.Play("rulertransformation", 0, 0f);
                }
                break;

            case 10:
                bagarea_panel.SetActive(true);
                ruler.SetActive(true);
                olcer.SetActive(true);
                alanvalueText.SetActive(true);
                kontrolEtBt.SetActive(true);
                noteInputController.SetNoteContentVisible(true);
                break;

            case 11:
                kontrolEtBt.SetActive(false);
                noteInputController.SetNoteContentVisible(true);
                alanvalueText.SetActive(true);
                break;
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
            firstActivityCanvas.SetActive(false);
            introductionCanvas.SetActive(true);

            IntroManager introManager = introductionCanvas.GetComponentInChildren<IntroManager>();
            if (introManager != null)
            {
                introManager.SetScene(3);
            }
        }
    }

    public void OnCorrectDrop()
    {
        if (dinamoPanel != null)
        {
            dinamoPanel.SetActive(true);
        }

        sceneID++;
        SetDialogue(sceneID);
    }
}




