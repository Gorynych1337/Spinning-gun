using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadRecord : MonoBehaviour
{
    [SerializeField] private TMP_Text recordTMP_Text;
    
    private void Awake()
    {
        int record = PlayerPrefs.GetInt("Record");
        
        recordTMP_Text.SetText($@"Your record is {record}");
    }
}
