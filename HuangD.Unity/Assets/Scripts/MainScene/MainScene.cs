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
        Global.session = Session.Builder.Build(Global.customInit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
