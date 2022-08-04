using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public Text count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count.text = (Global.session.popCount/100.0).ToString();
    }
}
