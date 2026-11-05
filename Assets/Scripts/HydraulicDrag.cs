using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraulicDrag : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 startPos;
    private bool isCompleted = false;
    private GameObject currentTarget = null;

    public string hedeftag = "dropzone8";
    public string matchStatus = "bos";

    public SixthActivityManager manager;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (!enabled) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos); //aldýðým hatayý çözememiþtim, sizin kodlarýnýzda internetten bulduðum bu kýsmý kullandým.
            if (hit != null && hit.gameObject == gameObject)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            OnMouseUp();
            isDragging = false;
        }

        if (isDragging && !isCompleted)
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    public void SetStartPosition()
    {
        startPos = transform.position;
    }
    private bool isDragging = false;

    private void OnMouseUp()
    {
        if (manager == null || manager.sceneID != 4)
            return;

        if (matchStatus == "dogru")
        {
            isCompleted = true;
            manager.OnCorrectDrop();
        }
        else
        {
            Debug.Log("HydraulicJack: Yanlýþ yere býrakýldý, geri dönülüyor.");
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