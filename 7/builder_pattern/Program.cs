namespace builder_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person myPerson = new Person.Builder()
            .withName("Василий")
            .withSurname("Васильев")
            .withAge(27)
            .withHeight(170)
            .withWeight(70)
            .build();
            Console.WriteLine(myPerson.ToString());

            HouseBuildDirector director = new HouseBuildDirector();
            HouseBuilder builder = new HippedRoofHouseBuilder();
            House house1 = director.Build(builder);
            Console.WriteLine(house1.ToString());

            builder = new FlatRoofHouseBuilder();
            House house2 = director.Build(builder);
            Console.WriteLine(house2.ToString());
        }
    }
}