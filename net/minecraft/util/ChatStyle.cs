using Minecraft1_8_9Port.net.minecraft.events;

namespace Minecraft1_8_9Port.net.minecraft.util;

public class ChatStyle
{
    private ChatStyle parentStyle;
    private EnumChatFormatting color;
    private Boolean bold;
    private Boolean italic;
    private Boolean underlined;
    private Boolean strikethrough;
    private Boolean obfuscated;
    private ClickEvent chatClickEvent;
    private HoverEvent chatHoverEvent;
    private string insertion;

    //TODO: finish: rootStyle, implement: getFormattingCode, toString, equals, hashCode, createShallowCopy, createDeepCopy, Serializer(deserialize, serialize)
    private static readonly ChatStyle rootStyle = new()
    {
    };

    public EnumChatFormatting getColor()
    {
        return this.color == null ? this.getParent().getColor() : this.color;
    }

    public bool getBold()
    {
        return this.bold == null ? this.getParent().getBold() : this.bold;
    }

    public bool getItalic()
    {
        return this.italic == null ? this.getParent().getItalic() : this.italic;
    }

    public bool getStrikethrough()
    {
        return this.strikethrough == null ? this.getParent().getStrikethrough() : this.strikethrough;
    }

    public bool getUnderlined()
    {
        return this.underlined == null ? this.getParent().getUnderlined() : this.underlined;
    }

    public bool getObfuscated()
    {
        return this.obfuscated == null ? this.getParent().getObfuscated() : this.obfuscated;
    }

    public bool isEmpty()
    {
        return this.bold == null && this.italic == null && this.strikethrough == null && this.underlined == null &&
               this.obfuscated == null && this.color == null && this.chatClickEvent == null &&
               this.chatHoverEvent == null;
    }

    private ChatStyle getParent()
    {
        return this.parentStyle == null ? rootStyle : this.parentStyle;
    }

    public ClickEvent getChatClickEvent()
    {
        return this.chatClickEvent == null ? this.getParent().getChatClickEvent() : this.chatClickEvent;
    }

    public HoverEvent getChatHoverEvent()
    {
        return this.chatHoverEvent == null ? this.getParent().getChatHoverEvent() : this.chatHoverEvent;
    }

    public string getInsertion()
    {
        return this.insertion == null ? this.getParent().getInsertion() : this.insertion;
    }

    public ChatStyle setColor(EnumChatFormatting color)
    {
        this.color = color;
        return this;
    }

    public ChatStyle setBold(Boolean boldIn)
    {
        this.bold = boldIn;
        return this;
    }

    public ChatStyle setItalic(Boolean italic)
    {
        this.italic = italic;
        return this;
    }

    public ChatStyle setStrikethrough(Boolean strikethrough)
    {
        this.strikethrough = strikethrough;
        return this;
    }

    public ChatStyle setUnderlined(Boolean underlined)
    {
        this.underlined = underlined;
        return this;
    }

    public ChatStyle setObfuscated(Boolean obfuscated)
    {
        this.obfuscated = obfuscated;
        return this;
    }

    public ChatStyle setChatClickEvent(ClickEvent eventa)
    {
        this.chatClickEvent = eventa;
        return this;
    }

    public ChatStyle setChatHoverEvent(HoverEvent eventa)
    {
        this.chatHoverEvent = eventa;
        return this;
    }

    public ChatStyle setInsertion(string insertion)
    {
        this.insertion = insertion;
        return this;
    }

    public ChatStyle setParentStyle(ChatStyle parent)
    {
        this.parentStyle = parent;
        return this;
    }
}