using System.Runtime.CompilerServices;

namespace EIEIE_Project;

public class Character
{
    protected int level;
    public virtual int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    public string Name { get; set; }
    public string Details { get; set; }
    protected float atk;
    public virtual float Atk
    {
        get
        {
            return atk;
        }
        set
        {
            atk = value;
        }
    }
    protected float def;
    public virtual float Def
    {
        get
        {
            return def;
        }
        set
        {
            def = value;
        }
    }
    public float MaxHP { get; set; }
    public float NowHP { get; set; }
    public float MaxMP { get; set; }
    public float NowMP { get; set; }

    //�Ϲ� ����
    public void Attack(Character attacker, Character target)
    {
        float tempHP = target.NowHP;
        Random random = new Random();
        int max = (int)Math.Ceiling(attacker.Atk + (attacker.Atk * 0.1));
        int min = (int)Math.Ceiling(attacker.Atk - (attacker.Atk * 0.1));
        if (random.Next(1, 101) <= 10)
        {
            Utility.ColorWrite("�ƹ��ϵ� �Ͼ�� �ʾҽ��ϴ�", ConsoleColor.Red);
            Console.WriteLine();
        }
        else
        {
            if (random.Next(1, 101) <= 15)
            {
                if ((random.Next(min, max) - target.Def * 0.5) <= 0)
                {
                    target.NowHP = (float)(target.NowHP - 1);
                }
                else
                {
                    target.NowHP = (float)(target.NowHP - (random.Next(min, max) + Math.Ceiling(random.Next(min, max) * 0.6)) - target.Def * 0.5);
                }
                    
                //Console.WriteLine("ġ��Ÿ ����!!");
                Utility.ColorWrite("ġ��Ÿ ����!!", ConsoleColor.Red);
                Console.WriteLine("Lv.{0} {1} ��(��) ������ϴ�. [������] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", target.Level, target.Name);
                Console.WriteLine();

            }
            else
            {
                if ((random.Next(min, max) - target.Def * 0.5) <= 0)
                {
                    target.NowHP = (float)(target.NowHP - 1);
                }
                else
                {
                    target.NowHP = (float)(target.NowHP - (random.Next(min, max) - target.Def * 0.5));
                }
                Console.WriteLine("Lv.{0} {1} ��(��) ������ϴ�. [������] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", target.Level, target.Name);
                Console.WriteLine();
            }
        }
    }
    //��ų���
    public bool CharacterSkil(Character attacker, Character target, Skil skil)
    {
        if (attacker.NowMP < skil.Cost)
        {
            Utility.ColorWrite("MP�� �����մϴ�", ConsoleColor.Red);
            Console.WriteLine();
            Console.WriteLine("���� MP : {0}", attacker.NowMP);
            Console.ReadKey();
            Console.Clear();
            return false;
        }
        else
        {
            float tempHP = target.NowHP;
            float tempMP = attacker.NowMP;
            Console.WriteLine("{0}�� {1} ��ų��� ", attacker.Name, skil.Name);
            //target.NowHP = (float)(target.NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
            if (skil.type == 1)
            {
                Random random = new Random();
                if (random.Next(1, 100) <= 15)
                {
                    Utility.ColorWrite("ġ��Ÿ ����!!", ConsoleColor.Red);
                    if ((float)((Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5) <= 0)
                    {
                        target.NowHP = (float)(target.NowHP - 1);
                    }
                    else
                    {
                        target.NowHP = (float)(target.NowHP - (skil.Damage + (attacker.atk * skil.skilRatiod) + ((attacker.atk * skil.skilRatiod) * 0.6)) - target.Def * 0.5);
                    }

                    Console.WriteLine("Lv.{0} {1} ��(��) ������ϴ�. [������] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                    return true;
                }
                else
                {
                    if ((float)((Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5) <= 0)
                    {
                        target.NowHP = (float)(target.NowHP - -1);
                    }
                    else
                    {
                        target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5);
                    }
                    Console.WriteLine("Lv.{0} {1} ��(��) ������ϴ�. [������] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                    return true;
                }

            }
            else
            {
                if ((float)((Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5) <= 0)
                {
                    target.NowHP = (float)(target.NowHP - 1);
                }
                else
                {
                    target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5);

                    Console.WriteLine("Lv.{0} {1} ��(��) ������ϴ�. [������] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                }

                return true;
            }
            
        }
        return false;
    }

}
public class Player : Character
{
    public override int Level
    {
        get
        {
            return level;
        }
        set
        {
            if (level != value)
            {
                level = value;
                Atk += (level - 1) * 0.5f;
                Def += (level - 1) * 1f;
                MaxExp += 20 + 5 * (level - 1);
            }
        }
    }
    private string job;
    public string Job
    {
        get
        {
            return job;
        }
        set
        {
            job = value;
            if (job == "����")
            {
                MaxHP = 150;
                NowHP = 150;
                Atk = 15;
                Def = 2;
                MaxMP = 20;
                NowMP = 20;
            }
            else if (job == "������")
            {
                MaxHP = 100;
                NowHP = 100;
                Atk = 10;
                Def = 1;
                MaxMP = 50;
                NowMP = 50;
            }
            else if (job == "���谡")
            {
                MaxHP = 150;
                NowHP = 150;
                Atk = 20;
                Def = 15;
                MaxMP = 50;
                NowMP = 50;
            }
        }
    }

    public int MaxExp { get; set; }
    private int nowExp;
    public int NowExp
    {
        get
        {
            return nowExp;
        }
        set
        {
            if (nowExp != value)
            {
                nowExp += value;
                if (nowExp == MaxExp)
                {
                    nowExp = 0;
                    Level++;
                }
                else if (nowExp > MaxExp)
                {
                    int extraExp = nowExp - MaxExp;
                    Level++;
                    while (extraExp - MaxExp > 0)
                    {
                        extraExp -= MaxExp;
                        Level++;
                    }
                    nowExp = extraExp;
                }
            }
        }
    }
    public int Gold { get; set; }


}

public class Monster : Character // Monster ĳ���� ����
{
    public int MonsterType { get; set; }
    public int MonsterID { get; set; }
    public bool IsDead { get; set; }
    // ���� ��� ���� -> ����� -> ���̾� - > �ǹ� -> ��� -> �÷�Ƽ�ѷ�ũ ���̴�.
    // ����(Lv.1~6) -> �����(Lv.7~12) -> ���̾�(Lv.13~18) -> �ǹ�(Lv.19~28) -> ���(Lv.29~35) -> �÷�Ƽ��(Lv.40~)
    public Monster(int id) // MonsterType 1���� ���, 2���� �����, 3���� ������
    {
        if (id == 1)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "��� ������[���: ����]"; // EasyScreen
            this.Atk = 3;
            this.Def = 0;
            this.MaxHP = 30;
            this.NowHP = 30;
            this.Details = "����: ��� ���� ����, ���׶� ��� �������̴�.";
        }
        else if (id == 2)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 2;
            this.Name = "���[���: ����]"; // EasyScreen
            this.Atk = 4;
            this.Def = 1;
            this.MaxHP = 28;
            this.NowHP = 28;
            this.Details = "����: ��� ���� ����, ������ ��Ƽ ����, ����� �������� �����Ѵ�.";
        }
        else if (id == 3)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "������ ���[���: ����]"; // EasyScreen
            this.Atk = 5;
            this.Def = 2;
            this.MaxHP = 33;
            this.NowHP = 33;
            this.Details = "����: �콼 ��Ʈ�ҵ�, ��ο� ������ ���� ����, ���⸦ ����־� ���� �������̴�.";
        }
        else if (id == 4)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "ȩ ���[���: ���� ����]"; // EasyScreen 
            this.Atk = 7;
            this.Def = 3;
            this.MaxHP = 50;
            this.NowHP = 50;
            this.Details = "����:  ������ or �콼 �ƹּҵ�, ����� �� ���� ���� ����, Ű�� ��� ��� �����̸� ��� ���ٴ� ������ ����,";
        }
        else if (id == 5)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "���̷���[���: ����]"; // NormalScreen
            this.Atk = 3;
            this.Def = 1;
            this.MaxHP = 15;
            this.NowHP = 15;
            this.Details = "����: ��� ���� ����, �׳� ���̷����̴� ������ �������� �ٴϱ� ������ �ٱ����� �������� ��������.";
        }
        else if (id == 6)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "�ü� ���̷���[���: ����]"; // NormalScreen
            this.Atk = 5;
            this.Def = 2;
            this.MaxHP = 20;
            this.NowHP = 20;
            this.Details = "����: Ȱ, ���� �����⸦ ����, �ױ������� �ü������� ����.";

        }
        else if (id == 7)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 3;
            this.Name = "���� ���̷���[���: ����]"; // NormalScreen
            this.Atk = 4;
            this.Def = 3;
            this.MaxHP = 23;
            this.NowHP = 23;
            this.Details = "����: ����ִ� ���� ���Ⱑ �پ���,�콼 �罽���� ����, ��ƻ����� ���翴���� ����.";

        }

        else if (id == 8)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "���Ǿ� ������ �𵥵�[���: �����]"; // NormalScreen
            this.Atk = 7;
            this.Def = 5;
            this.MaxHP = 48;
            this.NowHP = 48;
            this.Details = "����: �۷����� ����, �μ��� �ı� ���� ����, �ϳ� ���� ǰ���� ��� �ϰ� �ִ� ��ƻ����� �������翴���� ����. ";

        }
        else if (id == 9) //������
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 12;
            this.Name = "��������� ������ �𵥵�[���: ���� �����]"; // NormalScreen
            this.Atk = 8;
            this.Def = 9;
            this.MaxHP = 62;
            this.NowHP = 62;
            this.Details = "����: ���� ���������, �罽+�Ǳ� ���� ����, ��ƻ��� �ϳ� �Ƿ��� �ִ� �������̾��� �� ���� ������ �׾���?... ";
            // 10 ���� 1 Ȯ���� ���� ��������� ��� ��� ���� // �����ϸ� ���� Ȯ���� ���� ����������� ����ȴٴ� �ҹ��� �ִ�. 
        }
        else if (id == 10) // ������ ����
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 12;
            this.Name = "War ��Ʈ[���: ���� �����]"; // NormalScreen
            this.Atk = 10;
            this.Def = 1;
            this.MaxHP = 84;
            this.NowHP = 84;
            this.Details = "����: ���� �Ǳް���, ���� ��� or ���� ���� �Ѽչ��� ����, �߻� ������ �ľ��� �� �Ͽ����� �����Ϳ��� ���� ����� ��ȥ�� ���ļ� ź���Ѵٴ� �ҹ��� �ִ�, ";
        }
        else if (id == 11)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 12;
            this.Name = " ������ ��Ʈ��(�����)[���: �����]"; // HardScreen
            this.Atk = 7;
            this.Def = 5;
            this.MaxHP = 58;
            this.NowHP = 58;
            this.Details = "����: �б� or ����, ������ �ΰ��� ���� ���� �䰩 ����, �׻� ������ �񸻶��ִ�. ";
            //Console.WriteLine("��Ʈ���� ���� �پ��ϴ� ������ �� �������� ����� ��Ʈ���� �������� ����ִ�. �⺻ 2���� ũ���̸� ���� ����� ��ݽ� �ΰ� �Ϲݽ� �� �̴�. ��ġ�⸦ ������ ���� ��κ� ��� �Ѵٰ� �ϴ� ��������.");  ���� ����� �������� ��� ���� -> Dungeon �̵�
        }   //Console.WriteLine("��ȣ�ϴ� �ķ��� �ΰ��̸� �б�� �����Ҵ����� ����� �ż��ϰ� �Դ� �� �����Ѵ�.")
        
        else if (id == 12)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 14;
            this.Name = "���� ������ ��Ʈ��(�����)[���: ���̾�]"; // HardScreen
            this.Atk = 10;
            this.Def = 7;
            this.MaxHP = 65;
            this.NowHP = 65;
            this.Details = "����: ��Ʋ�׽�, �Ǳް��� ����, �ΰ��� �׿��� ��� �����ϱ⵵ �Ѵ�, ������ ����� �ڵ��̴� �����⸦ ��������. ";
        }
        else if (id == 13)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 15;
            this.Name = "half Ű�޶�[���: ���̾�]"; // HardScreen
            this.Atk = 12;
            this.Def = 5;
            this.MaxHP = 78;
            this.NowHP = 78;
            this.Details = "����: ��� ���� ����, Ű�޶�� ���� ����ü�� Ư�� ������ ������ ����ü�̴� ������ �پ��ؼ� Ư���ϱ� ����� ��ü�� �ƴ϶� ���� ���ϴ�. ";
            //����: ";
        }
        else if (id == 14)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 16;
            this.Name = "���� ��Ʈ��(�����)[���: ���̾�]"; // HardScreen
            this.Atk = 14;
            this.Def = 7;
            this.MaxHP = 70;
            this.NowHP = 70;
            this.Details = "����: �ּ� �ù���, ����� ���� ����, �ΰ� ���縦 ����ؼ� ����ǰ�� �����Ѵ�, ū ü���� ���� ����� ��ø�ϸ� ������ ��� �����ϰ��־ �����ϱ� �����. ";
            //����: �������� �����ʰ� ������� ������ ���� ���� ��Ʈ���� ��� ��� ������ ���� �ִ�. ";
        }
        
        else if (id == 15)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 18;
            this.Name = "������ ���� ��Ʈ��(�����)[���: ���� ���̾�]"; // HardScreen
            this.Atk = 30;
            this.Def = 10;
            this.MaxHP = 82;
            this.NowHP = 82;
            this.Details = "����: �ҵ�  �극��Ŀ or �ڸ��ٸ�, õ�갩��� ��� ����, ������ ���縦 ����� ���� �������̴� ������ Ưȭ�̸� �ܰ��� �ַ� ����Ѵ� ���� �������� ���¼��� ������...";
            //����:  ";
        }



        //else if (id == )
        //{
        //    this.MonsterType = 1;
        //    this.MonsterID = id;
        //    this.Level = 8;
        //    this.Name = "���� ����[]";
        //    this.Atk = 12;
        //    this.Def = 5;
        //    this.MaxHP = 80;
        //    this.NowHP = 80;
        //}
        //else if (id == )
        //{
        //    this.MonsterType = 3;
        //    this.MonsterID = id;
        //    this.Level = 5;
        //    this.Name = "ŷ ��� Boss[�ǹ�]";
        //    this.Atk = 10;
        //    this.Def = 10;
        //    this.MaxHP = 200;
        //    this.NowHP = 200;
        //}
        //else if (id == )
        //{
        //    this.MonsterType = 3;
        //    this.MonsterID = id;
        //    this.Level = 10;
        //    this.Name = "ŷ ��Ʈ��(�����)  Boss[]";
        //    this.Atk = 30;
        //    this.Def = 5;
        //    this.MaxHP = 450;
        //    this.NowHP = 450;
        //}
        //else if (id == )
        //{
        //    this.MonsterType = 3;
        //    this.MonsterID = id;
        //    this.Level = 15;
        //    this.Name = "�� ������ġ  Boss[]";
        //    this.Atk = 30;
        //    this.Def = 5;
        //    this.MaxHP = 600;
        //    this.NowHP = 600;
        //}
        //else
        //{
        //    //����ó��
        //}
        else
        {
            //����ó��
        }

    }
}

public class Skil
{
    public int ID { get; set; }
    public String? Name { get; set; }
    public float Damage { get; set; }
    public double skilRatiod { get; set; }
    public int range { get; set; }
    public bool IsHad { get; set; }
    public int Cost { get; set; }
    public int type { get; set; } // 1���� 2����
    public string Description { get; set; }
    public int Price { get; set; }

}