using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    // Скрипт вешается на что душе угодно. Хоть на камеру. Только не забудьте в Instantiate() позицию указать
    // Тут ничего сложного. Основному скрипту добавляется переменная типа snting с названием Name. В коллекцию добавляются скины основного класса
    [SerializeField]
    List<SckinName> sckins;
    // Ключ всё тот же
    string key = "PlayerSkin";

    [SerializeField]
    string name;
    // Проверяем наличие нужного ключа
    private void Start()
    {
        if (PlayerPrefs.HasKey(key))
        {
            name = PlayerPrefs.GetString(key);
            Debug.Log(name);
        }
        else
        {
            Instantiate(sckins[0].gameObject, new Vector3(), new Quaternion());
        }
        Instantiate(ChooseSckin(name), gameObject.transform.position, new Quaternion());
    }

    //Возвращает объект из колекции с подходящим именем. Иначе возвращает первый объект коллекции
    //Объект котрый мы ретурним мы после создаём в старте
    GameObject ChooseSckin (string name)
    {
        foreach (SckinName obj in sckins)
        {
            if (name == obj.name)
            {
                return obj.gameObject;
            }
            // Интересный факт - ранее тут было else и ретурнился первый объект коллекции, однако ошибок нет.
        }
        // Условно эта строка не нужна, но иначе IDE мозг выносит
        return new GameObject();
    }
}
