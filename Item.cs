namespace EIEIE_Project;

public class Item
{
    public string Name { get; set; }
    public int ItemID { get; set; }
    public int Price { get; set; }
    public int ItemType { get; set; }
    public string Inform { get; set; }
    public bool IsEquiped { get; set; }
    public bool ShopFlag { get; set; }
    public bool MonsterFlag { get; set; }

    public bool IsBought { get; set; }

    public virtual float GetValue()
    {
        return 0;
    }

    public string ChangeEquipMark()
    {
        if (IsEquiped)
        {
            return "[E]";
        }
        else
        {
            return "";
        }
    }
}

public class Weapon : Item
{
    public float Atk { get; set; }

    public override float GetValue()
    {
        return Atk;
    }
}

public class Armor : Item
{
    public float Def { get; set; }
    public override float GetValue()
    {
        return Def;
    }
}