using HuangD.CustomInits;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomInitScene : MonoBehaviour
{
    public CustomEmperor customEmperorPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFinished()
    {
        var customInit = new CustomInit();
        customInit.emperor = new EmperorInit()
        {
            familyName = customEmperorPanel.familyName.text,
            givenName = customEmperorPanel.givenName.text
        };

        Global.customInit = customInit;

        SceneManager.LoadScene(nameof(MainScene), LoadSceneMode.Single);
    }
}
