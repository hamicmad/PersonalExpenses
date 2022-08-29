using PersonalExpenses;
using PersonalExpenses.Controller;
using PersonalExpenses.Enums;
using PersonalExpenses.Models;

using var db = new PEcontext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

var wCntr = new WalletCntr();
var cCntr = new CategoryCntr();
while (true)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("1 - Категории(Расходы/Доходы)");
        Console.WriteLine("2 - Операции");
        Console.WriteLine("3 - Кошельки");
        Console.WriteLine("Esc - Выход");
        var key = Console.ReadKey();
        Console.WriteLine();
        switch (key.Key)
        {
            case ConsoleKey.D1:

                Console.WriteLine("1 - Добавить категорию");
                Console.WriteLine("2 - Просмотреть операции по категории");
                Console.WriteLine("3 - Изменить категорию");
                Console.WriteLine("4 - Удалить категорию");
                Console.WriteLine("Esc - Назад");
                var key1 = Console.ReadKey();
                Console.WriteLine();
                switch (key1.Key)
                {
                    case ConsoleKey.D1:
                        var catC1 = EnterCategory();
                        await cCntr.Create(catC1.name, catC1.type);
                        Console.WriteLine("Сохранено");
                        break;
                    case ConsoleKey.D2:
                        var idC2 = await CategorySearch(cCntr);
                        var cat2 = await cCntr.Read(idC2);
                        Console.WriteLine($"{cat2.Name}");
                        foreach (var op in cat2.CategoryOperations)
                        {
                            Console.WriteLine(op.ToString());
                        }
                        break;
                    case ConsoleKey.D3:
                        var catC3 = EnterCategory();
                        var idC3 = await CategorySearch(cCntr);
                        await cCntr.Update(idC3, catC3.name, catC3.type);
                        Console.WriteLine("Сохранено");
                        break;
                    case ConsoleKey.D4:
                        var catC4 = await CategorySearch(cCntr);
                        await cCntr.Delete(catC4);
                        Console.WriteLine("Сохранено");
                        break;
                }
                break;

            case ConsoleKey.D2:
                var opCtrl = new OperationCntr();
                Console.WriteLine("1 - Добавить операцию");
                Console.WriteLine("2 - Изменить операцию");
                Console.WriteLine("3 - Удалить операцию");
                Console.WriteLine("Esc - Назад");
                var key2 = Console.ReadKey();
                Console.WriteLine();
                switch (key2.Key)
                {
                    case ConsoleKey.D1:
                        var opC1 = await EnterOperation(wCntr, cCntr);
                        await opCtrl.Create(opC1.sum, opC1.wId, opC1.cId);
                        Console.WriteLine("Сохранено");
                        break;
                    case ConsoleKey.D2:
                        var opC2 = await OperationSearch(opCtrl, cCntr);
                        Console.WriteLine("Введите сумму:");
                        var sumC2 = decimal.Parse(Console.ReadLine());
                        await opCtrl.Update(opC2, sumC2);
                        Console.WriteLine("Сохранено");
                        break;
                    case ConsoleKey.D3:
                        var opC3 = await OperationSearch(opCtrl, cCntr);
                        await opCtrl.Delete(opC3);
                        Console.WriteLine("Сохранено");
                        break;
                }

                break;
            case ConsoleKey.D3:
                Console.WriteLine("1 - Добавить кошелек");
                Console.WriteLine("2 - Информация о кошельке");
                Console.WriteLine("3 - Перевод денег");
                Console.WriteLine("4 - Изменить кошелек");
                Console.WriteLine("5 - Удалить кошелек");
                Console.WriteLine("Esc - Назад");
                Console.WriteLine();
                var key3 = Console.ReadKey();
                Console.WriteLine();
                switch (key3.Key)
                {
                    case ConsoleKey.D1:
                        var wC1 = EnterWallet();
                        await wCntr.Create(wC1.name, wC1.currency);
                        Console.WriteLine("Сохранено");
                        break;
                    case ConsoleKey.D2:
                        var wC2 = await WalletSearch(wCntr);
                        var wallet = await wCntr.Read(wC2);

                        Console.WriteLine($"{wallet.WalletType.Name} {wallet.Balance} {wallet.WalletType.Currency}");
                        foreach (var op in wallet.CategoryOperations)
                        {
                            Console.WriteLine($"{op.Category.Type} {op.Category.Name}  {op.Sum} {op.Date}");
                        }
                        break;
                    case ConsoleKey.D3:
                        var wC3_1 = await WalletSearch(wCntr);
                        var wC3_2 = await WalletSearch(wCntr);
                        Console.WriteLine("Введите сумму для перевода:");
                        var sumC3 = decimal.Parse(Console.ReadLine());
                        await wCntr.TransferMoney(sumC3, wC3_1, wC3_2);
                        Console.WriteLine("Сохранено");
                        break;
                    case ConsoleKey.D4:
                        var wC4_1 = await WalletSearch(wCntr);
                        var wC4_2 = EnterWallet();
                        await wCntr.Update(wC4_1, wC4_2.name, wC4_2.currency);
                        Console.WriteLine("Сохранено");
                        break;
                    case ConsoleKey.D5:
                        var wC5_1 = await WalletSearch(wCntr);
                        await wCntr.Delete(wC5_1);
                        Console.WriteLine("Сохранено");
                        break;
                }
                break;
            case ConsoleKey.Escape:
                return;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


static (string name, Types type) EnterCategory()
{
    Console.WriteLine("Введите название:");
    var name = Console.ReadLine();
    Console.WriteLine("Выберите тип: 1.Расходы  2.Доходы");
    var type = (Types)int.Parse(Console.ReadLine());
    return (name, type);
}

static async Task<int> CategorySearch(CategoryCntr cCntr)
{
    var categories = await cCntr.ReadAll();

    Console.WriteLine("Выберите тип: 1.Расходы  2.Доходы");
    var type = (Types)int.Parse(Console.ReadLine());

    var cats = categories.Where(c => c.Type == type).ToList();
    Console.WriteLine("Выберите номер категории:");
    for (int i = 0; i < cats.Count; i++)
    {
        Console.WriteLine($"{i}. {cats[i].Name}");
    }
    var num = int.Parse(Console.ReadLine());
    return cats[num].Id;
}

static async Task<(decimal sum, int wId, int cId)> EnterOperation(WalletCntr wCntr, CategoryCntr cCntr)
{
    var wId = await WalletSearch(wCntr);
    var cId = await CategorySearch(cCntr);

    Console.WriteLine("Введите сумму:");
    var sum = decimal.Parse(Console.ReadLine());

    return (sum, wId, cId);
}

static async Task<int> OperationSearch(OperationCntr opCntr, CategoryCntr cntr)
{
    var cId = await CategorySearch(cntr);
    var cat = await cntr.Read(cId);
    Console.WriteLine("Выберите номер операции:");
    for (int i = 0; i < cat.CategoryOperations.Count; i++)
    {
        Console.WriteLine($"{i}. {cat.CategoryOperations[i]}");
    }
    int num = int.Parse(Console.ReadLine());
    return cat.CategoryOperations[num].Id;

}

static (string name, Currency currency) EnterWallet()
{
    Console.WriteLine("Введите имя:");
    var name = Console.ReadLine();

    Console.WriteLine("Выберите валюту:");
    foreach (var item in Enum.GetValues(typeof(Currency)))
    {
        Console.WriteLine($"{item}");
    }
    var currency = (Currency)int.Parse(Console.ReadLine());
    return (name, currency);
}

static async Task<int> WalletSearch(WalletCntr wCntr)
{
    var wallet = await wCntr.ReadAll();

    Console.WriteLine("Выберите номер кошелька:");
    for (int i = 0; i < wallet.Count; i++)
    {
        Console.WriteLine($"{i}. {wallet[i].WalletType.Name}");
    }
    var num = int.Parse(Console.ReadLine());
    return wallet[num].Id;
}