using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Скрипт для загрузки игровых уровней
    [SerializeField]
    int level;
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Level_" + level);
    }
}
