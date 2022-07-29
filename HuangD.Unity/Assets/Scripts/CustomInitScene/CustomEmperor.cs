using HuangD.CustomInits;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomEmperor : CustomInitPanel
{
    public InputField familyName;
    public InputField givenName;

    private void Start()
    {
        OnRandomFamily();
        OnRandomGiven();
    }

    public void OnRandomFamily()
    {
        string[] familyNames = Global.modder.defs.personDef.familyNames;

        familyName.text = familyNames.ElementAt(Random.Range(0, familyNames.Length));
    }

    public void OnRandomGiven()
    {
        string[] givenNames = Global.modder.defs.personDef.givenNames;

        givenName.text = givenNames.ElementAt(Random.Range(0, givenNames.Length));
    }

    public override void GetInitData(ref CustomInit customInit)
    {
        customInit.emperor = new EmperorInit()
        {
            familyName = familyName.text,
            givenName = givenName.text
        };
    }
}