using UnityEngine;
using UnityEngine.UI;

public class Military : MonoBehaviour
{
    public Text currCount;
    public Text maxCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maxCount.text = (Global.session.militaryMgr.max / 100.0).ToString();
        currCount.text = (Global.session.militaryMgr.current / 100.0).ToString();
    }
}
