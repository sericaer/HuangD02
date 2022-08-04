using HuangD.CustomInits;
using HuangD.Interfaces;
using HuangD.Sessions;
using LogicSimEngine.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public Canvas uiCanvas;

    public GameObject personDetailDialog;
    public GameObject eventDialog;
    public TimeSpeedControl timeSpeedControl;

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
        StartCoroutine(TimeElapseProcess());
        ;
    }

    private IEnumerator TimeElapseProcess()
    {
        timeSpeedControl.isSysPause = true;

        foreach (var eventObj in Global.session.OnTimeElapse())
        {
            var dialog = OnShowEventDialog(eventObj);

            yield return new WaitUntil(() => dialog.isDestroy);
        }

        timeSpeedControl.isSysPause = false;
    }

    private EventDialog OnShowEventDialog(IEvent eventObj)
    {
        var dialog = Instantiate(eventDialog, uiCanvas.transform).GetComponent<EventDialog>();
        dialog.obj = eventObj;

        return dialog;
    }

    public void OnShowPersonDetail(IPerson person)
    {
        var dialog = Instantiate(personDetailDialog, uiCanvas.transform).GetComponent<PersonDetailDialog>();
        dialog.obj = person;
    }
}
