namespace Minecraft1_8_9Port.net.minecraft.util;

public interface IChatComponent //: Iterable<IChatComponent>
{
    IChatComponent setChatStyle(ChatStyle style);

    ChatStyle getChatStyle();

    IChatComponent appendText(String text);

    IChatComponent appendSibling(IChatComponent component);

    String getUnformattedTextForChat();

    String getUnformattedText();

    String getFormattedText();

    List<IChatComponent> getSiblings();

    IChatComponent createCopy();

    //TODO: implement: Serializer(deserialize, serializeChatStyle, serialize, componentToJson, jsonToComponent)
}