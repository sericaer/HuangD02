using HuangD.Commands;
using HuangD.Interfaces;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LaborLevelItem : MonoBehaviour
{
    public Text Label;
    public Toggle toggle;

    public ILaborLevelDef.Item obj;
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

            toggle.BindCommand(new CmdChangeLaborLevel(province, obj));

        }
    }

    private IProvince _province;
    void Start()
    {
        GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = $"{obj.level}:\n"
                 + String.Join("\n", obj.effectDefs.Select(x => $"{x.name}    {x.Value:+0;-#}%"))
            };
        };
    }

    private void FixedUpdate()
    {
        if (obj == null)
        {
            return;
        }

        Label.text = obj.level.ToString();
        toggle.isOn = obj.level == province.laborLevel;
    }
}