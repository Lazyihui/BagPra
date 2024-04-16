using System;
using System.Collections.Generic;
using UnityEngine;
public class BagComponent {


    BagItemModel[] all;

    public BagComponent() { }


    public void Init(int maxSlot) {
        all = new BagItemModel[maxSlot];
    }

    public bool Add(int typeID, int count, Func<BagItemModel> onAddItemToNewSlot) {
        // 1. 判断是否已经存在

        // 2. 如果存在，增加数量
        for (int i = 0; i < all.Length; i++) {
            BagItemModel old = all[i];
            if (old.typeID == typeID) {
                // 就叠加 allowCount可叠加的数量
                int allowCount = old.maxCount - old.count;
                if (allowCount >= count) {
                    old.count += count;
                    return true;
                } else {
                    old.count = old.maxCount;
                    count -= allowCount;
                }
            }
        }
        // 3. 如果不存在，添加新的 就是没有久的
        if (count > 0) {
            // 如果有空格子 就添加 
            // a.先找有没有空格子 null 表示空格子
            int index = -1;
            for (int i = 0; i < all.Length; i++) {
                BagItemModel old = all[i];
                if (old == null) {
                    index = i;
                    break;
                }
            }
            // 如果没有空格子 就返回false 没有空格子的情况
            if (index == -1) {
                return false;
            }

            // b.添加新的物品
            //    回调函数
            all[index] = onAddItemToNewSlot.Invoke();
            return true;
            // 读模板（正确写法）
        } else {
            return true;
        }
        // 4. 如果背包满了，返回false 
    }


    public int maxSlot() {
        return all.Length;
    }
    public int GEtOccupiedSlotCount() {
        int count = 0;
        for (int i = 0; i < all.Length; i++) {
            if (all[i] != null) {
                count++;
            }
        }
        return count;
    }

}