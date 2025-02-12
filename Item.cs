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

    public string BuffAmount { get; set; }
    
    public void Use(Player player)
    {
        if(player.NowHP >= player.MaxHP)
        {
            Utility.ColorWrite("이미 체력이 가득 차 있습니다.(아무 키나 눌러 확인)\n", ConsoleColor.Red);
        }
        else
        {
            Random random = new Random();
            int randomBuffAmount = random.Next(40, 51);
            BuffAmount = randomBuffAmount.ToString();
            player.NowHP += int.Parse(BuffAmount);
            if (player.NowHP > player.MaxHP)
            {
                player.NowHP = player.MaxHP;
            }
            Count--;
            Utility.ColorWrite($"체력이 {BuffAmount} 회복되었습니다.(아무 키나 눌러 확인)\n", ConsoleColor.Green);
        }
        Console.ReadKey();
    }
    public void RecoverMP(Player player) // MP회복 메서드
    {
        if (player.NowMP >= player.MaxMP)
        {
            Utility.ColorWrite("이미 마나가 가득 차 있습니다.(아무 키나 눌러 확인)\n", ConsoleColor.Red);
        }
        else
        {
            Random random = new Random();
            int randomBuffAmount = random.Next(20, 26);
            BuffAmount = randomBuffAmount.ToString();
            player.NowMP += int.Parse(BuffAmount);
            if (player.NowMP > player.MaxMP)
            {
                player.NowMP = player.MaxMP;
            }
            Count--;
            Utility.ColorWrite($"마나가 {BuffAmount} 회복되었습니다.(아무 키나 눌러 확인)\n", ConsoleColor.Blue);
        }
        Console.ReadKey();
    }

    public void Use(GameManager gameManager, int extraAtk) // 공격력 버프 물약
    {
        Count--;
        BuffAmount = extraAtk.ToString();
        gameManager.player.Atk += int.Parse(BuffAmount);
        Utility.ColorWrite("공격력이 10 올랐습니다.(아무 키나 눌러 확인)\n",ConsoleColor.Magenta);
        Buff buff = new Buff(EndAtkBuff, gameManager, 3);
        Console.ReadKey();
    }
    private void EndAtkBuff(GameManager gameManager)
    {
        gameManager.player.Atk -= int.Parse(BuffAmount);
        Utility.ColorWrite("사냥꾼의 물약이 효능을 다했습니다.(아무 키나 눌러 확인)\n", ConsoleColor.DarkMagenta);
        Console.ReadKey();
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