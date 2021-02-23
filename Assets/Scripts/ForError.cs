using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForError : MonoBehaviour
{
    //Просто для того, что бы убрать Ошибку
    private void OnMouseDown()
    {
        GetComponent<Text>().enabled = false;
    }
}
