using Dungeon;

Protagonist player1 = new("Viktor", 50, 22);
Enemy currentEnemy = SpawnEnemy();

string? decision;

while (player1.IsAlive)
{
    Console.Write("Your action: ");
    decision = Console.ReadLine();

    switch (decision)
    {
        case "info":
            player1.DisplayInfo();
            continue;
        case "attack":
            currentEnemy.GetHit(player1);
            break;
        case "prepare":
            player1.Prepare();
            break;
        case "inventory":
            ChooseItem(player1);
            continue;
        default:
            Console.WriteLine("Not a valid action\n");
            continue;
    }
    
    if (IsDead(currentEnemy))
    {
        Console.Clear();
        Console.WriteLine("You killed the enemy!");

        player1.CollectItem(currentEnemy.DropLoot());
        currentEnemy = SpawnEnemy();
    }
    else
    {
        player1.GetHit(currentEnemy);

        player1.IsAlive = !IsDead(player1);
        if (player1.IsAlive == false) { Console.WriteLine("You died. Game over."); }
    }
}


static Enemy SpawnEnemy()
{
    return new Skeleton();
}
static bool IsDead(Character character)
{
    return character.Health < 0;
}
static void ChooseItem(Protagonist protagonist)
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