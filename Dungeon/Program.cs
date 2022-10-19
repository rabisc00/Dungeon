using Dungeon;

Character protagonist = new("Viktor", 50, 22);
Enemy currentEnemy = SpawnEnemy();

string? decision;

while (protagonist.IsAlive)
{
    Console.Write("Your action: ");
    decision = Console.ReadLine();

    switch (decision)
    {
        case "info":
            protagonist.DisplayInfo(currentEnemy);
            continue;
        case "attack":
            protagonist.HitEnemy(currentEnemy);
            break;
        case "prepare":
            protagonist.Prepare();
            break;
        case "inventory":
            ChooseItem(protagonist);
            continue;
        default:
            Console.WriteLine("Not a valid action\n");
            continue;
    }
    
    if (IsDead(currentEnemy))
    {
        Console.Clear();
        Console.WriteLine("You killed the enemy!");

        protagonist.CollectItem(currentEnemy.DropLoot());
        currentEnemy = SpawnEnemy();
    }
    else
    {
        protagonist.GetHit(currentEnemy);

        protagonist.IsAlive = !IsDead(protagonist);
        if (protagonist.IsAlive == false) { Console.WriteLine("ur dead"); }
    }
}


static Enemy SpawnEnemy()
{
    Random rnd = new();
    return new Enemy("Skeleton", rnd.Next(1, 51), rnd.Next(1, 51));
}
static bool IsDead(Character character) => character.Health < 0;
static void ChooseItem(Character protagonist)
{
    
    if (protagonist.ShowInventory())
    {
        List<string> availableOptions = new();
        protagonist.Inventory.ForEach(i => availableOptions.Add(i.ItemName.ToLower()));

        string chosenItem;
        do
        {
            Console.Write("Choose an item (or exit): ");
            chosenItem = Console.ReadLine().ToLower();

        } while (chosenItem != "exit" && !availableOptions.Contains(chosenItem));

        protagonist.ConsumeItem(chosenItem);
    }
    else { return; }
}