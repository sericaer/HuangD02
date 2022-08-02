﻿using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaxLevelContainer : MonoBehaviour
{
    public TaxLevelItem defaultItem;

    private Transform container => defaultItem.transform.parent;
    public IEnumerable<IPopTaxLevelDef.TaxLevelEffectGroup>  objs
    {
        get
        {
            return _levelDefs;
        }
        set
        {
            _levelDefs = value;

            UpdateItems(defaultItem, objs);
        }
    }

    public IProvince province;

    private IEnumerable<IPopTaxLevelDef.TaxLevelEffectGroup> _levelDefs;

    // Start is called before the first frame update
    void Start()
    {
        defaultItem.gameObject.SetActive(false);
    }

    private void UpdateItems(TaxLevelItem defaultItem, IEnumerable<IPopTaxLevelDef.TaxLevelEffectGroup> levelDefs)
    {
        var items = container.GetComponentsInChildren<TaxLevelItem>();

        var needRemveItems = items.Where(x => !levelDefs.Contains(x.obj)).ToArray();
        var needAddObjs = levelDefs.Except(items.Select(x => x.obj)).ToArray();

        foreach (var item in needRemveItems)
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in needAddObjs)
        {
            var item = Instantiate(defaultItem, container).GetComponent<TaxLevelItem>();
            item.obj = obj;
            item.toggle.isOn = province.popTaxLevel == obj.popTaxLevel;

            item.toggle.onValueChanged.AddListener((isOn) =>
            {
                if(!isOn)
                {
                    return;
                }

                province.popTaxLevel = obj.popTaxLevel;
            });

            item.gameObject.SetActive(true);
        }
    }
}
