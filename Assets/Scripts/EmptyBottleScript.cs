using System.Collections;
using UnityEngine;

public class EmptyBottleDragScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 startPos;
    private Animator animator;

    public string matchStatus = "bos";
    private bool isCompleted = false;
    private GameObject currentTarget = null;

    private bool isDragging = false;

    public FourthActManager manager;

    void Start()
    {
        mainCam = Camera.main;
        startPos = transform.position;
        animator = GetComponent<Animator>();
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
    private void OnMouseDrag()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }

    private void OnMouseUp()
    {
        if (!enabled || isCompleted) return;

        isDragging = false;

        if (manager == null || (manager.sceneID != 6 && manager.sceneID != 11)) return;

        string expectedTag = "dropzone7";

        if (matchStatus == "dogru" && currentTarget != null && currentTarget.CompareTag(expectedTag))
        {
            Debug.Log("Bottle doðru yere býrakýldý!");
            isCompleted = true;

            if (animator != null)
            {
                animator.SetTrigger("playOnce");
                StartCoroutine(WaitAndAdvance());
            }
            else
            {
                manager.OnCorrectDrop();
                ResetDrag();
            }
        }
        else
        {
            Debug.Log("Yanlýþ yere býrakýldý.");
            ResetDrag();
        }

        matchStatus = "bos";
    }
    void OnMouseDown()
    {
        if (!enabled || isCompleted) return;
        isDragging = true;
    }
    private IEnumerator WaitAndAdvance()
    {
        yield return new WaitForSeconds(1f);
        manager.OnCorrectDrop();
        ResetDrag();
    }

    public void ResetDrag()
    {
        transform.position = startPos;
        transform.rotation = Quaternion.identity;
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

