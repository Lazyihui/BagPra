using System;
using System.Collections.Generic;
using UnityEngine;



public class RoleEntity : MonoBehaviour {

    public int id;

    public float moveSpeed;

    public BagComponent bagCom;

    public void Ctor() {
        bagCom = new BagComponent();
    }
    public void Init(int bagMaxSlot) {
        bagCom.Init(bagMaxSlot);
    }
    
    public void Move(Vector3 dir, float fixdt) {
        Vector3 pos = transform.position;
        pos += dir * moveSpeed * fixdt;
        transform.position = pos;
    }

}


