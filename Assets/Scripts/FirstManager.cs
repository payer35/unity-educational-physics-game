using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstManager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject Introduction;

    public void OnStartButtonClicked()
    {
        StartScreen.SetActive(false);
        Introduction.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
