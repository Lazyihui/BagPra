using UnityEngine;
using UnityEngine.UI;


public class Panel_BagElement : MonoBehaviour {

    public int id;

    [SerializeField] Image imgIcon;

    [SerializeField] Text textCount;

    public void Ctor() { }

    public void Init(int id, Sprite icon, int count) {
        this.id = id;
        this.imgIcon.sprite = icon;

        if (count <= 0) {
            this.textCount.text = null;
        } else {
            this.textCount.text = count.ToString();
        }
    }
}