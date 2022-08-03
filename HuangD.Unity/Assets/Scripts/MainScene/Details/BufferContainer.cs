using HuangD.Interfaces;
using LogicSimEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BufferContainer : MonoBehaviour
{
    public BufferItem defaultItem;

    public void Upate(IEnumerable<IBuffer> buffers)
    {
        var container = defaultItem.transform.parent;

        var items = container.GetComponentsInChildren<BufferItem>().Where(x => x != defaultItem);

        var needRemveItems = items.Where(x => !buffers.Contains(x.obj)).ToArray();
        var needAddObjs = buffers.Except(items.Select(x => x.obj)).ToArray();

        foreach (var item in needRemveItems)
        {
            Destroy(item.gameObject);
        }

        foreach (var obj in needAddObjs)
        {
            var item = Instantiate(defaultItem, container).GetComponent<BufferItem>();
            item.obj = obj;

            item.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        defaultItem.gameObject.SetActive(false);
    }
}
