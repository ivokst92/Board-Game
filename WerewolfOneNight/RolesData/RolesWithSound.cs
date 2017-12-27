using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WerewolfOneNight.Enums;
using WerewolfOneNight.ViewModels;

namespace WerewolfOneNight.RolesData
{
    public class RolesWithSound
    {
        private const string imagesPath = @"Images/{0}.jpg";
        private static RolesWithSound instance;

        private RolesWithSound()
        {
            Roles = new List<RoleViewModel>()
            {
                new RoleViewModel(RoleEnum.Werewolf,
                string.Format(imagesPath,nameof(RoleEnum.Werewolf)),
                RoleDescription.Werewolf,
                new TimeSpan(0,0,10),
                new TimeSpan(0,0,3)),

                new RoleViewModel(RoleEnum.Minion,
                string.Format(imagesPath,nameof(RoleEnum.Minion)),
                RoleDescription.Minion,
                new TimeSpan(0,0,7),
                new TimeSpan(0,0,5)),

                new RoleViewModel(RoleEnum.Mason,
                string.Format(imagesPath,nameof(RoleEnum.Mason)),
                RoleDescription.Mason,
                new TimeSpan(0, 0, 4),
                new TimeSpan(0, 0, 2)),

            new RoleViewModel(RoleEnum.Seer,
                string.Format(imagesPath,nameof(RoleEnum.Seer)),
                RoleDescription.Seer,
                new TimeSpan(0, 0, 7),
                new TimeSpan(0, 0, 2)),

            new RoleViewModel(RoleEnum.Robber,
                string.Format(imagesPath,nameof(RoleEnum.Robber)),
                RoleDescription.Robber,
                new TimeSpan(0, 0, 9),
                new TimeSpan(0, 0, 2)),

            new RoleViewModel(RoleEnum.Troublemaker,
                string.Format(imagesPath,nameof(RoleEnum.Troublemaker)),
                RoleDescription.Troublemaker,
                new TimeSpan(0, 0, 6),
                new TimeSpan(0, 0, 3)),

            new RoleViewModel(RoleEnum.Drunk,
                string.Format(imagesPath,nameof(RoleEnum.Drunk)),
                RoleDescription.Drunk,
                new TimeSpan(0, 0, 7),
                new TimeSpan(0, 0, 2)),

            new RoleViewModel(RoleEnum.Insomniac,
                string.Format(imagesPath,nameof(RoleEnum.Insomniac)),
                RoleDescription.Insomniac,
                new TimeSpan(0, 0, 4),
                new TimeSpan(0, 0, 2)),
        };
        }

        public static RolesWithSound Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RolesWithSound();
                }
                return instance;
            }
        }

        public List<RoleViewModel> Roles;
    }
}
