using HuangD.CustomInits;
using HuangD.Interfaces;
using HuangD.Sessions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public Canvas uiCanvas;

    public GameObject personDetailDialog;

    // Start is called before the first frame update
    void Start()
    {
        Global.session = Session.Builder.Build(Global.customInit, Global.modder.defs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTimeElapse()
    {
        Global.session.OnTimeElapse();
    }

    public void OnShowPersonDetail(IPerson person)
    {
        var dialog = Instantiate(personDetailDialog, uiCanvas.transform).GetComponent<PersonDetailDialog>();
        dialog.obj = person;
    }
}
