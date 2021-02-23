using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    // Кошелёк

    string key = "Wallet";

    [SerializeField]
    Text text;
    public int Account = 0;

    // При запуске проверяется сколько денег накопил игрок
    void Start()
    {
        PlayerSckin.Purchase += WalletUpdate;
        if (PlayerPrefs.HasKey(key))
        {
            Account = PlayerPrefs.GetInt(key);
            WalletUpdate();
        }
        else
        {
            text.text = "0";
        }
    }

    // Обновляем показатели кошелька. Можно было бы прикрутить ивент и при покупке вызывать его, но это было проще.
    void WalletUpdate()
    {
        text.text = System.Convert.ToString(Account);
    }
}
