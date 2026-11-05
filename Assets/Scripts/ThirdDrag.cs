using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDrag : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 startPos;
    private bool isDragging = false;

    public string hedeftag = "";
    public string matchStatus = "bos";

    private bool isCompleted = false;
    private GameObject currentTarget = null;

    public ThirdActivityManager manager;

    void Start()
    {
        mainCam = Camera.main;
        startPos = transform.position;
    }

    void Update()
    {
        if (!isDragging || isCompleted) return;

        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    void OnMouseDown()
    {
        if (!enabled || isCompleted) return;

        isDragging = true;
    }

    void OnMouseUp()
    {
        if (!enabled || isCompleted) return;

        isDragging = false;

        if (manager == null || manager.sceneID != 9)
            return;

        if (matchStatus == "dogru")
        {
            Debug.Log("ThirdActivity: Doðru yere býrakýldý!");
            isCompleted = true;
            manager.OnCorrectDrop();
        }
        else
        {
            Debug.Log("ThirdActivity: Yanlýþ yere býrakýldý, geri dönülüyor.");
            ResetDrag();
        }

        matchStatus = "bos";
    }

    public void ResetDrag()
    {
        transform.position = startPos;
        isCompleted = false;
        matchStatus = "bos";
    }

    public void ResetToPosition(Vector3 pos)
    {
        transform.position = pos;
        isCompleted = false;
        matchStatus = "bos";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(hedeftag))
        {
            currentTarget = collision.gameObject;
            matchStatus = "dogru";
        }
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