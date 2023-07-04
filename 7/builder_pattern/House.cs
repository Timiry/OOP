using System;
using System.Text;

namespace builder_pattern
{
    // Класс дома(продукт)
    public class House
    {
        public string? Color { get; set; }
        public string? RoofType { get; set; }
        public int? NumbersOfFloors { get; set; }
        public bool? HasCellar { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(Color != null) sb.Append($"Цвет: {Color}\n");
            if(RoofType != null) sb.Append($"Тип крыши: {RoofType}\n"); 
            if (NumbersOfFloors != null) sb.Append($"Количество этажей: {NumbersOfFloors}\n");
            if (HasCellar != null)
            {
                if (HasCellar == true) sb.Append($"Есть подвал\n");
                else sb.Append("Нет подвала\n");
            }
            return sb.ToString();
        }
    }

    // Абстрактный класс строителя
    public abstract class HouseBuilder
    {
        public House house { get; private set; }
        public void CreateHouse()
        {
            house = new House();
        }
        public abstract void SetColor();
        public abstract void SetRoofType();
        public abstract void SetNumbersOfFloors();
        public abstract void SetHasCellar();
    }

    // Конкретный класс строителя дома с плоской крышей
    public class FlatRoofHouseBuilder : HouseBuilder
    {
        public override void SetRoofType()
        {
            this.house.RoofType = "Плоская";
        }
        public override void SetColor()
        {
            this.house.Color = "Белый";
        }
        public override void SetNumbersOfFloors()
        {
            this.house.NumbersOfFloors = 5;
        }
        public override void SetHasCellar()
        {
            this.house.HasCellar = true;
        }            
    }

    // Конкретный класс строителя дома со скошенной крышей
    public class HippedRoofHouseBuilder : HouseBuilder
    {
        public override void SetRoofType()
        {
            this.house.RoofType = "Скошенная";
        }
        public override void SetColor()
        {
            this.house.Color = "Серый";
        }
        public override void SetNumbersOfFloors()
        {
            this.house.NumbersOfFloors = 1;
        }
        public override void SetHasCellar()
        {
            this.house.HasCellar = false;
        }
    }

    // Класс, вызывающий методы строителя (директор)
    public class HouseBuildDirector
    {
        public House Build(HouseBuilder builder)
        {
            builder.CreateHouse();
            builder.SetRoofType();
            builder.SetColor();
            builder.SetNumbersOfFloors();
            builder.SetHasCellar();
            return builder.house;
        }
    }
}