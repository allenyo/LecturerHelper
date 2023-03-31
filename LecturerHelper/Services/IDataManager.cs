using Models;

namespace LecturerHelper.Services
{
    public interface IDataManager
    {
        FacultyResponseModel Faculties();
        List<AutoHosqNumbers> AutoHosqNumbers();
        LoadResponseModel Loads();
        List<Kaefic> Kaefics();
        Patok1ResponseModel Patok1s();
        PatokNaraResponseModel PatokNaras();
        GroupsResponseModel Groups();
        string GetReport(string fakName);
    }
}
