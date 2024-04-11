using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Bag : MonoBehaviour {
    // 背包内容
    [SerializeField] GridLayoutGroup gruop;
    [SerializeField] Panel_BagElement prefabElement;

    Dictionary<int, Panel_BagElement> elements;

    public void Ctor() { 
        elements = new Dictionary<int, Panel_BagElement>();
    }
    // 背包有添加物品和移除物品的方法

    public void Add(int id, Sprite icon, int count) {

        Panel_BagElement ele = GameObject.Instantiate(prefabElement, gruop.transform);
        ele.Init(id, icon, count);
        elements.Add(id, ele);
    }

    public void Remove(int id) {
        bool has = elements.TryGetValue(id, out Panel_BagElement ele);
        if (has) {
            elements.Remove(id);
            GameObject.Destroy(ele.gameObject);
        }
     }

    //  关闭
    public void Close() {

        foreach (var ele in elements) {
            GameObject.Destroy(ele.Value.gameObject);
        }
        GameObject.Destroy(this.gameObject);
    }
}