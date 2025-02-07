namespace EIEIE_Project;

public class GameManager
{
    public List<Item> itemList = new List<Item>()
    {
        new Weapon{Name = "�⺻ ��", ItemID = 1, Price = 100, ItemType = 0, Inform = "�⺻ ���Դϴ�. Ư���� ���� �����ϴ�.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Atk = 5f},
        new Weapon{Name = "��ī�ο� ��", ItemID = 2, Price = 250, ItemType = 0, Inform = "���� �� ������ ���Դϴ�.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 8f},
        new Weapon{Name = "�ź�ο� ��", ItemID = 3, Price = 500, ItemType = 0, Inform = "����� ���ƺ��̴� ���Դϴ�.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Atk = 10f},
        new Armor{Name = "�⺻ ����", ItemID = 4, Price = 100, ItemType = 1, Inform = "�⺻ �����Դϴ�. Ư���� ���� �����ϴ�.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = false, Def = 5f},
        new Armor{Name = "��¦�̴� ����", ItemID = 5, Price = 300, ItemType = 1, Inform = "�� �۾Ƽ� ��¦�̴� �����Դϴ�.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 8f},
        new Armor{Name = "�ź�ο� ����", ItemID = 6, Price = 700, ItemType = 1, Inform = "����� ���ƺ��̴� �����Դϴ�.",
        IsEquiped = false, ShopFlag = true, MonsterFlag = true, Def = 12f},
    };
}