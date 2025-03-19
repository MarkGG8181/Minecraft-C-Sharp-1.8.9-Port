namespace Minecraft1_8_9Port.net.minecraft.util;

public class Session
{
    private string username;
    private string playerID;
    private string token;
    
    public Session(string usernameIn, string playerIDIn, string tokenIn, string sessionTypeIn)
    {
        this.username = usernameIn;
        this.playerID = playerIDIn;
        this.token = tokenIn;
    }
    
    public string getSessionID()
    {
        return "token:" + this.token + ":" + this.playerID;
    }
    
    public string getPlayerID()
    {
        return this.playerID;
    }

    public string getUsername()
    {
        return this.username;
    }

    public string getToken()
    {
        return this.token;
    }
    
    /*
    public GameProfile getProfile()
    {
        try
        {
            UUID uuid = UUIDTypeAdapter.fromString(this.getPlayerID());
            return new GameProfile(uuid, this.getUsername());
        }
        catch (IllegalArgumentException var2)
        {
            return new GameProfile((UUID)null, this.getUsername());
        }
    }
    */
}