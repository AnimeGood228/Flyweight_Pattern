using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight_Pattern
{
    public class Character
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Image { get; private set; }

        // Атрибуты, которые не относятся к легковесным данным
        public int Level { get; set; }
        public int Experience { get; set; }

        public Character(string name, string type, string image)
        {
            Name = name;
            Type = type;
            Image = image;
        }
    }
    public class CharacterFactory
    {
        private readonly Dictionary<string, Character> _characters = new Dictionary<string, Character>();
        public string ErrorMessage { get; private set; }
        public Character GetCharacter(string name, string type, string image)
        {
            // Создаем ключ для поиска
            string key = $"{name}_{type}";

            // Проверяем, существует ли персонаж с таким именем и типом
            if (_characters.TryGetValue(key, out var existingCharacter))
            {
                ErrorMessage = $"Персонаж с именем '{name}' и типом '{type}' уже существует.";
                return null; // Возвращаем null в случае ошибки
            }

            // Создаем нового персонажа и добавляем его в коллекцию
            var newCharacter = new Character(name, type, image);
            _characters[key] = newCharacter;
            ErrorMessage = null; // Сбрасываем сообщение об ошибке

            return newCharacter; // Возвращаем нового персонажа
        }
    }
}
