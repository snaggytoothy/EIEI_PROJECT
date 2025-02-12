using Newtonsoft.Json;
using System.IO;

namespace EIEIE_Project;

public class SaveItemData
{
    public int ItemID;
    public bool IsEquiped;
}

public class SaveConsmable
{
    public int ItemID;
    public int Count;
}

public class SaveData
{
    public Player player;
    public List<SaveItemData> saveItemData;
    public List<SaveConsmable> SaveConsmableData;
}

public class Save
{
    public string FilePath = @"..\..\..\save.json";

    void SaveFile(SaveData data, String FilePath)
    {
        try
        {
            string userData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FilePath, userData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    static SaveData LoadData(String FilePath)
    {
        if (File.Exists(FilePath))
        {
            string userData = File.ReadAllText(FilePath);

            SaveData Save = JsonConvert.DeserializeObject<SaveData>(userData);

            return Save;
        }
        else
        {
            return null;
        }

    }

    public void LoadPlayer(ref Player player, List<Consumable> inventoryConsumables, List<Consumable> consumables ,List<Equipment> inventoryEquipment, List<Equipment> equipments)
    {
        if (File.Exists(FilePath))
        {
            SaveData loadData = LoadData(FilePath);

            player = loadData.player;
            Console.WriteLine(player.Name);
            Console.WriteLine(player.Gold);
            Console.WriteLine(player.Job);

            for (int i = 0; i < loadData.saveItemData.Count; i++)
            {
                inventoryEquipment.Add(equipments[equipments.FindIndex(x => x.ItemID.Equals(loadData.saveItemData[i].ItemID))]);
                inventoryEquipment[i].IsEquiped = loadData.saveItemData[i].IsEquiped;
            }
            for (int i = 0; i < loadData.SaveConsmableData.Count; i++)
            {
                inventoryConsumables.Add(consumables[consumables.FindIndex(x => x.ItemID.Equals(loadData.SaveConsmableData[i].ItemID))]);
                inventoryConsumables[i].Count = loadData.SaveConsmableData[i].Count;
            }

        }
        else
        {
            return;
        }
    }

    public void SavePlayer(Player player, List<Equipment> inventoryEquipment, List<Consumable> inventoryConsumables)
    {
        List<SaveItemData> saveItemDatas = new List<SaveItemData>();
        List<SaveConsmable> saveConsmables = new List<SaveConsmable>();
        for(int i = 0; i < inventoryEquipment.Count; i++)
        {
            saveItemDatas.Add(new SaveItemData { ItemID =  inventoryEquipment[i].ItemID ,IsEquiped = inventoryEquipment[i].IsEquiped });
        }
        for(int i =0;i<inventoryConsumables.Count; i++)
        {
            saveConsmables.Add(new SaveConsmable { ItemID = inventoryConsumables[i].ItemID, Count = inventoryConsumables[i].Count});
        }
        SaveData saveData = new SaveData() { player = player, saveItemData = saveItemDatas, SaveConsmableData = saveConsmables };
        SaveFile(saveData, FilePath);
    }


}