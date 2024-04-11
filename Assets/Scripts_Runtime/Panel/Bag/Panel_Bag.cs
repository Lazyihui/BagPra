using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Bag : MonoBehaviour {
    // 背包内容
    [SerializeField] GridLayoutGroup gruop;
    [SerializeField] Panel_BagElement prefabElement;

    List<Panel_BagElement> elements;

    public void Ctor() {
        elements = new List<Panel_BagElement>();
    }

    public void Init(int maxSlot) {
        // 最大的格子数量 
        // 生成空格子
        for (int i = 0; i < maxSlot; i++) {
            Panel_BagElement ele = GameObject.Instantiate(prefabElement, gruop.transform);
            ele.Init(0, null, -1);
            elements.Add(ele);
        }
    }
    // 背包有添加物品和移除物品的方法
    public void Add(int id, Sprite icon, int count) {
        // 实例化物品
    }

    public void Remove(int id) {
        int index = elements.FindIndex(value => value.id == id);
        if (index != -1) {
            GameObject.Destroy(elements[index].gameObject);
            elements.RemoveAt(index);
        }

    }

    //  关闭
    public void Close() {

        foreach (var ele in elements) {
            GameObject.Destroy(ele.gameObject);
        }
        GameObject.Destroy(this.gameObject);
    }
}