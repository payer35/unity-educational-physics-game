using System.Collections;
using UnityEngine;

public class NeedleDragScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 startPos;
    private Vector3 originalStartPos;

    public string matchStatus = "bos";
    private bool isCompleted = false;
    private GameObject currentTarget = null;

    private bool isDragging = false;

    public FourthActManager manager;

    void Start()
    {
        mainCam = Camera.main;
        startPos = transform.position;
        originalStartPos = transform.position;
    }

    void Update()
    {
        if (!enabled || isCompleted) return;

        if (isDragging)
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        }
    }
    public void SetOriginalStartPosition()
    {
        originalStartPos = transform.position;
        startPos = originalStartPos;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }

    private void OnMouseUp()
    {
        if (!enabled || isCompleted) return;

        isDragging = false;

        if (manager == null || manager.sceneID < 3 || manager.sceneID > 5) return;

        string expectedTag = "dropzone" + (manager.sceneID + 1).ToString();

        if (matchStatus == "dogru" && currentTarget != null && currentTarget.CompareTag(expectedTag))
        {
            Debug.Log("Needle doðru yere býrakýldý!");
            isCompleted = true;

            StartCoroutine(AnimateNeedleBounce());
        }
        else
        {
            Debug.Log("Yanlýþ yere býrakýldý, geri dönülüyor.");
            ResetDrag();
        }

        matchStatus = "bos";
    }

    void OnMouseDown()
    {
        if (!enabled || isCompleted) return;
        isDragging = true;
    }
    //drag sonrasý animasyon oynatmayý denemiþtim, iðnenin hareketinden animasyonda anchored position olduðu için drag engelleniyomuþ bu yöntemi yapay zeka ile buldum ve yazdým.
    private IEnumerator AnimateNeedleBounce()
    {
        Vector3 originalPos = transform.position;
        Vector3 leftPos = originalPos + new Vector3(-0.3f, 0f, 0f);

        float duration = 0.3f;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(originalPos, leftPos, t);
            yield return null;
        }

        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(leftPos, originalPos, t);
            yield return null;
        }

        manager.OnCorrectDrop();
        ResetDrag();
    }

    public void ResetDrag()
    {
        transform.position = originalStartPos;
        isCompleted = false;
        matchStatus = "bos";
    }

    public void ResetToPosition(Vector3 pos)
    {
        transform.position = pos;
        startPos = pos;
        isCompleted = false;
        matchStatus = "bos";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentTarget = collision.gameObject;
        matchStatus = "dogru";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTarget)
        {
            currentTarget = null;
            matchStatus = "bos";
        }
    }
}
