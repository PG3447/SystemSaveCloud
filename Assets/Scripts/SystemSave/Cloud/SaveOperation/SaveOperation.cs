using System.Threading.Tasks;

public class SaveOperation
{
    private static readonly ISaveClient Client = new CloudSaveClient();


    public static async void SaveGameToCloud(GameData gameData) {
        await Client.Save("Save", gameData);
    }

    public static async Task<GameData> LoadGameOnCloud() {
        GameData gameData = await Client.Load<GameData>("Save");
        return gameData;
    }

    public static async Task<bool> CheckExistSaveOnCloud() {
        GameData gameData  = await Client.Load<GameData>("Save");
        if (gameData == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static async void DeleteSaveOnCloud() {
        await Client.Delete("Save");
    }
}
