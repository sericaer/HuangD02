using HuangD.Interfaces;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TaxLevelItem : MonoBehaviour
{
    public Text Label;
    public Toggle toggle;

    public IPopTaxLevelDef.TaxLevelEffectGroup obj;


    void Start()
    {
        GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = $"{obj.popTaxLevel}:\n"
                            + String.Join("\n", obj.effectDefs.Select(x => $"{x.name}    {x.Value:+0;-#}%"))
            };
        };

    }

    private void FixedUpdate()
    {
        if(obj == null)
        {
            return;
        }

        Label.text = obj.popTaxLevel.ToString(); 
    }
}