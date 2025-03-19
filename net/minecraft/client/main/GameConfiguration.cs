using System.Net;
using Minecraft1_8_9Port.com.mojang.authlib.properties;
using Minecraft1_8_9Port.net.minecraft.util;

namespace Minecraft1_8_9Port.net.minecraft.client.main;

public class GameConfiguration
{
    public GameConfiguration.UserInformation userInfo;
    public GameConfiguration.DisplayInformation displayInfo;
    public GameConfiguration.FolderInformation folderInfo;
    public GameConfiguration.GameInformation gameInfo;
    public GameConfiguration.ServerInformation serverInfo;
    
    public GameConfiguration(GameConfiguration.UserInformation userInfoIn, GameConfiguration.DisplayInformation displayInfoIn, GameConfiguration.FolderInformation folderInfoIn, GameConfiguration.GameInformation gameInfoIn, GameConfiguration.ServerInformation serverInfoIn)
    {
        this.userInfo = userInfoIn;
        this.displayInfo = displayInfoIn;
        this.folderInfo = folderInfoIn;
        this.gameInfo = gameInfoIn;
        this.serverInfo = serverInfoIn;
    }
        
    public class DisplayInformation
    {
        public int width;
        public int height;
        public bool fullscreen;
        public bool checkGlErrors;

        public DisplayInformation(int widthIn, int heightIn, bool fullscreenIn, bool checkGlErrorsIn)
        {
            this.width = widthIn;
            this.height = heightIn;
            this.fullscreen = fullscreenIn;
            this.checkGlErrors = checkGlErrorsIn;
        }
    }
    
    public class FolderInformation
    {
        public DirectoryInfo mcDataDir { get; }
        public DirectoryInfo resourcePacksDir { get; }
        public DirectoryInfo assetsDir { get; }
        public string assetIndex { get; }

        public FolderInformation(DirectoryInfo mcDataDir, DirectoryInfo resourcePacksDir, DirectoryInfo assetsDir, string assetIndex)
        {
            mcDataDir = mcDataDir;
            resourcePacksDir = resourcePacksDir;
            assetsDir = assetsDir;
            assetIndex = assetIndex;
        }
    }
    
    public class GameInformation
    {
        public string version;

        public GameInformation(string versionIn)
        {
            this.version = versionIn;
        }
    }
    
    public class ServerInformation
    {
        public string serverName;
        public int serverPort;

        public ServerInformation(string serverNameIn, int serverPortIn)
        {
            this.serverName = serverNameIn;
            this.serverPort = serverPortIn;
        }
    }
    
    public class UserInformation
    {
        public Session session;
        public PropertyMap userProperties;
        public PropertyMap profileProperties;
        public WebProxy proxy;

        public UserInformation(Session sessionIn, PropertyMap userPropertiesIn, PropertyMap profilePropertiesIn, WebProxy proxyIn)
        {
            this.session = sessionIn;
            this.userProperties = userPropertiesIn;
            this.profileProperties = profilePropertiesIn;
            this.proxy = proxyIn;
        }
    }
}