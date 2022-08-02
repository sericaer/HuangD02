using HuangD.Interfaces;
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

    public IProvince province
    {
        get
        {
            return _province;
        }
        set
        {
            _province = value;
        }
    }

    private IEnumerable<IPopTaxLevelDef.TaxLevelEffectGroup> _levelDefs;
    private IProvince _province;

    // Start is called before the first frame update
    void Start()
    {
        defaultItem.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        container.GetComponentsInChildren<TaxLevelItem>().Single(x => x.obj.popTaxLevel == province.popTaxLevel).toggle.isOn = true;
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
