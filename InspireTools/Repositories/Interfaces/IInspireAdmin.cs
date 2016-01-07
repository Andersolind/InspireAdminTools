using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CC.Data;
using InspireTools.Models;

namespace InspireTools.Repositories.Interfaces {
    public interface IInspireAdmin : IRepository {
        dynamic SearchForCoachesInCcInspire(CCInspire data);
        dynamic GetCoachInfo(Con_PartnerUsers data);
        dynamic UpdateCoachInfo(UpdateCCInspire data);
        dynamic DeleteCoaches(Con_PartnerUsers data);
        dynamic SearchForWlaCoordinator(CCInspire data);
        dynamic UpdateWlaCoordinator(UpdateWlaCoordinators data);
        dynamic ChangeSchoolForCcInspire(CCInspire data);
        Task<dynamic> UpdateSchoolForCcInspire(UserInfo data);
        Task<dynamic> ActivateSchools_CcInspire(UserInfoList list);
        Task<dynamic> DeactivateSchools_CcInspire(UserInfoList list);
        dynamic FillConsystemList();
        dynamic CreateConSystemAccount(Con_Systems con);
        dynamic GetCountries();
        //
        dynamic CreateActivities(Con_Systems Activities);
        dynamic ActivitesList(Con_OppCategoryLookUp con_OppCategoryLookUp);
        dynamic DeleteActivites(Con_Systems activitiesList);






    }
}
