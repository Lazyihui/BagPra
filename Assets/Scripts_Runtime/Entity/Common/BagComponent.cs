using System.Collections.Generic;
using UnityEngine;
public class BagComponent {


    BagItemModel[] all;

    public BagComponent() { }


    public void Init(int maxSlot){
        all = new BagItemModel[maxSlot];
    }

    public void Add(int typeID,int count){
        // 1. 判断是否已经存在
        
        // 2. 如果存在，增加数量
        
        // 3. 如果不存在，添加新的
        
        // 4. 如果背包满了，返回false

    }

}