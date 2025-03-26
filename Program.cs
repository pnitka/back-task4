// Задача 1: зоопарк
using System;
using System.Collections.Generic;

public class Animal
{
    public virtual void Eat()
    {
        Console.WriteLine("Животное ест");
    }

    public virtual void Speak()
    {
        Console.WriteLine("Животное издает звук");
    }
}

public class Lion : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Рррр!");
    }
}

public class Elephant : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Тру-у-у!");
    }
}

public class Monkey : Animal
{
    public override void Speak()
    {
        Console.WriteLine("У-у-а!");
    }
}

public class Zoo
{
    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Lion());
        animals.Add(new Elephant());
        animals.Add(new Monkey());

        foreach (Animal animal in animals)
        {
            animal.Speak();
        }
    }
}


// Задача 2: игровые персы

using System;

public class GameCharacter
{
    public string name;
    public int health;

    public virtual void Attack(GameCharacter target)
    {
        Console.WriteLine(name + " атакует " + target.name);
    }
}

public class Warrior : GameCharacter
{
    public int armor;
    public override void Attack(GameCharacter target)
    {
        Console.WriteLine(name + " бьет мечом " + target.name);
        target.health -= 20; 
    }
}

public class Mage : GameCharacter
{
    public int mana;
    public override void Attack(GameCharacter target)
    {
        Console.WriteLine(name + " использует магию против " + target.name);
        target.health -= 30; 
    }
}

public class Game
{
    public static void Main(string[] args)
    {
        // персы
        Warrior warrior = new Warrior();
        warrior.name = "Воин";
        warrior.health = 100;
        warrior.armor = 15;

        Mage mage = new Mage();
        mage.name = "Маг";
        mage.health = 80;
        mage.mana = 50;

        while (warrior.health > 0 && mage.health > 0)
        {
            warrior.Attack(mage);
            Console.WriteLine("У мага осталось здоровья: " + mage.health);

            if (mage.health <= 0) break;

            mage.Attack(warrior);
            Console.WriteLine("У воина осталось здоровья: " + warrior.health);
        }

        if (warrior.health <= 0)
        {
            Console.WriteLine("Маг победил!");
        }
        else
        {
            Console.WriteLine("Воин победил!");
        }
    }
}

//3 Таска: Форма доставки
using System.Collections.Generic;

public class Delivery
{
    public string address;
    public double price;
}

public class CourierDelivery : Delivery
{
    public void DeliverByCourier()
    {
        Console.WriteLine("Доставка курьером по адресу: " + address);
    }
}

public class Pickup : Delivery
{
    public void PickUpFromStore()
    {
        Console.WriteLine("Самовывоз из магазина");
    }
}

public class DeliveryService
{
    public static void Main(string[] args)
    {
        List<Delivery> deliveries = new List<Delivery>();

        CourierDelivery courierDelivery = new CourierDelivery();
        courierDelivery.address = "ул. Ленина, 1";
        courierDelivery.price = 200;
        deliveries.Add(courierDelivery);

        Pickup pickup = new Pickup();
        pickup.address = "ул. Гагарина, 5"; 
        pickup.price = 0;
        deliveries.Add(pickup);

        foreach (Delivery delivery in deliveries)
        {
            if (delivery is CourierDelivery)
            {
                ((CourierDelivery)delivery).DeliverByCourier();
            }
            else if (delivery is Pickup)
            {
                ((Pickup)delivery).PickUpFromStore();
            }
        }
    }
}
