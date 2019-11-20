using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {
    public string[,] Item = new string[1, 7];
    public string Name, Amount, Weight, Icon, Adds, Type, InGameName;
	// Use this for initialization
	void Start ()
    {
        Item[0, 0] = Name;
        Item[0, 1] = Amount;
        Item[0, 2] = Weight;
        Item[0, 3] = Icon;
        Item[0, 4] = Adds;
        Item[0, 5] = Type;
        Item[0, 6] = InGameName;
    }

}
/*
 Добавление нового предмета:
 1. Создать префаб
 2. Кинуть на него скрипт Item Script
 3. Ввести нужные значения в колонки
 4. На камере в Create remove script добавить новый item
 5. В скрипте Inventory Script добавить новый icon
 Тип предмета
 I - Предмет
 E - Еда
 W - Вода
 H - ХП
 B - Строение
 T - Инструмент
 Номера Иконок
 0 - Камень
 1 - Палка
 2 - Яблоко
 3 - Вода
 4 - бревно
 5 - Пучок травы
 6 - Веревка
 7 - Верстак
 8 - Каменный Топор
 9 - Костер
 10 - Сырое мясо
 11 - Готовое мясо
 12 - Сырой краб
 13 - Жареный краб
 14 - Простая кровать
 Не забывать добавлять ID иконок
     */
