using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartyContainer : MonoBehaviour
{
    public PartyItem defaultItem;

    // Start is called before the first frame update
    void Start()
    {
        defaultItem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateItems(defaultItem, Global.session.parties);
    }

    private void UpdateItems(PartyItem defaultItem, IEnumerable<IParty> party)
    {
        var container = defaultItem.transform.parent;

        var items = container.GetComponentsInChildren<PartyItem>();

        var needRemveItems = items.Where(x => !party.Contains(x.obj)).ToArray();
        var needAddObjs = party.Except(items.Select(x => x.obj)).ToArray();

        foreach (var item in needRemveItems)
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in needAddObjs)
        {
            var item = Instantiate(defaultItem, container).GetComponent<PartyItem>();
            item.obj = obj;
            item.gameObject.SetActive(true);
        }
    }
}
