using HuangD.CustomInits;
using HuangD.Sessions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
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
}
