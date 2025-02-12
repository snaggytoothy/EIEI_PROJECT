using Newtonsoft.Json;
using System.IO;
using System.Net;

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
public class SaveSkilData
{
    public int SkilID;
}

public class SaveData
{
    public Player? player;
    public List<SaveItemData>? saveItemData;
    public List<SaveConsmable>? SaveConsmableData;
    public List<SaveSkilData>? SaveSkilData;
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

    public void LoadPlayer(ref Player player, List<Consumable> inventoryConsumables, List<Consumable> consumables ,List<Equipment> inventoryEquipment, List<Equipment> equipments, List<Skil> skils, List<Skil> mySkils)
    {
        if (File.Exists(FilePath))
        {
            SaveData loadData = LoadData(FilePath);

            player = loadData.player;

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
            for (int i = 0; i < loadData.SaveSkilData.Count; i++)
            {
                mySkils.Add(skils[skils.FindIndex(x => x.ID.Equals(loadData.SaveSkilData[i].SkilID))]);
            }
        }
        else
        {
            return;
        }
    }

    public void SavePlayer(Player player, List<Equipment> inventoryEquipment, List<Consumable> inventoryConsumables, List<Skil> mySkils)
    {
        List<SaveItemData> saveItemDatas = new List<SaveItemData>();
        List<SaveConsmable> saveConsmables = new List<SaveConsmable>();
        List<SaveSkilData> saveSkilDatas = new List<SaveSkilData>();
        for(int i = 0; i < inventoryEquipment.Count; i++)
        {
            saveItemDatas.Add(new SaveItemData { ItemID =  inventoryEquipment[i].ItemID ,IsEquiped = inventoryEquipment[i].IsEquiped });
        }
        for(int i =0;i<inventoryConsumables.Count; i++)
        {
            saveConsmables.Add(new SaveConsmable { ItemID = inventoryConsumables[i].ItemID, Count = inventoryConsumables[i].Count});
        }
        for (int i = 0; i < mySkils.Count; i++) 
        {
            saveSkilDatas.Add(new SaveSkilData { SkilID = mySkils[i].ID });
        }
        SaveData saveData = new SaveData() { player = player, saveItemData = saveItemDatas, SaveConsmableData = saveConsmables ,SaveSkilData = saveSkilDatas};
        SaveFile(saveData, FilePath);
    }


}