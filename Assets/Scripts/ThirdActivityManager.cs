using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
#if UNITY_EDITOR
using UnityEditor.U2D.Animation;
#endif
[System.Serializable]
public class ThirdActivityDialogueElement
{
    [TextArea(2, 5)]
    public string dialogueText;
}

public class ThirdActivityManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public List<ThirdActivityDialogueElement> activityDialogues;

    public GameObject thirdActivityCanvas;
    public GameObject secondActivityCanvas;
    public GameObject fourthActivityCanvas;

    private Vector3 wood1StartPos;
    private Vector3 wood2StartPos;
    private Vector3 wood3StartPos;
    public GameObject Character;
    public GameObject characterPart1;
    public GameObject characterPart2;
    public GameObject ileriButonu;
    public GameObject geriButonu;
    public GameObject kontrolEtBt;
    public GameObject notepadPanel;
    public GameObject wood1;
    public GameObject wood2;
    public GameObject wood3;
    public GameObject woodborder1;
    public GameObject woodborder2;
    public GameObject woodborder3;
    private Vector2 wb1StartPos;
    private Vector2 wb2StartPos; 
    private Vector2 wb3StartPos;
    public GameObject noteDropdownObj1;
    public TMP_Dropdown noteDropdown1;
    public GameObject noteDropdownObj2;
    public TMP_Dropdown noteDropdown2;
    public GameObject noteDropdownObj3;
    public TMP_Dropdown noteDropdown3;
    public GameObject noteDropdownObj4;
    public TMP_Dropdown noteDropdown4;
    public TMP_Dropdown noteDropdown5;
    public GameObject negativePopup;
    public ThirdDrag dragScript3;
    private Vector3 initialPos3 = Vector3.zero;
    public GameObject backpack;
    public int sceneID = 0;

    private void Start()
    {
        if (thirdActivityCanvas != null)
            thirdActivityCanvas.SetActive(true);
        if (kontrolEtBt != null)
            kontrolEtBt.SetActive(false);
        if (wood1 != null)
            wood1StartPos = wood1.transform.position;
        if (wood2 != null)
            wood2StartPos = wood2.transform.position;
        if (wood3 != null)
            wood3StartPos = wood3.transform.position;
        wb1StartPos = woodborder1.GetComponent<RectTransform>().anchoredPosition;
        wb2StartPos = woodborder2.GetComponent<RectTransform>().anchoredPosition;
        wb3StartPos = woodborder3.GetComponent<RectTransform>().anchoredPosition;
        if (dragScript3 != null)
            initialPos3 = dragScript3.transform.position;
        SetDialogue(sceneID);
    }

    public void SetDialogue(int id)
    {
        sceneID = id;

        if (id >= activityDialogues.Count)
        {
            thirdActivityCanvas.SetActive(false);
            fourthActivityCanvas.SetActive(true);
            Debug.Log("Third activity bitti.");
            return;
        }

        string text = activityDialogues[id].dialogueText;
        if (!string.IsNullOrEmpty(UserData.playerName))
            text = text.Replace("[name]", UserData.playerName);

        if (dialogueText != null)
            dialogueText.text = text;

        ResetSceneObjects();

        switch (id)
        {
            case 0:
                notepadPanel?.SetActive(false);
                break;

            case 1:
                break;

            case 2:
                if (ileriButonu != null)
                    ileriButonu.SetActive(false);

                break;

            case 3:
                if (woodborder1 != null)
                    woodborder1.SetActive(true);
                woodborder1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-225f, -180f);
                if (wood1 != null)
                    wood1.transform.position = new Vector3(-5f, -4f, 0f);
                    SpriteRenderer sr = wood1.GetComponent<SpriteRenderer>();
                if (sr != null)
                    sr.sortingOrder = -1;

                if (Character != null)
                {
                    Vector3 currentPos = Character.transform.position;
                    Character.transform.position = new Vector3(currentPos.x, currentPos.y + 0.2f, currentPos.z);
                }
                break;

            case 4:
                if (ileriButonu != null)
                    ileriButonu.SetActive(false);
                if (noteDropdownObj1 != null)
                    noteDropdownObj1.SetActive(true);

                if (noteDropdown1 != null)
                    noteDropdown1.interactable = false;
                break;
            case 5:
                if (woodborder2 != null)
                    woodborder2.SetActive(true);
                woodborder2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-220.6f, -153.6f);
                if (sceneID >= 5 && wood1 != null)
                    wood1.transform.position = wood1StartPos;
                SpriteRenderer ar = wood1.GetComponent<SpriteRenderer>();
                    if (ar != null)
                        ar.sortingOrder = 0;

                if (Character != null)
                {
                    Vector3 currentPos = Character.transform.position;
                    Character.transform.position = new Vector3(currentPos.x, currentPos.y + 1.1f, currentPos.z);
                }

                var sr1 = characterPart1?.GetComponent<SpriteRenderer>();
                var sr2 = characterPart2?.GetComponent<SpriteRenderer>();

                if (sr1 != null) sr1.sortingOrder = 0;
                if (sr2 != null) sr2.sortingOrder = 0;

                break;
            case 6:
                if (ileriButonu != null)
                    ileriButonu.SetActive(false);
                if (sceneID >= 5 && wood1 != null)
                    wood1.transform.position = wood1StartPos;
                break;

            case 7:
                if (woodborder3 != null)
                    woodborder3.SetActive(true);
                woodborder3.GetComponent<RectTransform>().anchoredPosition = new Vector2(-223.9f, -131.6f);
                if (sceneID >= 5 && wood1 != null)
                    wood1.transform.position = wood1StartPos;

                if (Character != null)
                {
                    Vector3 currentPos = Character.transform.position;
                    Character.transform.position = new Vector3(currentPos.x, currentPos.y + 0.5f, currentPos.z);
                }
                break;

            case 8:
                if (ileriButonu != null)
                    ileriButonu.SetActive(false);

                if (sceneID >= 5 && wood1 != null)
                    wood1.transform.position = wood1StartPos;
                break;

            case 9:
                if (ileriButonu != null)
                    ileriButonu.SetActive(false);
                if (sceneID >= 5 && wood1 != null)
                    wood1.transform.position = wood1StartPos;
                backpack?.SetActive(true);

                if (dragScript3 != null)
                {
                    dragScript3.enabled = true;
                    dragScript3.hedeftag = "dropzone3";
                }
                break;

            case 10:
                if (woodborder3 != null)
                    woodborder3.SetActive(true);
                woodborder3.GetComponent<RectTransform>().anchoredPosition = new Vector2(-223.9f, -145.1f);
                if (ileriButonu != null)
                    ileriButonu.SetActive(false);
                if (noteDropdown4 != null)
                {
                    noteDropdown4.ClearOptions();

                    List<string> options = new List<string> { "Seçiniz", "arttığından", "azaldığından" };
                    noteDropdown4.AddOptions(options);

                    noteDropdown4.value = 0;
                    noteDropdown4.RefreshShownValue();
                    noteDropdown4.interactable = true;
                }

                if (noteDropdown5 != null)
                {
                    noteDropdown5.ClearOptions();

                    List<string> options = new List<string> { "Seçiniz", "daha çok", "daha az" };
                    noteDropdown5.AddOptions(options);

                    noteDropdown5.value = 0;
                    noteDropdown5.RefreshShownValue();
                    noteDropdown5.interactable = true;
                }
                backpack?.SetActive(true);

                if (dragScript3 != null)
                {
                    dragScript3.enabled = true;
                    dragScript3.hedeftag = "dropzone3";
                }
                Vector3 currentPosition = Character.transform.position;
                Character.transform.position = new Vector3(currentPosition.x, currentPosition.y + -0.3f, currentPosition.z);
                break;

            case 11:
                backpack?.SetActive(true);
                break;

            case 12:
                backpack?.SetActive(true);
                break;
        }
        if (ileriButonu != null && id != 2 && id != 4 && id != 6 && id != 8 && id != 9 && id != 10)
            ileriButonu.SetActive(true);

        if (geriButonu != null)
            geriButonu.SetActive(id > 0);

        if (kontrolEtBt != null)
            kontrolEtBt.SetActive(id == 3 || id == 5 || id == 7 || id == 10);

        if (sceneID == 5 && wood2 != null)
        {
            Vector3 current = wood2.transform.position;
            wood2.transform.position = new Vector3(current.x - 5.1f, current.y -0.20f, current.z);
        }

        if (sceneID > 6 && wood2 != null)
        {
            wood2.transform.position = wood2StartPos;
        }

        if (sceneID == 7 && wood3 != null)
        {
            Vector3 current = wood3.transform.position;
            wood3.transform.position = new Vector3(current.x - 7.8f, current.y, current.z);
        }
        if (sceneID == 10 && wood3 != null)
        {
            Vector3 current = wood3.transform.position;
            wood3.transform.position = new Vector3(current.x, current.y - 0.3f, current.z);
        }
        SetNoteStates(id);
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
            thirdActivityCanvas.SetActive(false);
            secondActivityCanvas.SetActive(true);
            Debug.Log("İkinci aktiviteye geri dönülüyor...");
        }
    }
    public void CloseNegativePopup()
    {
        if (negativePopup != null)
            negativePopup.SetActive(false);

    }
    private void ResetSceneObjects()
    {
        noteDropdownObj1?.SetActive(false);
        noteDropdownObj2?.SetActive(false);
        noteDropdownObj3?.SetActive(false);
        noteDropdownObj4?.SetActive(false);
        backpack?.SetActive(false);
        woodborder1?.SetActive(false);
        woodborder2?.SetActive(false);
        woodborder3?.SetActive(false);
        if (dragScript3 != null)
        {
            dragScript3.enabled = false;

            if (sceneID == 9)
            {
                if (initialPos3 == Vector3.zero)
                    initialPos3 = dragScript3.transform.position;

                dragScript3.ResetToPosition(initialPos3);
            }
        }

    }
    private void SetNoteStates(int id)
    {
        noteDropdownObj1?.SetActive(id >= 3);
        if (noteDropdown1 != null)
        {
            noteDropdown1.interactable = (id == 3);
            if (id == 3)
            {
                noteDropdown1.ClearOptions();
                noteDropdown1.AddOptions(new List<string> { "Seçiniz", "çok azı", "yarısı", "tamamı" });
                noteDropdown1.value = 0;
                noteDropdown1.RefreshShownValue();
            }
        }
        noteDropdownObj2?.SetActive(id >= 5);
        if (noteDropdown2 != null)
        {
            noteDropdown2.interactable = (id == 5);
            if (id == 5)
            {
                noteDropdown2.ClearOptions();
                noteDropdown2.AddOptions(new List<string> { "Seçiniz", "çok azı", "yarısı", "tamamı" });
                noteDropdown2.value = 0;
                noteDropdown2.RefreshShownValue();
            }
        }
        noteDropdownObj3?.SetActive(id >= 7);
        if (noteDropdown3 != null)
        {
            noteDropdown3.interactable = (id == 7);
            if (id == 7)
            {
                noteDropdown3.ClearOptions();
                noteDropdown3.AddOptions(new List<string> { "Seçiniz", "çok azı", "yarısı", "tamamı" });
                noteDropdown3.value = 0;
                noteDropdown3.RefreshShownValue();
            }
        }

        noteDropdownObj4?.SetActive(id >= 10);
        if (noteDropdown4 != null)
        {
            noteDropdown4.interactable = (id == 10);
            if (id == 10)
            {
                noteDropdown4.ClearOptions();
                noteDropdown4.AddOptions(new List<string> { "Seçiniz", "arttığından", "azaldığından" });
                noteDropdown4.value = 0;
                noteDropdown4.RefreshShownValue();
            }
        }
        if (noteDropdown5 != null)
        {
            noteDropdown5.interactable = (id == 10);
            if (id == 10)
            {
                noteDropdown5.ClearOptions();
                noteDropdown5.AddOptions(new List<string> { "Seçiniz", "daha çok", "daha az" });
                noteDropdown5.value = 0;
                noteDropdown5.RefreshShownValue();
            }
        }
    }


    public void ToggleNotepad()
    {
        if (notepadPanel != null)
        {
            notepadPanel.SetActive(!notepadPanel.activeSelf);
        }
    }
    public void OnCorrectDrop()
    {
        sceneID++;
        SetDialogue(sceneID);
    }

    public void CloseNotepad()
    {
        if (notepadPanel != null)
            notepadPanel.SetActive(false);
    }
    public void CheckNoteValues()
    {
        if (sceneID == 3)
        {
            if (noteDropdown1 == null || noteDropdown1.options.Count == 0)
            {
                negativePopup?.SetActive(true);
                return;
            }

            string selected = noteDropdown1.options[noteDropdown1.value].text.ToLower();

            if (selected == "tamamı")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        if (sceneID == 5)
        {
            if (noteDropdown2 == null || noteDropdown2.options.Count == 0)
            {
                negativePopup?.SetActive(true);
                return;
            }

            string selected = noteDropdown2.options[noteDropdown2.value].text.ToLower();

            if (selected == "yarısı")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        if (sceneID == 7)
        {
            if (noteDropdown3 == null || noteDropdown3.options.Count == 0)
            {
                negativePopup?.SetActive(true);
                return;
            }

            string selected = noteDropdown3.options[noteDropdown3.value].text.ToLower();

            if (selected == "çok azı")
            {
                sceneID++;
                SetDialogue(sceneID);
            }
            else
            {
                negativePopup?.SetActive(true);
            }
        }
        if (sceneID == 10)
        {
            string selected4 = noteDropdown4.options[noteDropdown4.value].text.ToLower();
            string selected5 = noteDropdown5.options[noteDropdown5.value].text.ToLower();

            if (selected4 == "arttığından" && selected5 == "daha çok")
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

}

