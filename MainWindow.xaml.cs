using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flyweight_Pattern;

namespace Flyweight_Pattern
{
    public partial class MainWindow : Window
    {
        private CharacterFactory _characterFactory;

        public MainWindow()
        {
            InitializeComponent();
            _characterFactory = new CharacterFactory();
        }

        private void OnCreateCharacterClick(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string type = TypeTextBox.Text;
            string image = ImageTextBox.Text;

            // Получаем персонажа через фабрику
            Character character = _characterFactory.GetCharacter(name, type, image);
            // Проверяем, был ли создан персонаж
            if (character == null)
            {
                // Если персонаж не был создан, выводим сообщение об ошибке
                ResultTextBlock.Text = _characterFactory.ErrorMessage;
            }
            else
            {
                // Отображаем информацию о персонаже
                ResultTextBlock.Text = $"Персонаж: {character.Name}, Тип: {character.Type}, Изображение: {character.Image}, Уровень: {character.Level}, Опыт: {character.Experience}";
            }
        }
    }
}