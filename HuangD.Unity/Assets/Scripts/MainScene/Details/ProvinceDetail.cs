using HuangD.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
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

    public IProvince obj
    {
        get
        {
            return _obj;
        }
        set
        {
            _obj = value;
            this.gameObject.SetActive(obj != null);
        }
    }

    private Toggle[] taxLevels;

    private IProvince _obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = null;

        taxLevels = popTaxLevelContainer.GetComponentsInChildren<Toggle>();

        foreach (var level in taxLevels)
        {
            level.onValueChanged.AddListener((isOn) =>
            {
                if(!isOn)
                {
                    return;
                }

                var curr = taxLevels.SingleOrDefault(x => x.isOn);
                obj.popTaxLevel = Enum.Parse<IProvince.PopTaxLevel>(curr.name);
            });
        }


        popTax.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = $"����ֵ {obj.popTax.baseValue}\n"
                         + String.Join("\n", obj.popTax.effects.Select(x => $"{x.desc} {x.value:+0;-#}%"))
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

        Label.text = obj?.name;
        masterOffice.text = obj?.masterOffice.name;
        masterName.text = obj?.masterOffice?.currPerson?.fullName;
        popCount.text = obj?.popCount.ToString();
        popTax.text = obj?.popTax.Value.ToString();

        var currLevel = taxLevels.SingleOrDefault(x => x.name == obj.popTaxLevel.ToString());
        if(!currLevel.isOn)
        {
            currLevel.isOn = true;
        }
    }
}
