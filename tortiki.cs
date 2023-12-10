
using System;
using System.Collections.Generic;
using System.IO;

namespace ConfectioneryOrder
{
    
    class Order
    {
        private string cakeForm;
        private string cakeSize;
        private string cakeFlavor;
        private int cakeQuantity;
        private string cakeGlaze;
        private string cakeDecoration;

        public void ChooseCakeForm()
        {
            Console.WriteLine("Выберите форму торта:");
            Console.WriteLine("1. Круглая");
            Console.WriteLine("2. Прямоугольная");
            Console.WriteLine("3. Квадратная");
            int choice = Menu.SelectMenuItem(3);
            switch (choice)
            {
                case 1:
                    cakeForm = "Круглая";
                    break;
                case 2:
                    cakeForm = "Прямоугольная";
                    break;
                case 3:
                    cakeForm = "Квадратная";
                    break;
            }
        }

        public void ChooseCakeSize()
        {
            Console.WriteLine("Выберите размер торта:");
            Console.WriteLine("1. Маленький");
            Console.WriteLine("2. Средний");
            Console.WriteLine("3. Большой");
            int choice = Menu.SelectMenuItem(3);
            switch (choice)
            {
                case 1:
                    cakeSize = "Маленький";
                    break;
                case 2:
                    cakeSize = "Средний";
                    break;
                case 3:
                    cakeSize = "Большой";
                    break;
            }
        }

        public void ChooseCakeFlavor()
        {
            Console.WriteLine("Выберите вкус торта:");
            Console.WriteLine("1. Шоколадный");
            Console.WriteLine("2. Ванильный");
            Console.WriteLine("3. Фруктовый");
            int choice = Menu.SelectMenuItem(3);
            switch (choice)
            {
                case 1:
                    cakeFlavor = "Шоколадный";
                    break;
                case 2:
                    cakeFlavor = "Ванильный";
                    break;
                case 3:
                    cakeFlavor = "Фруктовый";
                    break;
            }
        }

        public void ChooseCakeQuantity()
        {
            Console.WriteLine("Введите количество тортов:");
            cakeQuantity = Convert.ToInt32(Console.ReadLine());
        }

        public void ChooseCakeGlaze()
        {
            Console.WriteLine("Выберите глазурь для торта:");
            Console.WriteLine("1. Шоколадная");
            Console.WriteLine("2. Сливочно-сахарная");
            Console.WriteLine("3. Фруктовая");
            int choice = Menu.SelectMenuItem(3);
            switch (choice)
            {
                case 1:
                    cakeGlaze = "Шоколадная";
                    break;
                case 2:
                    cakeGlaze = "Сливочно-сахарная";
                    break;
                case 3:
                    cakeGlaze = "Фруктовая";
                    break;
            }
        }

        public void ChooseCakeDecoration()
        {
            Console.WriteLine("Выберите декор для торта:");
            Console.WriteLine("1. Цветы");
            Console.WriteLine("2. Фигурки");
            Console.WriteLine("3. Шоколадные украшения");
            int choice = Menu.SelectMenuItem(3);
            switch (choice)
            {
                case 1:
                    cakeDecoration = "Цветы";
                    break;
                case 2:
                    cakeDecoration = "Фигурки";
                    break;
                case 3:
                    cakeDecoration = "Шоколадные украшения";
                    break;
            }
        }

        public void SaveOrder()
        {
            string orderDetails = string.Format("Форма: {0}, Размер: {1}, Вкус: {2}, Количество: { 3}, Глазурь: { 4}, Декор: { 5}",
                cakeForm, cakeSize, cakeFlavor, cakeQuantity, cakeGlaze, cakeDecoration);
File.AppendAllText("История заказов.txt", orderDetails + Environment.NewLine);
Console.WriteLine("Заказ сохранен в файле.");
        }

        public void PrintOrder()
{
    Console.WriteLine("Итоговый заказ:");
    Console.WriteLine("Форма: " + cakeForm);
    Console.WriteLine("Размер: " + cakeSize);
    Console.WriteLine("Вкус: " + cakeFlavor);
    Console.WriteLine("Количество: " + cakeQuantity);
    Console.WriteLine("Глазурь: " + cakeGlaze);
    Console.WriteLine("Декор: " + cakeDecoration);
}

public double CalculateTotalPrice()
{
    
    double price = 0;
   
    switch (cakeForm)
    {
        case "Круглая":
            price += 50;
            break;
        case "Прямоугольная":
            price += 80;
            break;
        case "Квадратная":
            price += 40;
            break;
    }
    
    switch (cakeSize)
    {
        case "Маленький":
            price += 200;
            break;
        case "Средний":
            price += 400;
            break;
        case "Большой":
            price += 800;
            break;
    }
    // вкус
    switch (cakeFlavor)
    {
        case "Шоколадный":
            price += 10;
            break;
        case "Ванильный":
            price += 10;
            break;
        case "Фруктовый":
            price += 20;
            break;
    }
    //глазурь
    switch (cakeGlaze)
    {
        case "Шоколадная":
            price += 50;
            break;
        case "Сливочно-сахарная":
            price += 60;
            break;
        case "Фруктовая":
                    price += 70;
            break;
    }
    
    switch (cakeDecoration)
    {
        case "Цветы":
            price += 100;
            break;
        case "Фигурки":
            price += 150;
            break;
        case "Шоколадные украшения":
            price += 200 ;
            break;
    }
    price *= cakeQuantity;

    return price;
}
    }


    class Menu
{
    private static List<string> menuItems = new List<string>();

    public static void AddMenuItem(string menuItem)
    {
        menuItems.Add(menuItem);
    }

    public static int SelectMenuItem(int maxChoice)
    {
        int choice = 0;
        bool validChoice = false;
        while (!validChoice)
        {
            Console.Write("Введите номер выбранного пункта: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= maxChoice)
            {
                validChoice = true;
            }
            else
            {
                Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
            }
        }
        return choice;
    }

    public static void PrintMenu()
    {
        Console.WriteLine("Меню:");
        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + menuItems[i]);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu.AddMenuItem("Заказать торт");
        Menu.AddMenuItem("Просмотреть историю заказов");
        Menu.AddMenuItem("Выход");

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Menu.PrintMenu();
            int choice = Menu.SelectMenuItem(3);
            switch (choice)
            {
                case 1:
                    Order order = new Order();
                    order.ChooseCakeForm();
                    order.ChooseCakeSize();
                    order.ChooseCakeFlavor();
                    order.ChooseCakeQuantity();
                    order.ChooseCakeGlaze();
                    order.ChooseCakeDecoration();
                    double totalPrice = order.CalculateTotalPrice();
                    order.PrintOrder();
                    Console.WriteLine("Общая стоимость заказа: " + totalPrice);
                    order.SaveOrder();
                    break;
                case 2:
                    Console.WriteLine("История заказов:");
                    string[] orderHistory = File.ReadAllLines("История заказов.txt");
                    foreach (string orderDetails in orderHistory)
                    {
                        Console.WriteLine(orderDetails);
                    }
                    break;
                case 3:
                    exit = true;
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
}