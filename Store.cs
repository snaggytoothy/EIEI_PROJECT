namespace EIEIE_Project;

public class Store
{
    GameManager gm = new GameManager();
    public void StoreScreen(Player player, List<Item> inventory)
    {
        Console.Clear();
        Console.WriteLine("���� \n�ʿ��� ������ ��� �� �� �ִ� ���Դϴ�. \n");
        Console.WriteLine($"[���� ���] : {player.Gold}G \n");
        Console.WriteLine("[������ ���] \n");

        for (int i = 0; i < gm.itemList.Count; i++)
        {
            Item item = gm.itemList[i];
            string str = item.ItemType == 1 ? "���ݷ�: " : "����: ";
            string strPrice = gm.itemList[i].IsBought ? "���ſϷ�" : $"{item.Price} G";
            Console.WriteLine($" - {item.ChangeEquipMark()} {item.Name} | {item.ItemType} +{item.GetValue()}| {item.Inform} | {strPrice}");
        }

        Console.WriteLine("1. ������ ���� \n0.������");

        //�Է��� ���� ���ڰ� �´��� Ȯ��
        Utility.GetInput(0, 2);
        bool isNum = int.TryParse(Console.ReadLine(), out int input);
        if (isNum)
        {
            switch (input)
            {
                case 1:
                    BuyItem(player, inventory);
                    break;
                case 2:
                    SellItem(player, inventory);
                    break;
                case 0:
                    break;
            }
        }
    }

    public void BuyItem(Player player, List<Item> inventory)
    {
        Console.Clear();
        Console.WriteLine("���� - ������ ���� \n�������� ������ �� �ֽ��ϴ�. \n");
        Console.WriteLine($"[���� ���] : {player.Gold} G \n");
        Console.WriteLine("[������ ���] \n");

        for (int i = 0; i < gm.itemList.Count; i++)
        {
            Item item = gm.itemList[i];
            string str = item.ItemType == 1 ? "���ݷ�: " : "����: ";
            string strPrice = gm.itemList[i].IsBought ? "���ſϷ�" : $"{item.Price} G";
            //ItemType�� ���� bool�� ���� ���̹Ƿ� ���� ������ Ÿ���� �߰��� ��� �����ؾ���
            Console.WriteLine($"{i + 1}. {item.Name} | {str} +{item.GetValue()} | {item.Inform} | {strPrice}");
        }

        Console.WriteLine("������ �������� ��ȣ�� ��������.");
        Console.WriteLine("0. ������");

        Utility.GetInput(0, gm.itemList.Count);
        bool input = int.TryParse(Console.ReadLine(), out int num);
        if (input)
        {
            num++;
            if (gm.itemList[num].IsBought)
            {
                Console.Clear();
                Console.WriteLine("�̹� ������ �������Դϴ�.");
            }
            else if (player.Gold >= gm.itemList[num].Price)
            {
                gm.itemList[num].IsBought = true;
                inventory.Add(gm.itemList[num]);
                player.Gold -= gm.itemList[num].Price;
                Console.Clear();
                Console.WriteLine($"{gm.itemList[num].Name} �������� �����߽��ϴ�.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("��尡 �����մϴ�.");
            }
            BuyItem(player, inventory);
        }
    }

    public void SellItem(Player player, List<Item> inventory)
    {
        Console.Clear();
        Console.WriteLine("���� - ������ �Ǹ� \n�������� �Ǹ��� �� �ֽ��ϴ�. \n");
        Console.WriteLine($"[���� ���] : {player.Gold} G \n");
        Console.WriteLine("[������ ���] \n");

        for (int i = 0; i < inventory.Count; i++)//�κ��丮 ������ ��ŭ
        {
            Item item = inventory[i];
            float sellNum = (float)item.Price * 0.85f;
            string str = item.ItemType == 1 ? "���ݷ�: " : "����: ";
            
            //ItemType�� ���� bool�� ���� ���̹Ƿ� ���� ������ Ÿ���� �߰��� ��� �����ؾ���
            //���� ���� �������� ��ȣ�� ������ID�� ���� ���� ���������� ǥ�õ�
            Console.WriteLine($"{i + 1}. {item.Name} | {str} +{item.GetValue()} | {item.Inform} | {sellNum.ToString("N0")}");
        }
        Console.WriteLine("�Ǹ��� �������� ��ȣ�� ��������.");
        Console.WriteLine("0. ������");

        Utility.GetInput(0, inventory.Count); //0���� �κ��丮 ������ ��������
        bool input = int.TryParse(Console.ReadLine(), out int num);
        if (input)
        {
            Item item = inventory[num - 1]; //������ ������ 1���� �����ϹǷ� input���� 1�� �� ���� �ӽ� item�� �߰�
            int itemID = item.ItemID; //���õ� �������� itemID�� ��ȯ��
            if (item.IsEquiped) item.IsEquiped = false; //���� ���̾��ٸ� ������
            float sellNum = inventory[num - 1].Price * 0.85f; //�Ǹ� ���� ����
            player.Gold += (int)sellNum; //�÷��̾� ��忡 �Ǹ� ���� �߰�
            inventory.Remove(inventory[num - 1]); //�ش� �������� inventory���� ����
            Console.Clear();
            Console.WriteLine($"{gm.itemList[itemID - 1].Name} �������� �Ǹ��߽��ϴ�.");
            SellItem(player, inventory);
        }
    }
}