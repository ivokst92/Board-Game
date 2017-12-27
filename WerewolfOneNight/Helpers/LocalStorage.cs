using System.Collections.Generic;
using WerewolfOneNight.Enums;
using Windows.Storage;

namespace WerewolfOneNight.Helpers
{
    public class LocalStorage
    {
        private const string containerKey = "Container";
        private const string rolesKey = "Roles";
        private ApplicationDataContainer localSettings;
        private ApplicationDataContainer container;
        private static LocalStorage instance;

        private LocalStorage()
        {
            this.BuildStorage();
        }

        public static LocalStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalStorage();
                }
                return instance;
            }
        }

        private void BuildStorage()
        {
            if (localSettings == null)
                localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            // Create a setting in a container

            if (!localSettings.Containers.ContainsKey(containerKey))
            {
                container =
                localSettings.CreateContainer(containerKey, Windows.Storage.ApplicationDataCreateDisposition.Always);
            }
        }

        public string Roles
        {
            get
            {
                var value = localSettings.Containers[containerKey].Values[rolesKey];
                var roles = value == null ? null : value.ToString();
                return roles;
            }
            set
            {
                localSettings.Containers[containerKey].Values[rolesKey] = value;
            }
        }

        public List<RoleEnum> RolesEnum
        {
            get
            {
                if (Roles == null)
                {
                    return null;
                }
                string[] currentRoles = Roles.Split(' ');
                List<RoleEnum> rolesEnum = new List<RoleEnum>();
                foreach (var currRole in currentRoles)
                {
                    if (!string.IsNullOrWhiteSpace(currRole) &&
                        !string.IsNullOrEmpty(currRole))
                        rolesEnum.Add(currRole.GetRole());
                }
                return rolesEnum;
            }
        }
    }
}
