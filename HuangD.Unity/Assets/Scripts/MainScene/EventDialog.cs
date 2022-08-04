using LogicSimEngine.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class EventDialog : MonoBehaviour
{
    public Text title;
    public Button defaultButton;

    public IEvent obj
    {
        get
        {
            return _obj;
        }
        set
        {
            _obj = value;
            title.text = obj.title;

            defaultButton.onClick.RemoveAllListeners();
            defaultButton.onClick.AddListener(() =>
            {
                Destroy(this.gameObject);
            });
        }
    }

    public bool isDestroy { get; private set; } = false;
    
    private IEvent _obj;

    void OnDestroy()
    {
        isDestroy = true;
        _obj.OnExit?.Invoke();
    }
}