using HuangD.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChaotingDetail : MonoBehaviour
{
    public OfficeChaotingItem defaultMainItem;
    public OfficeChaotingItem defaultBranshItem;

    // Start is called before the first frame update
    void Start()
    {
        defaultMainItem.gameObject.SetActive(false);
        defaultBranshItem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateItems(defaultMainItem, Global.session.chaoting.mainOffices);
        UpdateItems(defaultBranshItem, Global.session.chaoting.branchOffices);
    }

    private void UpdateItems(OfficeChaotingItem defaultItem, IEnumerable<IOffice> offices)
    {
        var container = defaultItem.transform.parent;
        
        var items = container.GetComponentsInChildren<OfficeChaotingItem>().Where(x=>x!= defaultItem);

        var needRemveItems = items.Where(x => !offices.Contains(x.obj)).ToArray();
        var needAddObjs = offices.Except(items.Select(x => x.obj)).ToArray();

        foreach(var item in needRemveItems)
        {
            Destroy(item.gameObject);
        }

        foreach(var obj in needAddObjs)
        {
            var item = Instantiate(defaultItem, container).GetComponent<OfficeChaotingItem>();
            item.obj = obj;
            item.gameObject.SetActive(true);
        }
    }
}
