using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDragScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 startPos;

    public string hedeftag = "";
    public string matchStatus = "bos";

    private bool isCompleted = false;
    private bool isDragging = false;
    private GameObject currentTarget = null;

    public SecondActivityManager manager;

    void Start()
    {
        mainCam = Camera.main;
        startPos = transform.position;
    }

    void Update()
    {
        if (!enabled) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit != null && hit.gameObject == gameObject)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging && !isCompleted)
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            OnMouseUp();
        }
    }

    private void OnMouseUp()
    {
        if (manager == null || (manager.sceneID != 2 && manager.sceneID != 5))
            return;

        if (matchStatus == "dogru")
        {
            Debug.Log("SecondActivity: Doğru yere bırakıldı!");
            isCompleted = true;
            manager.OnCorrectDrop();
        }
        else
        {
            Debug.Log("SecondActivity: Yanlış yere bırakıldı, geri dönülüyor.");
            ResetDrag();
        }

        matchStatus = "bos";
    }

    public void ResetDrag()
    {
        transform.position = startPos;
        isCompleted = false;
        matchStatus = "bos";
        isDragging = false;
    }

    public void ResetToPosition(Vector3 pos)
    {
        transform.position = pos;
        isCompleted = false;
        matchStatus = "bos";
        isDragging = false;
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
