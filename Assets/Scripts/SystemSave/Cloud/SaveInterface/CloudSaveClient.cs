using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using UnityEngine;

public class CloudSaveClient : ISaveClient
{
    private readonly ICloudSaveDataClient _client = CloudSaveService.Instance.Data;
    
    public async Task Save(string key, object value)
    {
        var data = new Dictionary<string, object> { { key, value } };
        await Call(_client.ForceSaveAsync(data));
    }


    public async Task<T> Load<T>(string key)
    {
        var query = await Call(_client.LoadAsync(new HashSet<string> { key }));
        return query.TryGetValue(key, out var value) ? Deserialize<T>(value) : default;
    }


    public async Task Delete(string key)
    {
        await Call(_client.ForceDeleteAsync(key));
    }
    private static T Deserialize<T>(string input)
    {
        if (typeof(T) == typeof(string)) return (T)(object)input;
        return JsonConvert.DeserializeObject<T>(input);
    }

    private static async Task Call(Task action)
    {
        try
        {
            await action;
        }
        catch (CloudSaveValidationException e)
        {
            Debug.LogError(e);
        }
        catch (CloudSaveRateLimitedException e)
        {
            Debug.LogError(e);
        }
        catch (CloudSaveException e)
        {
            Debug.LogError(e);
        }
    }

    private static async Task<T> Call<T>(Task<T> action)
    {
        try
        {
            return await action;
        }
        catch (CloudSaveValidationException e)
        {
            Debug.LogError(e);
        }
        catch (CloudSaveRateLimitedException e)
        {
            Debug.LogError(e);
        }
        catch (CloudSaveException e)
        {
            Debug.LogError(e);
        }

        return default;
    }
}