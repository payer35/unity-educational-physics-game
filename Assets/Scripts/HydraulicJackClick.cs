using UnityEngine;

public class HydraulicJackClick: MonoBehaviour
{
    public SixthActivityManager manager;

    private void OnMouseDown()
    {
        if (manager == null) return;

        int id = manager.sceneID;
        if (id == 7 || id == 8 || id == 9)
        {
            manager.sceneID++;
            manager.SetDialogue(manager.sceneID);
        }
    }
}
