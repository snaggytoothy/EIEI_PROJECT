namespace EIEIE_Project;

public class Item
{
    public string Name { get; set; }
    public int ItemID { get; set; }
    public int Price { get; set; }
    public int ItemType { get; set; }
    public string Inform { get; set; }

    public bool ShopFlag { get; set; }
    public bool MonsterFlag { get; set; }
}


public class Consumable : Item // 소비 아이템 클래스  
{
    private int maxCount = 99;
    public int MaxCount
    {
        get
        {
            return maxCount;
        }
    }
    public int Count { get; set; }

    public float BuffAmount { get; set; }
    
    public void Use(Player player)
    {
        player.NowHP += BuffAmount;
        if(player.NowHP > player.MaxHP)
        {
            player.NowHP = player.MaxHP;
        }
        Count--;
        Console.WriteLine("체력이 50 회복되었습니다.");
    }

    public void Use(GameManager gameManager, int extraAtk) // 공격력 버프 물약
    {
        Count--;
        BuffAmount = extraAtk;
        gameManager.player.Atk += BuffAmount;
        Buff buff = new Buff(EndAtkBuff, gameManager, 3);
    }
    private void EndAtkBuff(GameManager gameManager)
    {
        gameManager.player.Atk -= BuffAmount;
    }
}


public class Equipment : Item // 장비 클래스 
{
    public bool IsEquiped { get; set; }
    public bool IsBought { get; set; }
    public virtual float GetValue()
    {
        return 0;
    }
    public virtual void Equip(Player player)
    {

    }
    public virtual void UnEquip(Player player)
    {

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
    public string DifficultyLvFlag { get; set; } //MonsterFlag == true, ShopFlag ==false


}

public class Weapon : Equipment
{
    public float Atk { get; set; }

    public override float GetValue()
    {
        return Atk;
    }
    public override void Equip(Player player)
    {
        IsEquiped = true;
        player.Atk += this.GetValue();
    }
    public override void UnEquip(Player player)
    {
        IsEquiped = false;
        player.Atk -= this.GetValue();
    }
}

public class Armor : Equipment
{
    public float Def { get; set; }
    public override float GetValue()
    {
        return Def;
    }
    public override void Equip(Player player)
    {
        IsEquiped = true;
        player.Def += this.GetValue();
    }
    public override void UnEquip(Player player)
    {
        IsEquiped = false;
        player.Def -= this.GetValue();
    }
}