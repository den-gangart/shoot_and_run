
namespace RunShooter
{
    public interface GameEvent
    {
        public string Name { get; }
        public object Data { get; }
    }

    public class BaseEvent : GameEvent
    {
        public string Name { get => _name; }
        public object Data { get => _data; }

        private string _name;
        private object _data;

        public BaseEvent(string name) : this(name, null) { }

        public BaseEvent(string name, object value)
        {
            _name = name;
            _data = value;
        }

        public T GetEventValue<T>()
        {
            return (T)_data;
        }
    }

    public class GameFieldEvent : BaseEvent
    {
        public const string ON_GAME_STARTED = "ON_GAME_STARTED";
        public const string ON_GAME_FINISHED = "ON_GAME_FINISHED";  
        public const string ON_ENEMY_DEAD = "ON_ENEMY_DEAD";
        public const string ON_PLAYER_SPAWNED = "ON_PLAYER_SPAWNED";
        public const string ON_PLAYER_DEAD = "ON_PLAYER_DEAD";

        public GameFieldEvent(string name) : base(name) { }
        public GameFieldEvent(string name, object value) : base(name, value) { }
    }

    public class UIEvent : BaseEvent
    {
        public const string ON_LOAD_SCREEN = "ON_LOAD_SCREEN";

        public UIEvent(string name) : base(name) { }
        public UIEvent(string name, object value) : base(name, value) { }
    }
}