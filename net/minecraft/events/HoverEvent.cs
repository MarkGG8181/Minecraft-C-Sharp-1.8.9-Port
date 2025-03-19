using Minecraft1_8_9Port.net.minecraft.util;

namespace Minecraft1_8_9Port.net.minecraft.events;

public class HoverEvent
    {
        public enum Action
        {
            SHOW_TEXT,
            SHOW_ACHIEVEMENT,
            SHOW_ITEM,
            SHOW_ENTITY
        }

        private static readonly Dictionary<string, Action> nameMapping = new Dictionary<string, Action>();

        private readonly Action action;
        private readonly IChatComponent value;

        static HoverEvent()
        {
            // Initialize the nameMapping dictionary
            foreach (var action in Enum.GetValues(typeof(Action)))
            {
                nameMapping.Add(action.ToString().ToLower(), (Action)action);
            }
        }

        public HoverEvent(Action action, IChatComponent value)
        {
            this.action = action;
            this.value = value;
        }

        public Action GetAction()
        {
            return this.action;
        }

        public IChatComponent GetValue()
        {
            return this.value;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj != null && this.GetType() == obj.GetType())
            {
                HoverEvent other = (HoverEvent)obj;

                return this.action == other.action && (this.value == null ? other.value == null : this.value.Equals(other.value));
            }
            return false;
        }

        public override string ToString()
        {
            return $"HoverEvent{{action={this.action}, value='{this.value}'}}";
        }

        public override int GetHashCode()
        {
            int hashCode = this.action.GetHashCode();
            hashCode = 31 * hashCode + (this.value != null ? this.value.GetHashCode() : 0);
            return hashCode;
        }

        public static Action GetValueByCanonicalName(string canonicalName)
        {
            return nameMapping.ContainsKey(canonicalName) ? nameMapping[canonicalName] : default;
        }
    }