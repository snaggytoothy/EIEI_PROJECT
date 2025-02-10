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
            this.MaxHP = 28;
            this.NowHP = 28;
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
            this.MaxHP = 33;
            this.NowHP = 33;
            Console.WriteLine("����: Į�� �� ������ �콼 �ռҵ带 �տ� ��� �ִ�, ��ο� ���� ������ �԰��ִ�");
        }
        else if (id == 4)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "ȩ ���[���� �����]"; // EasyScreen 
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 54;
            this.NowHP = 54;
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
            this.NowHP = 15;
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
            this.MaxHP = 20;
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
            this.MaxHP = 23;
            this.NowHP = 23;
            Console.WriteLine("����: ����ִ� ���� ���Ⱑ �پ��ϴ�, ��κ� �콼 �罽������ ����, �ױ����� ���翴���� ����.");

        }
        else if (id == 7)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "������ ���̷���[����]"; // NormalScreen
            this.Atk = 4;
            this.Def = 3;
            this.MaxHP = 23;
            this.NowHP = 23;
            Console.WriteLine("����: ����ִ� ���� ���Ⱑ �پ��ϴ�, ��κ� �콼 �罽������ ����, �ױ����� ���翴���� ����.");

        }
        else if (id == 9) // ������ ����
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "War ��Ʈ[���� ���̾�]"; // NormalScreen
            this.Atk = 7;
            this.Def = 7;
            this.MaxHP = 63;
            this.NowHP = 63;
            Console.WriteLine("����: ���� �Ǳް���, ���� ��� or ���� ���� �Ѽչ��� ����, �߻� ������ �ľ��� �� �Ͽ����� �����Ϳ��� ���� ����� ��ȥ�� ���ļ� ź���Ѵٴ� �ҹ��� �ִ�, ");
        }
        else if (id == 10)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = " ������ ��Ʈ��(�����)[���̾�]"; // HardScreen
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 50;
            this.NowHP = 50;
            Console.WriteLine("����: �б� or ������ ��� �ִ�, ������ �ΰ��� ���� ���� �䰩�̸� �⺻ 2���� ũ���̴�. ");
            //Console.WriteLine("��Ʈ���� ���� �پ��ϴ� ������ �� �������� ����� ��Ʈ���� �������� ����ִ�. ���� ����� ��ݽ� �ΰ� �Ϲݽ� �� �̴�. ��ġ�⸦ ������ ���� ��κ� ��� �Ѵٰ� �ϴ� ��������.");  ���� ����� �������� ��� ���� -> Dungeon �̵�
        }   //Console.WriteLine("��ȣ�ϴ� �ķ��� �ΰ��̸� �б�� �����Ҵ����� ����� �ż��ϰ� �Դ� �� �����Ѵ�.")
        else if (id == 11)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 9;
            this.Name = "���� ������ ��Ʈ��(�����)[�ǹ�]"; // HardScreen
            this.Atk = 8;
            this.Def = 7;
            this.MaxHP = 65;
            this.NowHP = 65;
            Console.WriteLine("����: �ּ� �ù���, ü��+�Ǳ� �ռ� ������ ����, �ΰ� ���縦 ����ؼ� ����ǰ�� �����Ѵ�, ū ü���� ���� ����� ��ø�ϸ� ������ ��� �����ϰ��־ �����ϱ� �����. ");
        }
        else if (id == 12)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "���� ��Ʈ��(�����)[���̾�]"; // HardScreen
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 50;
            this.NowHP = 50;
            Console.WriteLine("����: �ּ� �ù���, ü��+�Ǳ� �ռ� ������ ����, �ΰ� ���縦 ����ؼ� ����ǰ�� �����Ѵ�, ū ü���� ���� ����� ��ø�ϸ� ������ ��� �����ϰ��־ �����ϱ� �����. ");
            Console.WriteLine("����: �������� �����ʰ� ������� ������ ���� ���� ��Ʈ���� ��� ��� ������ ���� �ִ�. ");
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