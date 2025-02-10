namespace EIEIE_Project;

public class Character
{
    public int Level { get; set; }
    public string Name { get; set; }
    public float Atk { get; set; }
    public float Def { get; set; }
    public float MaxHP { get; set; }
    public float NowHP { get; set; }

    public void Attack(Character attacker, Character target)
    {
        Random random = new Random();
        int max = (int)Math.Ceiling(attacker.Atk + (attacker.Atk * 0.1));
        int min = (int)Math.Ceiling(attacker.Atk - (attacker.Atk * 0.1));

        target.NowHP = target.NowHP - random.Next(min, max);
    }
}
public class Player : Character
{
    public string Job { get; set; }
    public float MaxMP { get; set; }
    public float NowMP { get; set; }
    public int MaxExp { get; set; }
    public int NowExp { get; set; }
    public int Gold { get; set; }
}

public class Monster : Character // Monster ĳ���� ����
{
    public int MonsterType { get; set; }
    public int MonsterID { get; set; }
    public bool IsDead { get; set; }
    // ���� ��� ���� -> ����� -> ���̾� - > �ǹ� -> ��� -> �÷�Ƽ�ѷ�ũ ���̴�.
    public Monster(int id) // MonsterType 1���� ���, 2���� �����, 3���� ������
    {
        if (id == 1)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "��� ������[����]"; // EasyScreen
            this.Atk = 2;
            this.Def = 1;
            this.MaxHP = 30;
            this.NowHP = 30;
            Console.WriteLine("����: ���׶� ��� �������̴�.");
        }
        else if(id == 2)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 2;
            this.Name = "���[����]"; // EasyScreen
            this.Atk = 2;
            this.Def = 3;
            this.MaxHP = 30;
            this.NowHP = 30;
            Console.WriteLine("����: �Ǽջ���, �������� �ɰ��� ���� �θ����ִ�.");
        }
        else if (id == 3)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "������ ���[����]"; // EasyScreen
            this.Atk = 3;
            this.Def = 4;
            this.MaxHP = 38;
            this.NowHP = 38;
            Console.WriteLine("����: Į�� �� ������ �콼 �ռҵ带 �տ� ��� �ִ�, ��ο� ���� ������ �԰��ִ�");
        }
        else if (id == 4) // ������ ����
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "ȩ ���[���� �����]"; // EasyScreen 
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 45;
            this.NowHP = 45;
            Console.WriteLine("����: Ű�� ��� ��� ������, ����� �� ���� ������ �԰� �ִ�, ����� �����ϰ� ���� ������");
        }
        else if (id == 5)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "���̷���[����]"; // NormalScreen
            this.Atk = 2;
            this.Def = 1;
            this.MaxHP = 15;
            this.NowHP = 20;
            Console.WriteLine("����: �ƹ� ��� ���� �� �Ǿ��ִ� �׳� ���̷����̴� ������ �������� �ٴϱ� ������ �ٱ����� �������� ��������.");
        }
        else if (id == 6)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "�ü� ���̷���[����]"; // NormalScreen
            this.Atk = 5;
            this.Def = 2;
            this.MaxHP = 15;
            this.NowHP = 20;
            Console.WriteLine("����: Ȱ, ���� �����⸦ �����ϰ��ִ�, �ױ������� �ü������� ����.");

        }

        else if (id == 7)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 3;
            this.Name = "���� ���̷���[����]"; // NormalScreen
            this.Atk = 4;
            this.Def = 3;
            this.MaxHP = 16;
            this.NowHP = 20;
            Console.WriteLine("����: ����ִ� ���� ���Ⱑ �پ��ϴ�, ��κ� �콼 �罽������ ����, �ױ����� ���翴���� ����.");

        }
        else if (id == 8) // ������ ����
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "War ��Ʈ[���� ���̾�]"; // NormalScreen
            this.Atk = 7;
            this.Def = 6;
            this.MaxHP = 70;
            this.NowHP = 70;
            Console.WriteLine("����: ���� �Ǳް���, ���� ��� or ���� ���� �Ѽչ��� ����, �߻� ������ �ľ��� �� �Ͽ����� �����Ϳ��� ���� ����� ��ȥ�� ���ļ� ź���Ѵٴ� �ҹ��� �ִ�, ");
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
        //    this.Name = "���ɿ� �Ƚ� Boss[]";
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
        //    this.Name = "�𵥵� ������ Boss[]";
        //    this.Atk = 30;
        //    this.Def = 5;
        //    this.MaxHP = 600;
        //    this.NowHP = 600;
        //}
        //else
        //{
        //    //����ó��
        //}

    }
}