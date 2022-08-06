using HuangD.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceItem : MonoBehaviour
{
    public Text Label;
    public Toggle toggle;
    public ProvinceDetail defaultProvinceDetail;

    public IProvince obj
    {
        get
        {
            return _obj;
        }
        set
        {
            _obj = value;
        }
    }

    private IProvince _obj;
    
    public void OnSelectChanged(bool isOn)
    {
        if (isOn && obj != null)
        {
            var old = defaultProvinceDetail.transform.parent.GetComponentInChildren<ProvinceDetail>();
            Destroy(old?.gameObject);

            var provinceDetail = Instantiate<ProvinceDetail>(defaultProvinceDetail, defaultProvinceDetail.transform.parent);
            provinceDetail.obj = _obj;
            provinceDetail.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Label.text = obj?.name;
    }

    private void Start()
    {
        defaultProvinceDetail.gameObject.SetActive(false);
    }
}
