using HuangD.Interfaces;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BufferItem : MonoBehaviour
{
    public Text label;

    public IBuffer obj;

    void Start()
    {
        GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo() { bodyText = String.Join("\n", obj.def.effects.Select(x => $"{x.name}    {x.Value}")) };
        };    
    }

    void FixedUpdate()
    {
        label.text = obj.def.name;
    }
}
