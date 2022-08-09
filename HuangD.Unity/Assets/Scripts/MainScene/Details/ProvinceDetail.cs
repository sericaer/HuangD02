using HuangD.Interfaces;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceDetail : MonoBehaviour
{
    public Text Label;
    public Text masterOffice;
    public Text masterName;
    public Text popCount;
    public Text popTax;
    public Text militaryCurr;
    public Text militaryMax;
    public GameObject popTaxLevelContainer;
    public BufferContainer bufferContainer;
    public TaxLevelContainer taxLevelContainer;
    public MilitaryLevelContainer MilitaryLevelContainer;
    public LaborLevelContainer LaborLevelContainer;

    public Slider liveliHood;

    public IProvince obj
    {
        get
        {
            return _obj;
        }
        set
        {
            _obj = value;
            taxLevelContainer.province = obj;
            MilitaryLevelContainer.province = obj;
            LaborLevelContainer.province = obj;
        }
    }


    private IProvince _obj;


    // Start is called before the first frame update
    void Start()
    {
        popTax.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = $"基础值    {obj.popTax.baseValue/100.0}\n"
                         + String.Join("\n", obj.popTax.effects.Select(x => $"{x.desc}    {x.value:+0;-#}%"))
            };
        };

        liveliHood.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = $"基础值    {obj.livelihood.baseValue/100.0}\n"
                         + String.Join("\n", obj.livelihood.effects.Select(x => $"{x.desc}    {x.value:+0;-#}%"))
            };
        };

        popCount.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText =String.Join("\n", obj.popCountChange.effects.Select(x => $"{x.desc}    {x.value:+0.00;-#.##}%"))
            };
        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(obj == null)
        {
            return;
        }

        Label.text = obj.name;
        masterOffice.text = obj.masterOffice.name;
        masterName.text = obj.masterOffice?.currPerson?.fullName;
        popCount.text = (obj.popCount/100.0).ToString();
        popTax.text = (obj.popTax.Value/100.0).ToString();
        militaryCurr.text = (obj.military.currValue / 100.0).ToString();
        militaryMax.text = (obj.military.maxValue / 100.0).ToString();
        liveliHood.value = obj.livelihood.Value;

        bufferContainer.Upate(obj.buffers);
    }
}
