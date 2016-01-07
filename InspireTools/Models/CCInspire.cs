using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspireTools.Models {
    public class CCInspire {
        public string SearchBar { get; set; }
        public string SearchOption { get; set; }
    }

    public class UpdateCCInspire {
        public Con_PartnerUsers con_Users { get; set; }
    }

    public class UpdateWlaCoordinators {
        public PortfolioAdmin portfolioAdmin { get; set; }
    }


    public class Con_PartnerUsers : Con_CompanyProfiles {

        public int PartnerUserID { get; set; }
        public string PartnerFirstName { get; set; }
        public string PartnerMiddleInitial { get; set; }
        public string PartnerLastName { get; set; }
        public string PartnerNickname { get; set; }
        public string PartnerEmail { get; set; }
        public string PartnerPosition { get; set; }
        public string PartnerAreaCode { get; set; }
        public bool IsSelfEmployed { get; set; }
        public string PartnerPhone { get; set; }
        public string PartnerExtension { get; set; }
        public string PartnerAreaCodeAlt { get; set; }
        public string PartnerPhoneAlt { get; set; }
        public string PartnerExtensionAlt { get; set; }
        public string PartnerAddr1 { get; set; }
        public string PartnerAddr2 { get; set; }
        public string PartnerCity { get; set; }
        public string PartnerState { get; set; }
        public string PartnerPostalZip { get; set; }
        public string PartnerUsername { get; set; }
        public string PartnerPassword { get; set; }
        public int PartnerStatusID { get; set; }
        public bool CanContactSponsor { get; set; }
        public string PartnerBio { get; set; }
        public string PartnerOtherJobs { get; set; }
        public string ProfMemberships { get; set; }
        public string PartnerHobbies { get; set; }
        public DateTime? NameUsedSince { get; set; }
        public DateTime? DateRegistered { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? AddrUsedSince { get; set; }
        public DateTime? PartnerDateofBirth { get; set; }
        public bool HasDriversLicense { get; set; }
        public string DriversLicenseState { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string GovIDNumber { get; set; }
        public string GovIDState { get; set; }
        public string Gender { get; set; }
        public bool CanEditProfile { get; set; }
        public int CompanyID { get; set; }
        //No edit need to review the business requirements-- Also how the data is related.
        public bool IsMainCompContact { get; set; }
        public bool CanContactStudents { get; set; }
        public bool CanContactEducators { get; set; }
        public bool IsCareerCoach { get; set; }
        public bool IsNewCDOContact { get; set; }
        public string CompanyOtherName { get; set; }
        public bool CanMessageBoard { get; set; }
        public bool CanOfferCDOCompany { get; set; }
        public bool CanEditOpportunities { get; set; }
        public bool CanOfferCDOPartner { get; set; }
        public string HeardAboutText { get; set; }

    }

    public class Con_BackCheckStatusLookup {
        public string BackCheckStatusDescr_EN { get; set; }

    }

    public class Con_CompanyProfiles {
        public string HasMessageBoard { get; set; }
        public string CompanyName { get; set; } //51
    }

    public class Con_PartnerStatusLookup {
        public string PartnerStatusName { get; set; }
    }

    public class PortfolioAdmin {
        public int AdminID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsNetworkCDOContact { get; set; }
    }

    public class UserInfo {
        public int consysid { get; set; }
        public string InstitutionName { get; set; }
        public int schoolid { get; set; }
    }

    public class UserInfoList {
        public List<UserInfo> UserInfo { get; set; }
        public UserInfo UpdateUserInfo { get; set; }
        public ConSystems Consystems { get; set; }
        public int ConsysId { get; set; }
    }

    public class Con_Systems {
        public ConSystems Consystems { get; set; }
        public Con_OppCategoryLookUp Activities { get; set; }
        public List<Con_OppCategoryLookUp> ActivitiesList { get; set; }
    }

    public class ConSystems {
        public int ConSysID { get; set; }
        public string ConSysName { get; set; }
        public string ConSysAddress1 { get; set; }
        public string ConSysAddress2 { get; set; }
        public string ConSysCity { get; set; }
        public string ConSysState { get; set; }
        public string ConSysCountry { get; set; }
        public string ConSysPostalZip { get; set; }
        public string MainPhone { get; set; }
        public string ConSysFax { get; set; }
        public string MainEmail { get; set; }
        public int? SystemStatus { get; set; }
        public string ConSysUsername { get; set; }
        public string ReplyToEmailAddr { get; set; }
        public int ConSchoolID { get; set; }
        public string ConSysReferrer { get; set; }
        public string PartnerSignUpLink { get; set; }
        public int PortTypeID { get; set; }
        public string ClusterType { get; set; }
        public string ConSysLogo { get; set; }
        public bool HasSponsorSplash { get; set; }
        public string SplashSysLogo { get; set; }
        public bool HasHeaderLogo { get; set; }
        public string HeaderLogo { get; set; }
        public string HeaderLogoName { get; set; }
        public bool? AllowNoCheckPartners { get; set; }
        public bool HasNewCDOOption { get; set; }
        public bool AdminCDOFollowup { get; set; }
        public bool PartnerCDOBgCheckByPass { get; set; }
        public bool CareerCoaches { get; set; }
        public bool IndustryProfiles { get; set; }
        public bool CompanyProfiles { get; set; }
        public bool VolunteerProfiles { get; set; }
        public bool CompanyMessageBoards { get; set; }
        public bool HasCompanyVideos { get; set; }
        public bool AllowStuMessages { get; set; }
        public bool AllowEduMessages { get; set; }
        public bool CDOFollowup_CompanyContact { get; set; }
        public bool CDOFollowup_CAMS { get; set; }
        public bool CDOFollowup_NetworkAdmin { get; set; }
        public int? CDOFollowup_ConSysAdminID { get; set; }
        public bool CDO_StudentAccess { get; set; }
        public bool CDO_CamsAccess { get; set; }
        public bool CDO_PartnerAccess { get; set; }
        public bool CDO_NetworkAdminAccess { get; set; }
        public bool CanOfferCDOPartner { get; set; }
        public bool CanOfferCDOCompany { get; set; }
        public bool? CDO_SurveyStudentAvailable { get; set; }
        public bool? CDO_SurveyCAMSAvailable { get; set; }
        public bool? CDO_SurveyPartnerAvailable { get; set; }
        public string CoachSignUpIntro { get; set; }
        public string CoachSignUpConcl { get; set; }
        public string CoachSignUpThankYou { get; set; }
        public string CompContactIntro { get; set; }
        public string CompContactConcl { get; set; }
        public string CompContactThankYou { get; set; }
        public string NewCompanyIntro { get; set; }
        public string NewCompanyConcl { get; set; }
        public string NewCompanyThankYou { get; set; }
        public string BGCheckInfo { get; set; }
        public string CDO_SelectionIntro { get; set; }
        public string SignUpFormIntro { get; set; }
        public string SignUpFormTY { get; set; }
        public string TermsConditions { get; set; }
        public string SignUpPartnerAttachment { get; set; }
        public string CDO_SignUpSelectionIntro { get; set; }
        public string CDO_InstrCAMS_EN { get; set; }
        public string CDO_InstrCAMS_SP { get; set; }
        public string CDO_InstrCAMS_FR { get; set; }
        public string CDO_MessageTips_EN { get; set; }
        public string CDO_MessageTips_FR { get; set; }
        public string CDO_MessageTips_SP { get; set; }
        public string CDO_StudentRequestOptIn_EN { get; set; }
        public string CDO_StudentRequestOptIn_FR { get; set; }
        public string CDO_StudentRequestOptIn_SP { get; set; }
        public string CDO_RequestCompleteMsg_EN { get; set; }
        public string CDO_RequestCompleteMsg_FR { get; set; }
        public string CDO_RequestCompleteMsg_SP { get; set; }
        public string CDO_FullSingle_EN { get; set; }
        public string CDO_FullPlural_EN { get; set; }
        public string CDO_FullArticle_EN { get; set; }
        public string CDO_ShortSingle_EN { get; set; }
        public string CDO_ShortPlural_EN { get; set; }
        public string CDO_ShortArticle_EN { get; set; }
        public string CDO_FullSingle_SP { get; set; }
        public string CDO_FullPlural_SP { get; set; }
        public string CDO_FullArticle_SP { get; set; }
        public string CDO_ShortSingle_SP { get; set; }
        public string CDO_ShortPlural_SP { get; set; }
        public string CDO_ShortArticle_SP { get; set; }
        public string CDO_FullSingle_FR { get; set; }
        public string CDO_FullPlural_FR { get; set; }
        public string CDO_FullArticle_FR { get; set; }
        public string CDO_ShortSingle_FR { get; set; }
        public string CDO_ShortPlural_FR { get; set; }
        public string CDO_ShortArticle_FR { get; set; }
        public string CDO_ShortAcronym_EN { get; set; }
        public string CDO_ShortAcronym_FR { get; set; }
        public string CDO_ShortAcronym_SP { get; set; }
        public string CDO_ShortAcronymPlural_EN { get; set; }
        public string CDO_ShortAcronymPlural_FR { get; set; }
        public string CDO_ShortAcronymPlural_SP { get; set; }
        public string CDO_btn_MoutImg { get; set; }
        public string CDO_btn_MoverImg { get; set; }
        public string CDO_tab_MoutImg { get; set; }
        public string CDO_tab_MoverImg { get; set; }
        public string CDO_btn_AddOpp { get; set; }
        public string CDO_btn_MoutTypeSrch { get; set; }
        public string CDO_btn_MoverTypeSrch { get; set; }
        public string CDO_inst_OppSearch { get; set; }
        public string CDO_hdr_OppSearch { get; set; }
        public string Con_MainLogo { get; set; }
        public string Con_MainTitle_EN { get; set; }
        public string Con_MainTitle_SP { get; set; }
        public string Con_MainTitle_FR { get; set; }
        public string Con_MainBlurb_EN { get; set; }
        public string Con_MainBlurb_SP { get; set; }
        public string Con_MainBlurb_FR { get; set; }
        public bool IsInternshipQuestionsActive { get; set; }
        public string SystemStatusUpdateRecipientEmails { get; set; }
        public string MainHeaderLogo { get; set; }
        public string MainHeaderLogoName { get; set; }
        public int? MonthlyMetricsOnOff { get; set; }
        public int? MonthlyMetricsSortByName { get; set; }
        public bool? Multilingual { get; set; }
    }

    public class CountriesModel {
        private int CountryId { get; set; }
        private string Name { get; set; }
    }

    public class Con_SystemsUsers {

    }

    public class Con_OppCategoryLookUp {
        public int ConSysId { get; set; }
        public int OppCatId { get; set; }

        [Display(Name = "English-Name")]
        public string OppCatName_EN { get; set; }

        [Display(Name = "English-Description")]
        public string OppCatDescr_EN { get; set; }

        [Display(Name = "Spanish-Name")]
        public string OppCatName_SP { get; set; }

        [Display(Name = "Spanish-Description")]
        public string OppCatDescr_SP { get; set; }

        public bool IsChecked { get; set; }
    }
}