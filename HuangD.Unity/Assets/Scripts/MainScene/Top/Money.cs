using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count.text = Global.session.moneyMgr.current.ToString();
    }
}
