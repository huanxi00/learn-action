// See https://aka.ms/new-console-template for more information

using NewTypes.Pets;

List<IPet> pets = new List<IPet>
{
    new Dog(),
    new Cat()
};

foreach (var pet in pets)
{
    Console.WriteLine(pet.TalkToOwner());
}
