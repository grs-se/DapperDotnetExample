using AutoMapper;
using WellbeingWorkbook.Entities;
using WellbeingWorkbook.Models.Users;

namespace WellbeingWorkbook.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Create Request -> User
            CreateMap<CreateRequest, User>();

            //// UpdateRequest -> User
            //CreateMap<UpdateRequest, User>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest prop) =>
            //        {

            //        }
            //        ));
        }
    }
}
