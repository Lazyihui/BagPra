using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Bag : MonoBehaviour {
    // 背包内容
    [SerializeField] GridLayoutGroup gruop;
    [SerializeField] Panel_BagElement prefabElement;

    List<Panel_BagElement> elements;

    public Action<int> OnuseHandle;

    public void Ctor() {
        elements = new List<Panel_BagElement>();
    }

    public void Init(int maxSlot) {
        // 最大的格子数量 
        // 生成空格子
        for (int i = 0; i < maxSlot; i++) {
            Panel_BagElement ele = GameObject.Instantiate(prefabElement, gruop.transform);
            ele.Ctor();
            ele.OnUseHandle = Onuse;
            ele.Init(-1, null, 0);
            elements.Add(ele);
        }
    }

    void Onuse(int id) {
        OnuseHandle.Invoke(id);
    }
    // 背包有添加物品和移除物品的方法
    public void Add(int id, Sprite icon, int count) {
        // 实例化物品
        // 找到不是-1的格子 然后添加内容
        for (int i = 0; i < elements.Count; i++) {
            Panel_BagElement ele = elements[i];
            if (ele.id == -1) {
                ele.Init(id, icon, count);
                break;
            }
        }
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