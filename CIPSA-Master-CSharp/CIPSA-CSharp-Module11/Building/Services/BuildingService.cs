using System;

namespace CIPSA_CSharp_Module11.Building.Services
{
    public abstract class BuildingService
    {
        public virtual string GetInformation(Models.Building building)
        {
            return string.Empty;
        }
    }
}
