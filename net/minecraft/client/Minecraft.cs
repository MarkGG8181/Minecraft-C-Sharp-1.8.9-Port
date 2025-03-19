using System.Net;
using Minecraft1_8_9Port.com.mojang.authlib.properties;
using Minecraft1_8_9Port.net.minecraft.client.main;
using Minecraft1_8_9Port.net.minecraft.client.resources;
using Minecraft1_8_9Port.net.minecraft.util;
using Minecraft1_8_9Port.org.apache.logging.log4j;
using Minecraft1_8_9Port.org.lwjgl;

namespace Minecraft1_8_9Port.net.minecraft.client;

public class Minecraft
{
    private static Logger logger = LogManager.getLogger();

    //private static ResourceLocation locationMojangPng = new ResourceLocation("textures/gui/title/mojang.png");
    public static byte[] memoryReserve = new byte[10485760];

    private DirectoryInfo fileResourcepacks;

    private PropertyMap profileProperties;
    //private ServerData currentServerData;
    //private TextureManager renderEngine;
    private static Minecraft theMinecraft;

    //public PlayerControllerMP playerController;
    private bool fullscreen;
    private bool enableGLErrorChecking = true;

    private bool hasCrashed;

    //private CrashReport crashReporter;
    public int displayWidth;
    public int displayHeight;
    private bool connectedToRealms = false;

    //private Timer timer = new Timer(20.0F);

    //private PlayerUsageSnooper usageSnooper = new PlayerUsageSnooper("client", this, MinecraftServer.getCurrentTimeMillis());
    //public WorldClient theWorld;
    //public RenderGlobal renderGlobal;
    //private RenderManager renderManager;
    //private RenderItem renderItem;
    //private ItemRenderer itemRenderer;
    //public EntityPlayerSP thePlayer;
    //private Entity renderViewEntity;
    //public Entity pointedEntity;
    //public EffectRenderer effectRenderer;
    private Session session;
    private bool isGamePaused;

    //public FontRenderer fontRendererObj;
    //public FontRenderer standardGalacticFontRenderer;
    //public GuiScreen currentScreen;
    //public LoadingScreenRenderer loadingScreen;
    //public EntityRenderer entityRenderer;
    private int leftClickCounter;
    private int tempDisplayWidth;

    private int tempDisplayHeight;

    //private IntegratedServer theIntegratedServer;
    //public GuiAchievement guiAchievement;
    //public GuiIngame ingameGUI;
    public bool skipRenderWorld;

    //public MovingObjectPosition objectMouseOver;
    //public GameSettings gameSettings;
    //public MouseHelper mouseHelper;
    public DirectoryInfo mcDataDir;
    private DirectoryInfo fileAssets;

    private string launchedVersion;

    private WebProxy proxy;
    //private ISaveFormat saveLoader;
    private static int debugFPS;
    private int rightClickDelayTimer;
    private string serverName;
    private int serverPort;
    public bool inGameHasFocus;
    long systemTime = getSystemTime();

    private int joinPlayerCounter;

    //public FrameTimer frameTimer = new FrameTimer();
    long startNanoTime = java.lang.System.nanoTime();
    private bool is64bit;

    private bool isDemo;

    //private NetworkManager myNetworkManager;
    private bool integratedServerIsRunning;

    //public Profiler mcProfiler = new Profiler();
    private long debugCrashKeyPressTime = -1L;

    //private IReloadableResourceManager mcResourceManager;
    //private IMetadataSerializer metadataSerializer_ = new IMetadataSerializer();
    private List<IResourcePack> defaultResourcePacks = new List<IResourcePack>();
    private DefaultResourcePack mcDefaultResourcePack;
    //private ResourcePackRepository mcResourcePackRepository;
    //private LanguageManager mcLanguageManager;
    //private IStream stream;
    //private Framebuffer framebufferMc;
    //private TextureMap textureMapBlocks;
    //private SoundHandler mcSoundHandler;
    //private MusicTicker mcMusicTicker;
    //private ResourceLocation mojangLogo;
    //private MinecraftSessionService sessionService;
    //private SkinManager skinManager;
    //private Queue < FutureTask<? >> scheduledTasks = Queues. < FutureTask<? >> newArrayDeque();
    private long field_175615_aJ = 0L;

    private Thread mcThread = Thread.CurrentThread;

    //private ModelManager modelManager;
    //private BlockRendererDispatcher blockRenderDispatcher;
    volatile bool running = true;
    public string debug = "";
    public bool field_175613_B = false;
    public bool field_175614_C = false;
    public bool field_175611_D = false;
    public bool renderChunksMany = true;
    long debugUpdateTime = getSystemTime();
    int fpsCounter;
    long prevFrameTime = -1L;
    private string debugProfilerName = "root";

    public static long getSystemTime()
    {
        return Sys.getTime() * 1000L / Sys.getTimerResolution();
    }

    public Minecraft(GameConfiguration gameConfig)
    {
        theMinecraft = this;
        this.mcDataDir = gameConfig.folderInfo.mcDataDir;
        this.fileAssets = gameConfig.folderInfo.assetsDir;
        this.fileResourcepacks = gameConfig.folderInfo.resourcePacksDir;
        this.launchedVersion = gameConfig.gameInfo.version;
        this.profileProperties = gameConfig.userInfo.profileProperties;
        this.mcDefaultResourcePack = new DefaultResourcePack((new ResourceIndex(gameConfig.folderInfo.assetsDir, gameConfig.folderInfo.assetIndex)).getResourceMap());
        this.proxy = gameConfig.userInfo.proxy == null ? WebProxy.GetDefaultProxy() : gameConfig.userInfo.proxy;
        //this.sessionService = (new YggdrasilAuthenticationService(gameConfig.userInfo.proxy, UUID.randomUUID().toString())).createMinecraftSessionService();
        this.session = gameConfig.userInfo.session;
        logger.info("Setting user: " + this.session.getUsername());
        logger.info("(Session ID is " + this.session.getSessionID() + ")");
        this.displayWidth = gameConfig.displayInfo.width > 0 ? gameConfig.displayInfo.width : 1;
        this.displayHeight = gameConfig.displayInfo.height > 0 ? gameConfig.displayInfo.height : 1;
        this.tempDisplayWidth = gameConfig.displayInfo.width;
        this.tempDisplayHeight = gameConfig.displayInfo.height;
        this.fullscreen = gameConfig.displayInfo.fullscreen;
        this.is64bit = isJvm64bit();
        //this.theIntegratedServer = new IntegratedServer(this);

        if (gameConfig.serverInfo.serverName != null)
        {
            this.serverName = gameConfig.serverInfo.serverName;
            this.serverPort = gameConfig.serverInfo.serverPort;
        }

        //ImageIO.setUseCache(false);
        //Bootstrap.register();
    }

    private static bool isJvm64bit()
    {
        return Environment.Is64BitOperatingSystem;
    }
}