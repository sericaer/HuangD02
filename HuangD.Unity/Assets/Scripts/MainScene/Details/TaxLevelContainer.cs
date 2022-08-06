using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaxLevelContainer : MonoBehaviour
{
    public TaxLevelItem defaultItem;

    private Transform container => defaultItem.transform.parent;

    public IProvince province
    {
        get
        {
            return _province;
        }
        set
        {
            _province = value;

            foreach (var obj in Global.modder.defs.popTaxLevelDef.taxLevelEffectGroups)
            {
                var item = Instantiate(defaultItem, container).GetComponent<TaxLevelItem>();
                item.obj = obj;
                item.province = province;
                item.gameObject.SetActive(true);
            }
        }
    }

    private IProvince _province;

    // Start is called before the first frame update
    void Start()
    {
        defaultItem.gameObject.SetActive(false);

        //var items = container.GetComponentsInChildren<TaxLevelItem>();

        //var levelDefs = Global.modder.defs.popTaxLevelDef.taxLevelEffectGroups;

        //var needRemveItems = items.Where(x => !levelDefs.Contains(x.obj)).ToArray();
        //var needAddObjs = levelDefs.Except(items.Select(x => x.obj)).ToArray();

        //foreach (var item in needRemveItems)
        //{
        //    Destroy(item.gameObject);
        //}

        //foreach (var obj in needAddObjs)
        //{
        //    var item = Instantiate(defaultItem, container).GetComponent<TaxLevelItem>();
        //    item.obj = obj;;
        //    item.gameObject.SetActive(true);
        //}
    }

    
}
