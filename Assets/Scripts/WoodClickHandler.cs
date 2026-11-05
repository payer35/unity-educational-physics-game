using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneTransition
{
    public int requiredSceneID = 0;
    public int targetSceneID = 0;
}
//tıklamaya göre sahne geçişini basit mantıkla yazmıştım fakat düzgün çalışmadığı için bunu yapay zeka önerdi
public class WoodClickHandler : MonoBehaviour
{
    public ThirdActivityManager manager;

    [SerializeField]
    private List<SceneTransition> transitions = new List<SceneTransition>();

    private void OnMouseDown()
    {
        if (manager == null) return;

        foreach (var t in transitions)    
        {
            if (manager.sceneID == t.requiredSceneID)
            {
                manager.sceneID = t.targetSceneID;
                manager.SetDialogue(t.targetSceneID);
                break;
            }
        }
    }
}

