using UnityEngine;
using Bluetooth_value;

public class button_color : MonoBehaviour
{
    public int num;
    private bool urikire;
    public Sprite[] newsprite = new Sprite[2];
    SpriteRenderer mr;


    // Update is called once per frame
    void Update()
    {
        mr = GetComponent<SpriteRenderer>();
        if (Bv.push_flag[num] || urikire)
        {
            mr.material.color = new Color32(0, 100, 0, 255);
            mr.sprite = newsprite[0];
            urikire = true;
        }
        else
        {
            mr.material.color = new Color32(0, 0, 100, 255);
            mr.sprite = newsprite[1];
        }

    }
}
