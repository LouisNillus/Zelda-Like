﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{

	public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}