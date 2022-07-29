using HuangD.CustomInits;
using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomInitScene : MonoBehaviour
{
    public CustomInitContainer customInitContainer;

    public Button next;
    public Button finished;

    // Start is called before the first frame update
    void Start()
    {
        next.onClick.AddListener(OnNext);
        finished.onClick.AddListener(OnFinished);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        next.gameObject.SetActive(!customInitContainer.isShowFinishPanel);
    }

    public void OnFinished()
    {
        var customInit = new CustomInit();

        var panels = new List<CustomInitPanel>();
        customInitContainer.GetComponentsInChildren(true, panels);
        foreach (var customInitPanel in panels)
        {
            customInitPanel.GetInitData(ref customInit);
        }

        Global.customInit = customInit;

        SceneManager.LoadScene(nameof(MainScene), LoadSceneMode.Single);
    }

    public void OnNext()
    {
        customInitContainer.OnNext();
    }
}
