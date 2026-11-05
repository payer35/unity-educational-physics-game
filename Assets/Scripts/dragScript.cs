using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragScript : MonoBehaviour
{
    private Camera maincam;
    private Vector3 startpos;

    public string hedeftag = "";
    public string matchStatus = "bos";

    private bool isCompleted = false;
    private bool isDragging = false;

    public FirstActivityManager manager;

    void Start()
    {
        maincam = Camera.main;
        startpos = transform.position;
    }

    void Update()
    {
        if (!enabled) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit != null && hit.gameObject == gameObject)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging && !isCompleted)
        {
            Vector3 mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            OnMouseUp();
        }
    }
    public void SetStartPosition(Vector3 newStartPos)
    {
        startpos = newStartPos;
    }

    private void OnMouseUp()
    {
        if (manager == null || manager.sceneID != 3)
            return;

        if (matchStatus == "dogru")
        {
            Debug.Log("Doğru yere bırakıldı!");
            isCompleted = true;
            manager.OnCorrectDrop();
        }
        else
        {
            Debug.Log("Yanlış yere bırakıldı, geri dönülüyor.");
            basadon();
        }

        matchStatus = "bos";
    }

    public void ResetDragState()
    {
        isCompleted = false;
        matchStatus = "bos";
        isDragging = false;
    }

    public void basadon()
    {
        transform.position = startpos;
    }

    GameObject icindeoldugumobje = null;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == hedeftag)
        {
            icindeoldugumobje = collision.gameObject;
            matchStatus = "dogru";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == icindeoldugumobje)
        {
            icindeoldugumobje = null;
            matchStatus = "bos";
        }
    }
}
