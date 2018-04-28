﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightHandDetector : MonoBehaviour {

    public Text coinText; //префаб текста для количества собранных монет
    public GameObject crack; //Префаб трещин под камнем

    public static bool isRockedRightHand; //переменная для определения нахождения ладони на камне

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            isRockedRightHand = true;
            StartCoroutine(DrawCrack(collision));
        }
        if (collision.gameObject.tag == "Coin")
        {
            StartCoroutine(ScoreCoin(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            isRockedRightHand = false;
        }
    }

    IEnumerator ScoreCoin(Collider2D collision) //Метод для добавления собранных монет
    {
        yield return new WaitForSeconds(0.3f); //Задержка
        if (!FindObjectOfType<PlayerController>().direction)
        {
            int scoreCoin = Convert.ToInt32(coinText.text); // Получение текущего значения количества монет
            scoreCoin++;
            coinText.text = scoreCoin.ToString(); //изменение текста количества собранных монет
            Destroy(collision.gameObject); //Уничтожение собранной монеты
        }
    }

    IEnumerator DrawCrack(Collider2D collision) //Метод для добавления трещин
    {
        yield return new WaitForSeconds(0.3f); //Задержка
        if (!FindObjectOfType<PlayerController>().direction) //проверка на смену направления
        {
            Instantiate(crack,collision.transform.position,Quaternion.identity); //Добавление трещин
        }
    }
}
