﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirObjetos : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
