using HuangD.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceItem : MonoBehaviour
{
    public Text Label;
    public Toggle toggle;
    public ProvinceDetail provinceDetail;

    public IProvince obj
    {
        get
        {
            return _obj;
        }
        set
        {
            _obj = value;

            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener((isOn) =>
            {
                if(isOn)
                {
                    provinceDetail.obj = _obj;
                }
            });
        }
    }

    private IProvince _obj;

    private void FixedUpdate()
    {
        Label.text = obj?.name;
    }
}
