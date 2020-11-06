using UnityEngine;
using Bluetooth_value;

public class button_color : MonoBehaviour
{
    public int num;
    private bool urikire;
    SpriteRenderer mr;

    // Update is called once per frame
    void Update()
    {
        mr = GetComponent<SpriteRenderer>();
        if (Bv.push_flag[num] || urikire)
        {
            mr.material.color = new Color32(0, 100, 0, 255);
            urikire = true;
        }
        else mr.material.color = new Color32(0, 0, 100, 255);

    }
}
