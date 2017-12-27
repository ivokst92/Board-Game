using System;
using WerewolfOneNight.Enums;

namespace WerewolfOneNight.ViewModels
{
    public class RoleViewModel
    {
        public RoleViewModel(RoleEnum role,
                            string imageSourcePath,
                            string skillDescription,
                            TimeSpan wakeUpDelay,
                            TimeSpan sleepDelay)
        {
            this.Role = role;
            this.ImageSourcePath = imageSourcePath;
            this.SkillDescription = skillDescription;
            this.WakeUpDelay = wakeUpDelay;
            this.SleepDelay = sleepDelay;
        }

        public TimeSpan WakeUpDelay { get; set; }

        public TimeSpan SleepDelay { get; set; }

        public RoleEnum Role { get; set; }

        public string ImageSourcePath { get; set; }

        public string SkillDescription { get; set; }
    }
}
