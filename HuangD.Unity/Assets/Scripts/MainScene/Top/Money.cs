using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text count;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<LazyUpdateTooltipTrigger>().funcGetTipInfo = () =>
        {
            return new TipInfo()
            {
                bodyText = String.Join("\n", Global.session.moneyMgr.tables.Select(x => $"{x.Key}    {x.Value.Values.Sum(x=>x.Invoke().Value):+0;-#}"))
            };
        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count.text = (Global.session.moneyMgr.current/100.0).ToString();
    }
}
