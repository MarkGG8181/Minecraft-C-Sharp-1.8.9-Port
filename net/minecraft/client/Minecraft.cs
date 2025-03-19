namespace Minecraft1_8_9Port.net.minecraft.client;

public class Minecraft{
    
    public static byte[] memoryReserve = new byte[10485760];
    private static Minecraft theMinecraft;
    private bool fullscreen;
    private bool enableGLErrorChecking = true;
    private bool hasCrashed;
    
    public int displayWidth;
    public int displayHeight;
    
    private bool isGamePaused;
    
    private int leftClickCounter;
    private int tempDisplayWidth;
    private int tempDisplayHeight;
    
    public bool skipRenderWorld;
    
    private static int debugFPS;
    private int rightClickDelayTimer;
    
    private int serverPort;
    public bool inGameHasFocus;
    
    long systemTime = getSystemTime();
    private int joinPlayerCounter;
    
    long startNanoTime = System.nanoTime();
    private bool is64bit;
    private bool integratedServerIsRunning;
    private long debugCrashKeyPressTime = -1L;
    
    volatile bool running = true;
    public String debug = "";
    
    public bool renderChunksMany = true;
    long debugUpdateTime = getSystemTime();
    int fpsCounter;
    long prevFrameTime = -1L;
    private String debugProfilerName = "root";
    
    public static long getSystemTime() {
        return Sys.getTime() * 1000L / Sys.getTimerResolution();
    }
    
}