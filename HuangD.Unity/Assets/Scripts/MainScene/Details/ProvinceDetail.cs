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

    public IProvince obj;

    // Start is called before the first frame update
    void Start()
    {
        var taxLevels = popTaxLevelContainer.GetComponentsInChildren<Toggle>();
        foreach(var level in taxLevels)
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Label.text = obj?.name;
        masterOffice.text = obj?.masterOffice.name;
        masterName.text = obj?.masterOffice?.currPerson?.fullName;
        popCount.text = obj?.popCount.ToString();
        popTax.text = obj?.popTax.Value.ToString();
    }
}
