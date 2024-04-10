using System;
using System.Collections.Generic;
using UnityEngine;



public class RoleEntity : MonoBehaviour {

    public int id;

    public float moveSpeed;

    public void Ctor() { }

    public void Move(Vector3 dir, float fixdt) {
        Vector3 pos = transform.position;
        pos += dir * moveSpeed * fixdt;
        transform.position = pos;
    }

}


