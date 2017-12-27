using System;
using System.Collections.Generic;
using WerewolfOneNight.Enums;
using WerewolfOneNight.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WerewolfOneNight
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const double opacity = 0.25;
        private const double defaultOpacity = 1;
        private List<RoleEnum> roles;

        public MainPage()
        {
            this.InitializeComponent();
            roles = new List<RoleEnum>();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            roles = LocalStorage.Instance.RolesEnum;
            if (roles == null)
            {
                roles = new List<RoleEnum>();
            }
            PrepareUI();
        }

        private void PrepareUI()
        {
            foreach (var role in roles)
            {
                if (role == RoleEnum.Mason || role == RoleEnum.Werewolf || role == RoleEnum.Villager)
                {
                    var count = roles.FindAll(x => x == role).Count;
                    for (int i = 1; i <= count; i++)
                    {
                        var Image = ControlsHelper.FindControl<Image>(this.gridParent, typeof(Image), role.ToString() + i);
                        Image.Opacity = defaultOpacity;
                    }
                }
                else
                {
                    var Image = ControlsHelper.FindControl<Image>(this.gridParent, typeof(Image), role.ToString());
                    Image.Opacity = defaultOpacity;
                }
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var image = (Image)sender;
            if (image.Opacity == defaultOpacity)
            {
                image.Opacity = opacity;
                roles.Remove(image.GetRole());
            }
            else
            {
                image.Opacity = defaultOpacity;
                roles.Add(image.GetRole());
            }
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string roleValues = null;
            foreach (var role in roles)
            {
                roleValues += role.ToString() + " ";
            }
            LocalStorage.Instance.Roles = roleValues;

            this.Frame.Navigate(typeof(GamePlay));
        }
    }
}
