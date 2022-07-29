using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZhoujunDetail : MonoBehaviour
{
    public ProvinceItem defaultItem;

    // Start is called before the first frame update
    void Start()
    {
        defaultItem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateItems(defaultItem, Global.session.provinces);
    }

    private void UpdateItems(ProvinceItem defaultItem, IEnumerable<IProvince> provinces)
    {
        var container = defaultItem.transform.parent;

        var items = container.GetComponentsInChildren<ProvinceItem>();

        var needRemveItems = items.Where(x => !provinces.Contains(x.obj)).ToArray();
        var needAddObjs = provinces.Except(items.Select(x => x.obj)).ToArray();

        foreach (var item in needRemveItems)
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in needAddObjs)
        {
            var item = Instantiate(defaultItem, container).GetComponent<ProvinceItem>();
            item.obj = obj;
            item.gameObject.SetActive(true);
        }

    }
}
