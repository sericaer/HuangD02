using HuangD.Interfaces;
using UnityEngine;

public class MilitaryLevelContainer : MonoBehaviour
{
    public MilitaryLevelItem defaultItem;

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

            foreach (var obj in Global.modder.defs.militaryLevelDef.items)
            {
                var item = Instantiate(defaultItem, container).GetComponent<MilitaryLevelItem>();
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
    }
}
