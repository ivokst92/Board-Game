using System;
using System.Linq;
using System.Threading.Tasks;
using WerewolfOneNight.Helpers;
using WerewolfOneNight.RolesData;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WerewolfOneNight
{
    public sealed partial class GamePlay : Page
    {
        private readonly TimeSpan wakeUpDelay = new TimeSpan(0, 0, 7);
        private readonly TimeSpan sleepDelay = new TimeSpan(0, 0, 3);
        private readonly TimeSpan prepareForEndDelay = new TimeSpan(0, 0, 5);
        private readonly TimeSpan startDelay = new TimeSpan(0, 0, 3);
        private readonly TimeSpan everyoneWakeUpDelay = new TimeSpan(0, 0, 3);
        private const string GameImagePath = "Images/Game.jpg";

        public GamePlay()
        {
            this.InitializeComponent();
            this.Loaded += GamePlay_Loaded;
        }

        private async void GamePlay_Loaded(object sender, RoutedEventArgs e)
        {
            var roles = LocalStorage.Instance.RolesEnum.OrderBy(x => x).Distinct();
            Sound sound = new Sound();
            sound.StartGame();
            ChangeUI(GameImagePath, RoleDescription.CloseEyes);
            await Task.Delay(startDelay);
            foreach (var role in roles)
            {
                var model = RolesWithSound.Instance.Roles.Find(x => x.Role == role);

                //In case role without any sounds e.g. hunter, villager.
                if (model == null)
                {
                    continue;
                }

                ChangeUI(model.ImageSourcePath, model.SkillDescription);

                sound.WakeUp(role);
                //Speech delay plus default wake up delay
                await Task.Delay(model.WakeUpDelay+ wakeUpDelay);
                 gridRowOne.Children.Clear();
                sound.Sleep(role);
                //Sleep speech delay plus default sleep delay
                await Task.Delay(model.SleepDelay+ sleepDelay);
            }
            sound.PrepareForEnd();
            ChangeUI(GameImagePath, RoleDescription.PrepareForEnd);
            await Task.Delay(prepareForEndDelay+ everyoneWakeUpDelay);
            sound.EndGame();
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ChangeUI(string imageSourcePath, string skillDescription)
        {
            gridRowOne.Children.Clear();
            gridRowTwo.Children.Clear();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(this.BaseUri, imageSourcePath));
            TextBlock tb = new TextBlock()
            {
                Text = skillDescription,
                FontSize = 35,
                Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };
            gridRowOne.Children.Add(tb);
            gridRowTwo.Children.Add(image);
        }
    }
}
