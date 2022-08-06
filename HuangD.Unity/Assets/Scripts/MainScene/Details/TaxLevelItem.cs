﻿using HuangD.Commands;
using HuangD.Interfaces;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TaxLevelItem : MonoBehaviour
{
    public Text Label;
    public Toggle toggle;
    public Image Lock;

    public IPopTaxLevelDef.TaxLevelEffectGroup obj;
    public IProvince province
    {
        get
        {
            return _province;
        }
        set
        {
            _province = value;

            FixedUpdate();

            toggle.BindCommand(new CmdChangePopTaxLevel(province, obj));
             
        }
    }

    private IProvince _province;
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

        //toggle.onValueChanged.AddListener((isOn) =>
        //{
        //    if (!isOn)
        //    {
        //        return;
        //    }

        //    province.popTaxLevel = obj.popTaxLevel;
        //});
    }

    private void FixedUpdate()
    {
        if(obj == null)
        {
            return;
        }

        Label.text = obj.popTaxLevel.ToString();
        toggle.isOn = obj.popTaxLevel == province.popTaxLevel;
    }
}