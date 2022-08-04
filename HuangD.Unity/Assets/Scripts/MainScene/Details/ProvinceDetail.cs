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
    public GameObject popTaxLevelContainer;
    public BufferContainer bufferContainer;
    public TaxLevelContainer taxLevelContainer;

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

            if(_obj != null)
            {
                taxLevelContainer.province = obj;
                taxLevelContainer.objs = Global.modder.defs.popTaxLevelDef.taxLevelEffectGroups;
            }

            this.gameObject.SetActive(obj != null);
        }
    }

    //private Toggle[] taxLevels;

    private IProvince _obj;

    //public void OnTaxLevelChanged(IProvince.PopTaxLevel popTaxLevel)
    //{
    //    obj.popTaxLevel = popTaxLevel;
    //}

    // Start is called before the first frame update
    void Start()
    {
        obj = null;

        //taxLevels = popTaxLevelContainer.GetComponentsInChildren<Toggle>();

        //foreach (var level in taxLevels)
        //{
        //    level.onValueChanged.AddListener((isOn) =>
        //    {
        //        if(!isOn)
        //        {
        //            return;
        //        }

        //        var curr = taxLevels.SingleOrDefault(x => x.isOn);
        //        obj.popTaxLevel = Enum.Parse<IProvince.PopTaxLevel>(curr.name);
        //    });
        //}


        popTax.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = $"基础值    {obj.popTax.baseValue}\n"
                         + String.Join("\n", obj.popTax.effects.Select(x => $"{x.desc}    {x.value:+0;-#}%"))
            };
        };

        liveliHood.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = $"基础值    {obj.livelihood.baseValue}\n"
                         + String.Join("\n", obj.livelihood.effects.Select(x => $"{x.desc}    {x.value:+0;-#}%"))
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
        liveliHood.value = obj.livelihood.Value;

        //var currLevel = taxLevels.SingleOrDefault(x => x.name == obj.popTaxLevel.ToString());
        //if(!currLevel.isOn)
        //{
        //    currLevel.isOn = true;
        //}

        bufferContainer.Upate(obj.buffers);
    }
}
