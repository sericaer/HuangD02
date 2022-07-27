using HuangD.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HougongDetail : MonoBehaviour
{
    public OfficeHougongItem defaultHouItem;
    public OfficeHougongItem defaultGuiItem;
    public OfficeHougongItem defaultFeiItem;
    public OfficeHougongItem defaultBinItem;

    // Start is called before the first frame update
    void Start()
    {
        defaultHouItem.gameObject.SetActive(false);
        defaultGuiItem.gameObject.SetActive(false);
        defaultFeiItem.gameObject.SetActive(false);
        defaultBinItem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateItems(defaultHouItem, Global.session.hougong.hous);
        UpdateItems(defaultGuiItem, Global.session.hougong.guis);
        UpdateItems(defaultFeiItem, Global.session.hougong.feis);
        UpdateItems(defaultBinItem, Global.session.hougong.bins);
    }

    private void UpdateItems(OfficeHougongItem defaultItem, IEnumerable<IOffice> offices)
    {
        var container = defaultItem.transform.parent;
        
        var items = container.GetComponentsInChildren<OfficeHougongItem>().Where(x=>x!= defaultItem);

        var needRemveItems = items.Where(x => !offices.Contains(x.obj)).ToArray();
        var needAddObjs = offices.Except(items.Select(x => x.obj)).ToArray();

        foreach(var item in needRemveItems)
        {
            Destroy(item.gameObject);
        }

        foreach(var obj in needAddObjs)
        {
            var item = Instantiate(defaultItem, container).GetComponent<OfficeHougongItem>();
            item.obj = obj;
            item.gameObject.SetActive(true);
        }
    }
}
