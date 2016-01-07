using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using CC.Cache;
using CC.Data;
using InspireTools.Models;
using InspireTools.Repositories.Interfaces;

namespace InspireTools.Repositories {
    public class InspireRepository : Repository, IInspireAdmin {

        private readonly ICache _cache;
        private readonly ISql _sql;
        private const string CC_Inspire_NetworkDashboard_SearchCoaches = "careerdb.dbo.CC_Inspire_NetworkDashboard_SearchCoaches";

        public InspireRepository(ISql sql, ICache cache)
            : base(sql, cache) {
            _sql = sql;
            _cache = cache;
        }

        public dynamic SearchForCoachesInCcInspire(CCInspire data) {

            //We are looking for three types of searches--See Amir for further instructions
            //AmirD@careercruising.com

            return _sql.Query<dynamic>(
                   CC_Inspire_NetworkDashboard_SearchCoaches,
                    new {
                        SearchBar = data.SearchBar,
                        SearchOption = data.SearchOption
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
        }



       
        public dynamic GetCoachInfo(Con_PartnerUsers data) {
            strSQL = string.Format(@"careerdb.dbo.NetworkDashboard_GetCoachInfo {0}", data.PartnerUserID);
            var results = Sql.Query<DbCareer, dynamic>(strSQL);
            return Ok(new { CoachInfo = results });

        }

       
        public dynamic UpdateCoachInfo(UpdateCCInspire data) {
            try {
                //Dates need to be converted and fix bad data..
                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_UpdateCoaches {0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',
            '{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}',
            '{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}',
            '{35}','{36}','{37}',{38},'{39}','{40}','{41}',
            '{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}',{50},'{51}'",
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerFirstName),//0
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerMiddleInitial),//1
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerLastName),//2
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerNickname),//3
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerEmail),//4
                                                                       data.con_Users.PartnerPosition,//5
                                                                       data.con_Users.PartnerAreaCode,//6
                                                                       data.con_Users.IsSelfEmployed,//7
                                                                       data.con_Users.PartnerPhone,//8
                                                                       data.con_Users.PartnerExtension,//9
                                                                       data.con_Users.PartnerAreaCodeAlt,//10
                                                                       data.con_Users.PartnerPhoneAlt,//11
                                                                       data.con_Users.PartnerExtensionAlt,//12
                                                                       data.con_Users.PartnerAddr1,//13
                                                                       data.con_Users.PartnerAddr2,//14
                                                                       data.con_Users.PartnerCity,//15
                                                                       data.con_Users.PartnerState,//16
                                                                       data.con_Users.PartnerPostalZip,//17
                                                                       data.con_Users.PartnerUsername,//18
                                                                       data.con_Users.PartnerPassword,//19
                                                                       data.con_Users.PartnerStatusID,//20--No Edit in UI
                                                                       data.con_Users.CanContactSponsor,//21
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerBio),//22
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerOtherJobs),//23
                                                                       StringExtensions.FormatUserInput(data.con_Users.ProfMemberships),//24
                                                                       StringExtensions.FormatUserInput(data.con_Users.PartnerHobbies),//25
                                                                      MinimumDates.SqlDateValidator(data.con_Users.NameUsedSince), //26
                                                                      MinimumDates.SqlDateValidator(data.con_Users.DateRegistered),//27
                                                                      MinimumDates.SqlDateValidator(data.con_Users.LastLogin),//28
                                                                      MinimumDates.SqlDateValidator(data.con_Users.AddrUsedSince),//29
                                                                      MinimumDates.SqlDateValidator(data.con_Users.PartnerDateofBirth),//30
                                                                       data.con_Users.HasDriversLicense,//31
                                                                       data.con_Users.DriversLicenseState,//32
                                                                       data.con_Users.DriversLicenseNumber,//33
                                                                       data.con_Users.GovIDNumber,//34
                                                                       data.con_Users.GovIDState,//35
                                                                       data.con_Users.Gender,//36
                                                                       data.con_Users.CanEditProfile,//37
                                                                       data.con_Users.CompanyID,//38
                                                                       data.con_Users.IsMainCompContact,//39
                                                                       data.con_Users.CanContactStudents,//40
                                                                       data.con_Users.CanContactEducators,//41
                                                                       data.con_Users.IsCareerCoach,//42
                                                                       data.con_Users.IsNewCDOContact,//43
                                                                       StringExtensions.FormatUserInput(data.con_Users.CompanyOtherName),//44
                                                                       data.con_Users.CanMessageBoard,//45
                                                                       data.con_Users.CanOfferCDOCompany,//46
                                                                       data.con_Users.CanEditOpportunities,//47
                                                                       data.con_Users.CanOfferCDOPartner,//48
                                                                       StringExtensions.FormatUserInput(data.con_Users.HeardAboutText),//49
                                                                       data.con_Users.PartnerUserID,//50
                                                                       StringExtensions.FormatUserInput(data.con_Users.CompanyName)//51
                                                                       );
                var results = Sql.Query<DbCareer, dynamic>(strSQL);

                //Need to return errors if any.. Anders lind 1/5/2015 -- TODO
                //Databases raises errors in stored procedures.
                return Ok(new { Errors = results });
            } catch (Exception ex) {
                string error = ex.InnerException.ToString();
                return BadRequest(ex.InnerException.ToString());
            }
        }

        
        public dynamic DeleteCoaches(Con_PartnerUsers data) {
            try {
                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_DeleteCoaches {0}", data.PartnerUserID);
                var results = Sql.Query<DbCareer, dynamic>(strSQL);
                return Ok(new { CoachInfo = results });
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.ToString());
            }
        }
        //Cams Related Serches
        
        public dynamic SearchForWlaCoordinator(CCInspire data) {

            //We are looking for three types of searches--See Amir for further instructions
            //AmirD@careercruising.com
            //Email,Name,Company Name
            strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_WlaCoordinator '{0}'", data.SearchBar);
            var results = Sql.Query<DbCareer, dynamic>(strSQL);
            return Ok(new { Results = results });

        }

       
        public dynamic UpdateWlaCoordinator(UpdateWlaCoordinators data) {
            try {
                //We are looking for three types of searches--See Amir for further instructions
                //AmirD@careercruising.com
                //adminId, firstname,lastname,email,IsNetworkCDOContact
                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_UpdateWlaCoordinator {0},'{1}','{2}','{3}','{4}'", data.portfolioAdmin.AdminID, data.portfolioAdmin.FirstName, data.portfolioAdmin.LastName, data.portfolioAdmin.Email, data.portfolioAdmin.IsNetworkCDOContact);
                var results = Sql.Query<DbCareer, dynamic>(strSQL);
                return Ok(new { Errors = results });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }

        }


        
        public dynamic ChangeSchoolForCcInspire(CCInspire data) {
            try {
                //We are looking for three types of searches--See Amir for further instructions
                //AmirD@careercruising.com
                //adminId, firstname,lastname,email,IsNetworkCDOContact
                var createSafeSqlString = Regex.Replace(data.SearchBar, @"\r\n?|\n", ",");
                string strSQL = "select cs.Consysname as Implementation, ui.consysid,ui.InstitutionName,ui.schoolid  from userinfo ui left join con_systems cs  on ui.consysid = cs.consysid where ui.schoolid in(" + createSafeSqlString + ")";
                Task t = Task.Run(() => Sql.Query<DbCareer, dynamic>(strSQL));

                var results = t;


                return Ok(new { Results = results });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }

        }

       
        public async Task<dynamic> UpdateSchoolForCcInspire(UserInfo data) {
            try {
                //We are looking for three types of searches--See Amir for further instructions
                //AmirD@careercruising.com
                //, Schoolid,Consysid,InstitutionName
                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_UpdateSchoolsForCcInspire {0},{1},'{2}'", data.schoolid, data.consysid, data.InstitutionName);

                var results = await Task.Run(() => Sql.Query<DbCareer, dynamic>(strSQL));

                return Ok(new { Results = results });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }

        }

       
        public async Task<dynamic> ActivateSchools_CcInspire(UserInfoList list) {
            try {
                foreach (UserInfo c in list.UserInfo) {

                    //consysid
                    //schoolid 
                    strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_UpdateSchoolsWithProgramConSysId {0},{1}", list.ConsysId, c.schoolid);
                    var results = await Task.Run(() => Sql.Query<DbCareer, dynamic>(strSQL));
                }
                return Ok(new { Results = "" });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }

        }

       
        public async Task<dynamic> DeactivateSchools_CcInspire(UserInfoList list) {
            try {

                if (list.UpdateUserInfo.consysid <= 0) {
                    list.UpdateUserInfo.consysid = 0;
                }

                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_UpdateSchoolsWithProgramConSysId {0},{1}", list.UpdateUserInfo.consysid, list.UpdateUserInfo.schoolid);
                var results = await Task.Run(() => Sql.Query<DbCareer, dynamic>(strSQL));

                return Ok(new { Results = "" });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }
        }

       
        public dynamic FillConsystemList() {
            try {
                //We are looking for three types of searches--See Amir for further instructions
                //AmirD@careercruising.com
                //, Schoolid,Consysid,InstitutionName

                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_Con_SystemsList", "");

                var results = Sql.CacheQuery<DbCareer, dynamic>("CCConSystemList", strSQL);
                return Ok(new { Results = results });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }

        }
       
        public dynamic CreateConSystemAccount(Con_Systems con) {
            //  ImageFactory.SaveImage("HeaderLogo_", con.Consystems.HeaderLogo, con.Consystems.HeaderLogoName, con.Consystems.ConSysName);

            //15
            //                                                                      
            //            //Create a enum for Logo types
            strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_CreateCCInspireImplementation 
                        '{0}','{1}','{2}','{3}','{4}','{5}','{6}',
                        '{7}','{8}','{9}','{10}','{11}','{12}','{13}',
                        '{14}','{15}','{16}','{17}','{18}','{19}','{20}',
                        '{21}','{22}'",
                                                                      StringExtensions.FormatUserInput(con.Consystems.ConSysName),//0
                                                                      StringExtensions.FormatUserInput(con.Consystems.ConSysAddress1),//1
                                                                      StringExtensions.FormatUserInput(con.Consystems.ConSysAddress2),//2
                                                                      StringExtensions.FormatUserInput(con.Consystems.ConSysCity),//3
                                                                      StringExtensions.FormatUserInput(con.Consystems.ConSysState),//4
                                                                      con.Consystems.ConSysPostalZip,//5
                                                                      con.Consystems.ConSysCountry,//6
                                                                      con.Consystems.MainPhone,//7
                                                                      con.Consystems.ConSysFax,//8
                                                                      con.Consystems.MainEmail,//9
                                                                      con.Consystems.ConSysUsername,//10
                                                                      con.Consystems.ReplyToEmailAddr,//11
                                                                      con.Consystems.ConSysReferrer,//12
                                                                      con.Consystems.PartnerSignUpLink,//13
                                                                      con.Consystems.ClusterType,//14
                                                                      ImageFactory.SaveImage("HeaderLogo_", con.Consystems.HeaderLogo, con.Consystems.HeaderLogoName, con.Consystems.ConSysName),//15
                                                                      con.Consystems.SignUpFormIntro,//16
                                                                      con.Consystems.SignUpFormTY,//17
                                                                      con.Consystems.TermsConditions,//18
                                                                      con.Consystems.CDO_InstrCAMS_EN,//19
                                                                      StringExtensions.FormatUserInput(con.Consystems.CDO_InstrCAMS_SP),//20
                                                                      StringExtensions.FormatUserInput(con.Consystems.CDO_InstrCAMS_FR),//21
                                                                      ImageFactory.SaveImage("MainHeaderLogo_", con.Consystems.MainHeaderLogo, con.Consystems.MainHeaderLogo, con.Consystems.ConSysName));//22


            //  strSQL = "select * from Con_SystemsUsers";
            var results = Sql.Query<DbCareer, dynamic>(strSQL);
            //   string jsonString = javaScriptSerializer.Serialize(employee);

            //   string strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_CreateConSystemAccount", "");
            //     var results = Sql.Query<DbCareer, dynamic>(strSQL);
            return Ok(new { Results = results });

        }

        
        public dynamic GetCountries() {
            //HttpPostedFileBase file
            // Impersonate im = new Impersonate();
            ///   im.DoWorkUnderImpersonation();
            //string strSQL = "select * from Con_SystemsUsers";
            //var results = Sql.Query<DbCareer, dynamic>(strSQL);
            //string jsonString = javaScriptSerializer.Serialize(employee);


            try {
                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_SchoolCountryList", "");
                var results = Sql.Query<DbCareer, dynamic>(strSQL);
                return Ok(new { Results = results });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }

        }

        //Adding activites 
        //Student: Wibstudent | training
        //Partner: amird@careercruising.com | 123456

        
        public dynamic CreateActivities(Con_Systems Activities) {

            try {
                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_CreateActivities {0},'{1}','{2}','{3}','{4}'", Activities.Activities.ConSysId, Activities.Activities.OppCatName_EN.FormatUserInput(true), Activities.Activities.OppCatDescr_EN.FormatUserInput(true), Activities.Activities.OppCatName_SP.FormatUserInput(true), Activities.Activities.OppCatDescr_SP.FormatUserInput(true));

                var results = Sql.Query<DbCareer, dynamic>(strSQL);
                return Ok(new { Results = results });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }

        }

      
        public dynamic ActivitesList(Con_OppCategoryLookUp con_OppCategoryLookUp) {
            try {
                strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_Con_SystemsListAndActivities {0}", con_OppCategoryLookUp.ConSysId);
                var results = Sql.Query<DbCareer, Con_OppCategoryLookUp>(strSQL);
                return Ok(new { Results = results });
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }
        }

       
        public dynamic DeleteActivites(Con_Systems activitiesList) {
            Help _help = new Help();
            try {
                //Loop and delete
                foreach (Con_OppCategoryLookUp c in activitiesList.ActivitiesList) {
                    strSQL = string.Format(@"careerdb.dbo.CC_Inspire_NetworkDashboard_Con_Systems_Delete_Activity {0}", c.OppCatId);
                    _help.CreateObject = Sql.Query<DbCareer, dynamic>(strSQL);
                }

                return Ok(_help.CreateObject);
            } catch (Exception ex) {
                return CareerCruising_AdminApp.Controllers.ApiControllerExtension.NotFound(this, ex.InnerException.ToString());
            }
        }
    }
}