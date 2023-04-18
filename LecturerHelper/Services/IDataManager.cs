using Models;

namespace LecturerHelper.Services
{
    public interface IDataManager
    {
        FacultyResponseModel Faculties();
        List<AutoHosqNumbers> AutoHosqNumbers();
        LoadResponseModel Loads();
        List<Data.Kaefic> Kaefics();
        Patok1ResponseModel Patok1s();
        PatokNaraResponseModel PatokNaras();
        GroupsResponseModel Groups();
        GroupPlanResponseModel GetGroupPlanByFakName(string fakName);
        GroupPlanResponseModel GetAllGroupPlan();
        GroupPlanResponseModel GetGroupPlanByGroup(string groupname);
        HosqResponse Hosq();
        GroupPlanResponseModel GetHosqPlan();
        LoadResponseModel GetLoadByCode(string code);
    }
}
