﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("GameManager").SendMessage("GameOver");
    }
}
