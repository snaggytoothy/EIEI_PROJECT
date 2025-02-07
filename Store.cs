namespace EIEIE_Project;

public class Store
{
    GameManager gm = new GameManager();

    public void StoreScreen(Player player, List<Item> inventory)
    {
        Console.Clear();
        Console.WriteLine("���� \n�ʿ��� ������ ��� �� �� �ִ� ���Դϴ�. \n");
        Console.WriteLine($"[���� ���] : {player.Gold}G \n"); //�̵� �÷��̾� ��� ���⿡ �־�� ��
        Console.WriteLine("[������ ���] \n");

        for (int i = 0; i < gm.itemList.Count; i++)
        {
            Item item = gm.itemList[i];
            Console.WriteLine($" - {i}. {item.Name} | {item.Inform} | {item.Price}");
        }

        Console.WriteLine("1. ������ ���� \n0.������");
        
        //�Է��� ���� ���ڰ� �´��� Ȯ��
        bool isNum = int.TryParse(Console.ReadLine(), out int input);
        if (isNum)
        {
            switch (input)
            {
                case 1:
                    BuyItem(player, inventory);
                    break;
                case 0:
                    break;
            }
        }
        else
        {
            WrongInput();
        }
    }

    public void BuyItem(Player player, List<Item> inventory)
    {
        Console.Clear();
        Console.WriteLine("���� - ������ ���� \n�ʿ��� ������ �����մϴ�. \n");
        Console.WriteLine($"[���� ���] : {player.Gold} G \n"); //�̵� �÷��̾� ��� ���⿡ �־�� ��
        Console.WriteLine("[������ ���] \n");

        for (int i = 0; i < gm.itemList.Count; i++)
        {
            Item item = gm.itemList[i];
            string str = item.ItemType == 1 ? "���ݷ�: " : "����: ";
            //ItemType�� ���� bool�� ���� ���̹Ƿ� ���� ������ Ÿ���� �߰��� ��� �����ؾ���
            Console.WriteLine($"{i}. {item.Name} | {str} +{item.GetValue()} | {item.Inform} | {item.Price}");
        }

        Console.WriteLine("������ �������� ��ȣ�� ��������.");
        Console.WriteLine("0. ������");

        Utility.GetInput(0, gm.itemList.Count);
        bool input = int.TryParse(Console.ReadLine(), out int num);
        if (input)
        {
            if (gm.itemList[num].IsBought)
            {
                Console.Clear();
                Console.WriteLine("�̹� ������ �������Դϴ�.");
                BuyItem(player, inventory);
            }
            else if (player.Gold >= gm.itemList[num].Price)
            {
                gm.itemList[num].IsBought = true;
                inventory.Add(gm.itemList[num]);
                Console.Clear();
                Console.WriteLine($"{gm.itemList[num].Name}�� �����߽��ϴ�.");
            }
        }
        Console.WriteLine("");
    }

    public void WrongInput()
    {
        Console.WriteLine("�߸��� �Է��Դϴ�.");
    }
}