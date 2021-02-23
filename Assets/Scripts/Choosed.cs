using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choosed : MonoBehaviour
{
    // Просто скрипт для отображения выбранного объекта
    [SerializeField]
    Text text;
    void Update()
    {
        text.text = "Выбран: " + PlayerPrefs.GetString("PlayerSkin");
    }
}
